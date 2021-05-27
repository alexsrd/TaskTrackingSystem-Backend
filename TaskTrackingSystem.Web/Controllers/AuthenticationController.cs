using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.DAL;

namespace TaskTrackingSystem.Web.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromQuery]RegisterDto registerUser)
        {
            try
            {
                var result = await _authenticationService.Register(registerUser);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Registered failed: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<string>> Login([FromQuery]LoginDto loginUser)
        {
            var resultToken = await _authenticationService.Login(loginUser);
            if (resultToken != String.Empty)
            {
                return Ok(new {resultToken});
            }
            return BadRequest("Email or password is incorrect");
        }
    }
}