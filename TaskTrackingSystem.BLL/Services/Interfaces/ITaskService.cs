using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTOs;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    /// <summary>
    /// Interface for TaskService
    /// </summary>
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetProjectTasksWithUsers(int projectId);
        Task<TaskDto> CreateTask(int projectId, TaskDto task);
        Task<IEnumerable<TaskDto>> GetUserTasksOnProject(string userId, int projectId);
        Task<TaskDto> UpdateTask(TaskDto task);
        Task<TaskDto> DeleteTask(int id);
    }
}