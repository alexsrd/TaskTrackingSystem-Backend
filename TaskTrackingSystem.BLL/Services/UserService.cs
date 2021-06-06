using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.BLL.Services.SmtpService;
using TaskTrackingSystem.DAL;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.Services
{
    /// <summary>
    /// Service for actions with User entities
    /// </summary>
    public class UserService : IUserService
    {
        private readonly Mapper _mapper;
        private readonly IUnitOfWork _database;
        private readonly IEmailService _emailService;

        public UserService(IUnitOfWork database,IEmailService emailService)
        {
            _database = database;
            _emailService = emailService;
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
        
        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var user = await _database.UserManager.FindByEmailAsync(userDto.Email);
            user = _mapper.Map(userDto, user);

            var userRoles = await _database.UserManager.GetRolesAsync(user);
            await _database.UserManager.RemoveFromRolesAsync(user, userRoles);
            await _database.UserManager.AddToRoleAsync(user,userDto.Role);
            var updatedUser =  await _database.Users.UpdateAsync(user);
            
            var mailInfo = new EmailInfo
            {
                EmailTo = user.Email,
                Subject = "Task Management System",
                Body = $"Your role was changed from \"{userRoles.FirstOrDefault()}\" to \"{userDto.Role}\""
            };
            await _emailService.SendEmailAsync(mailInfo);
            
            return _mapper.Map<UserDto>(updatedUser);
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

                var mailInfo = new EmailInfo
                {
                    EmailTo = email,
                    Subject = "Task Management System",
                    Body = $"Access to project \"{project.Name}\" was granted to you."
                };
                await _emailService.SendEmailAsync(mailInfo);
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IdentityResult> DeleteUser(string email)
        {
            var user = await _database.UserManager.FindByEmailAsync(email);
            await _database.UserManager.DeleteAsync(user);
            _database.Save();
            return IdentityResult.Success;
        }
    }
}