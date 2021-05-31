using System.Collections.Generic;
using System.Threading.Tasks;
using Task = TaskTrackingSystem.DAL.Entities.Task;

namespace TaskTrackingSystem.DAL.Repositories.Interfaces
{
    public interface ITaskRepository : IRepositoryBase<Task>
    {
        Task<IEnumerable<Task>> GetProjectTasksWithUsers(int id);
    }
}