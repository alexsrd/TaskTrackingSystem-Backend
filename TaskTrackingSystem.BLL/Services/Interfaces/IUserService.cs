using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTOs;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> UpdateUser(UserDto user);

        Task<IEnumerable<UserDto>> GetProjectUsers(int projectId);
        Task<UserDto> AddUserToProject(int projectId, string email);
        
    }
}