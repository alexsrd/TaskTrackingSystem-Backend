using System.Collections.Generic;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(ApplicationUser user,IList<string> roles);
    }
}