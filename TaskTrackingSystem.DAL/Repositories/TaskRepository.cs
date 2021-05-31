using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Repositories.Interfaces;
using Task = TaskTrackingSystem.DAL.Entities.Task;

namespace TaskTrackingSystem.DAL.Repositories
{
    public class TaskRepository : RepositoryBase<Task>,ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetProjectTasksWithUsers(int id)
        {
            var tasksWithUsers = await _context.Tasks
                .Where(t => t.ProjectId == id)
                .Include(t => t.User).ToListAsync();
            return tasksWithUsers;
        }
    }
}