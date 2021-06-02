using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Repositories.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskTrackingSystem.DAL.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersWithProjects()
        {
            return await _context.Users
                .Include(u => u.Projects).ToListAsync();
        }
        
    }
}