using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Repositories.Interfaces;
using Task = TaskTrackingSystem.DAL.Entities.Task;

namespace TaskTrackingSystem.DAL.Repositories
{
    /// <summary>
    /// Repository for Task entity
    /// </summary>
    public class TaskRepository : RepositoryBase<Task>,ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all tasks including user entity, related to a project with a projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Task>> GetProjectTasksWithUsers(int projectId)
        {
            var tasksWithUsers = await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .Include(t => t.User).ToListAsync();
            return tasksWithUsers;
        }
        
    }
}