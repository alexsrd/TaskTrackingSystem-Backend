using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.BLL.DTOs;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    /// <summary>
    /// Interface for UserService
    /// </summary>
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> UpdateUser(UserDto user);
        Task<IEnumerable<UserDto>> GetProjectUsers(int projectId);
        Task<UserDto> AddUserToProject(int projectId, string email);
        Task<IdentityResult> DeleteUser(string email);
    }
}