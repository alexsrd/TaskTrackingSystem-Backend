using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            try
            {
                return Ok(await _userService.GetUsersAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Update(UserDto user)
        {
            try
            {
                return Ok(await _userService.UpdateUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{projectId:int}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetProjectUsers(int projectId)
        {
            try
            {
                return Ok(await _userService.GetProjectUsers(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [HttpPut("addToProject/{projectId:int}")]
        public async Task<ActionResult<UserDto>> AddToProject(int projectId,UserDto user)
        {
            try
            {
                return Ok(await _userService.AddUserToProject(projectId, user.Email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<IdentityResult>> DeleteUser(string email)
        {
            try
            {
                return Ok(await _userService.DeleteUser(email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}