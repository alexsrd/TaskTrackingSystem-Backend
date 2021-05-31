using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.DAL;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly Mapper _mapper;
        private readonly IUnitOfWork _database;

        public UserService(IUnitOfWork database)
        {
            _database = database;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, UserProfileDto>().ReverseMap();
            }));
        }
        public async Task<IEnumerable<UserProfileDto>> GetUsersAsync()
        {
            var users = await _database.Users.GetAllAsync();
            var userProfileDtos = new List<UserProfileDto>();
            foreach (var user in users)
            {
                var profile = _mapper.Map<UserProfileDto>(user);
                IList<string> roles = await _database.UserManager.GetRolesAsync(user);
                profile.Role = roles.FirstOrDefault();
                userProfileDtos.Add(profile);
            }
            return userProfileDtos;
        }
        

        public async Task<UserProfileDto> ChangeUserRole(UserProfileDto user)
        {
            var userFromClient = _mapper.Map<ApplicationUser>(user);
            var userFromDb = await _database.UserManager.FindByEmailAsync(user.Email);
            userFromDb.Role = userFromClient.Role;
            
            var userRoles = await _database.UserManager.GetRolesAsync(userFromDb);
            await _database.UserManager.RemoveFromRolesAsync(userFromDb, userRoles);
            await _database.UserManager.AddToRoleAsync(userFromDb,userFromClient.Role);
            var userDto =  await _database.Users.UpdateAsync(userFromDb);
            _database.Save();
            return _mapper.Map<UserProfileDto>(userDto);
        }
    }
}