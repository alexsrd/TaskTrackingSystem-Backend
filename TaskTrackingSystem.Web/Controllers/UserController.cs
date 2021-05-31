using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Update(UserDto user)
        {
            return Ok(await _userService.ChangeUserRole(user));
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet("{projectId:int}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetProjectUsers(int projectId)
        {
            return Ok(await _userService.GetProjectUsers(projectId));
        }
    }
}