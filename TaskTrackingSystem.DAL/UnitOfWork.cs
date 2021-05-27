using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UserManager<ApplicationUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }

        public UnitOfWork(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}