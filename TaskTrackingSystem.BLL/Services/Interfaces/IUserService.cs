using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTOs;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserProfileDto>> GetUsersAsync();
        Task<UserProfileDto> ChangeUserRole(UserProfileDto user);
    }
}