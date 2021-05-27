using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL
{
    public interface IUnitOfWork
    {
        public UserManager<ApplicationUser> UserManager { get;}
        public RoleManager<IdentityRole> RoleManager { get;}
        Task SaveAsync();
    }
}