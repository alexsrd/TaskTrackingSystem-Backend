using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.BLL.Services.SmtpService;
using TaskTrackingSystem.DAL;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _database;
        private readonly Mapper _mapper;
        private readonly IEmailService _emailService;
        public ProjectService(IUnitOfWork database,IEmailService emailService)
        {
            _database = database;
            _emailService = emailService;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDto, Project>().ReverseMap();
            }));
        }
        
        public async Task<ProjectDto> CreateProject(string currentUserId,ProjectDto project)
        {
            var users = new List<ApplicationUser>();
            foreach (var user in project.Users)
            {
                var userTmp = await _database.UserManager.FindByEmailAsync(user.Email);
                if (userTmp != null)
                {
                    var mailInfo = new EmailInfo
                    {
                        EmailTo = userTmp.Email,
                        Subject = "Task Management System",
                        Body = $"Access to project \"{project.Name}\" was granted to you."
                    };
                    await _emailService.SendEmailAsync(mailInfo);
                }
            }
            users.Add(await _database.UserManager.FindByIdAsync(currentUserId));

            var proj = _mapper.Map<Project>(project);
            proj.CreatedAt = DateTime.Now;

            proj.Users = new List<ApplicationUser>();
            proj.Users.AddRange(users);
            
            await _database.Projects.InsertAsync(proj);
            _database.Save();
            
            return project;
        }

        public async Task<IEnumerable<ProjectDto>> GetUserProjects(string id)
        {
            var projects = await _database.Projects.GetAllProjectsByUserId(id);
            var projectDtos = new List<ProjectDto>();
            foreach (var project in projects)
            {
                projectDtos.Add(_mapper.Map<ProjectDto>(project));
            }
            return projectDtos;
        }

        public async Task<ProjectDto> GetProject(int id)
        {
            var project = await _database.Projects.GetFirstWhereAsync(p => p.Id == id);
            var projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public async void DeleteProject(int projectId)
        {
            var projectDto = await _database.Projects.GetFirstWhereAsync(p => p.Id == projectId);
            _database.Projects.Delete(_mapper.Map<Project>(projectDto));
        }

        public async void DeleteUserFromProject(int projectId,ApplicationUser user)
        {
            var projectDto = await _database.Projects.GetFirstWhereAsync(p => p.Id == projectId);
            var project = _mapper.Map<Project>(projectDto);
            var appUser = await _database.UserManager.FindByEmailAsync(user.Email);
            project.Users.Remove(appUser);
            await _database.Projects.UpdateAsync(project);
        }
        
    }
}