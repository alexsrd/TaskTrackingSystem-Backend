using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {
        Task<IEnumerable<ApplicationUser>> GetUsersWithProjects();
    }
}