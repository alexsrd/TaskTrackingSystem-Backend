using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTOs;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetProjectTasksWithUsers(int id);
        Task<TaskDto> CreateTask(int projectId, TaskDto task);
    }
}