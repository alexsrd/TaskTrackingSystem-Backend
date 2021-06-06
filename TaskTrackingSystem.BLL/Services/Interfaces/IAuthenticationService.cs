using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.BLL.DTOs;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    /// <summary>
    /// Interface for AuthenticationService
    /// </summary>
    public interface IAuthenticationService
    {
        Task<IdentityResult> Register(RegisterDto registerUser);
        Task<string> Login(LoginDto loginUser);
    }
}