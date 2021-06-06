using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    /// <summary>
    /// Interface for ProjectService
    /// </summary>
    public interface IProjectService
    {
        Task<ProjectDto> CreateProject(string currentUserId,ProjectDto project);
        Task<IEnumerable<ProjectDto>> GetUserProjects(string id);
        Task<ProjectDto> GetProject(int id);
        Task<ProjectDto> DeleteProject(int projectId);
        Task<ProjectDto> DeleteUserFromProject(int projectId, string email);
    }
}