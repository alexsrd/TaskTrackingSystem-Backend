using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTOs;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateProject(string currentUserId,ProjectDto project);
        Task<IEnumerable<ProjectDto>> GetUserProjects(string id);
        Task<ProjectDto> GetProject(int id);
    }
}