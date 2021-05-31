using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.DAL;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _database;
        private readonly Mapper _mapper;
        public ProjectService(IUnitOfWork database)
        {
            _database = database;
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
                if(userTmp != null) users.Add(userTmp);
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
    }
}