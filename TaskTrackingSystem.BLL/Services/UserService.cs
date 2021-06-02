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
                cfg.CreateMap<ApplicationUser, UserDto>().ReverseMap();
            }));
        }
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _database.Users.GetAllAsync();
            var userProfileDtos = new List<UserDto>();
            foreach (var user in users)
            {
                var profile = _mapper.Map<UserDto>(user);
                IList<string> roles = await _database.UserManager.GetRolesAsync(user);
                profile.Role = roles.FirstOrDefault();
                userProfileDtos.Add(profile);
            }
            return userProfileDtos;
        }
        

        public async Task<UserDto> ChangeUserRole(UserDto user)
        {
            var userFromClient = _mapper.Map<ApplicationUser>(user);
            var userFromDb = await _database.UserManager.FindByEmailAsync(user.Email);
            userFromDb.Role = userFromClient.Role;
            
            var userRoles = await _database.UserManager.GetRolesAsync(userFromDb);
            await _database.UserManager.RemoveFromRolesAsync(userFromDb, userRoles);
            await _database.UserManager.AddToRoleAsync(userFromDb,userFromClient.Role);
            var userDto =  await _database.Users.UpdateAsync(userFromDb);
            _database.Save();
            return _mapper.Map<UserDto>(userDto);
        }

        public async Task<IEnumerable<UserDto>> GetProjectUsers(int projectId)
        {
            var users = await _database.Users.GetUsersWithProjects();
            var projectUsers = users
                .Where(u => u.Projects.Exists(p => p.Id == projectId));
            var userDtos = new List<UserDto>();
            foreach (var user in projectUsers)
            {
                userDtos.Add(_mapper.Map<UserDto>(user));
            }

            return userDtos;
        }

        public async Task<UserDto> AddUserToProject(int projectId,string email)
        {
            var user = await _database.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                var project = await _database.Projects.GetProjectWithUsers(projectId);
                project.Users.Add(user);
                await _database.Projects.UpdateAsync(project);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}