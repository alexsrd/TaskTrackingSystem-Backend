using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.DAL;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _database;
        private readonly IJwtService _jwtService;

        public AuthenticationService(IUnitOfWork database, IJwtService jwtService)
        {
            _database = database;
            _jwtService = jwtService;

        }

        public async Task<IdentityResult> Register(RegisterDto registerUser)
        {
            var possibleUser = await _database.UserManager.FindByEmailAsync(registerUser.Email);
            if (possibleUser!= null)
            {
                return IdentityResult.Failed(new IdentityError(){Description = $"User with email {registerUser.Email} already exists"});
            }
            var user = new ApplicationUser
            {
                Email = registerUser.Email, 
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                FullName = registerUser.Name + " " + registerUser.Surname,
                Role = "User",
                UserName = registerUser.Email.Substring(0,registerUser.Email.IndexOf("@"))+registerUser.Surname[0]
            };

            var result = await _database.UserManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                _database.Save();
                result = await _database.UserManager.AddToRoleAsync(user,"USER");
            }
            _database.Save();
            return result;
        }

        public async Task<string> Login(LoginDto loginUser)
        {
            var user = await _database.UserManager.FindByEmailAsync(loginUser.Email);
            if (user != null && await _database.UserManager.CheckPasswordAsync(user, loginUser.Password))
            {
                var userRoles = await _database.UserManager.GetRolesAsync(user);
                return _jwtService.GenerateJwtToken(user,userRoles);
            }

            return String.Empty;
        }
    }
}