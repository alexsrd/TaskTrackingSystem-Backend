using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Repositories.Interfaces;

namespace TaskTrackingSystem.DAL.Repositories
{
    /// <summary>
    /// Project repository, inherited from RepositoryBase
    /// </summary>
    public class ProjectRepository : RepositoryBase<Project>,IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        
        /// <summary>
        /// Constructor with injection of ApplicationDbContext
        /// </summary>
        /// <param name="context">Injected ApplicationDbContext object</param>
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

        /// <summary>
        /// Get project by id with included ApplicationUser object
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>Project entity object</returns>
        public async Task<Project> GetProjectWithUsers(int projectId)
        {
            return await _context.Projects.Include(p => p.Users).FirstOrDefaultAsync(p => p.Id == projectId);
        }
    }
}