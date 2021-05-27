using System;
using System.Threading;
using System.Threading.Tasks;
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
            var user = new ApplicationUser() {Email = registerUser.Email, UserName = registerUser.UserName};

            var result = await _database.UserManager.CreateAsync(user, registerUser.Password);
            
            if (result.Succeeded)
            {
                await _database.SaveAsync();
                result = await _database.UserManager.AddToRoleAsync(user, "USER");
            }
            await _database.SaveAsync();
            return result;
        }

        public async Task<string> Login(LoginDto loginUser)
        {
            var user = await _database.UserManager.FindByEmailAsync(loginUser.Email);
            if (user != null && await _database.UserManager.CheckPasswordAsync(user, loginUser.Password))
            {
                return _jwtService.GenerateJwtToken(user.Id);
            }

            return String.Empty;
        }
    }
}