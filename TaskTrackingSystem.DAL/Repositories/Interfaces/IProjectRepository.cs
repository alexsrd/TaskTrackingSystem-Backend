using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.Repositories.Interfaces
{
    public interface IProjectRepository : IRepositoryBase<Project>
    {
        Task<IList<Project>> GetAllProjectsByUserId(string id);
        Task<Project> GetProjectWithUsers(int projectId);
    }
}