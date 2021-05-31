using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Repositories.Interfaces;

namespace TaskTrackingSystem.DAL.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>,IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<IList<Project>> GetAllProjectsByUserId(string id)
        {
            var projectsWithUsers = await _context.Projects.Include(p => p.Users).ToListAsync();
            var userProjects = projectsWithUsers.Where(p => p.Users.Exists(u => u.Id == id));
            return userProjects.ToList();
        }
    }
}