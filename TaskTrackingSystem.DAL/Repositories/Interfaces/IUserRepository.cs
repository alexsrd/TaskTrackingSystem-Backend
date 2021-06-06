using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface for user repository
    /// </summary>
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {
        Task<IEnumerable<ApplicationUser>> GetUsersWithProjects();
    }
}