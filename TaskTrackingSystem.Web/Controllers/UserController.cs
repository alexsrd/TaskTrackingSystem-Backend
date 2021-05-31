using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable<UserProfileDto>> Get()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpPut]
        public async Task<ActionResult<UserProfileDto>> Update(UserProfileDto user)
        {
            return Ok(await _userService.ChangeUserRole(user));
        }
    }
}