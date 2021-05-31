using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.Web.Controllers
{
    [ApiController]
    
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostProject(ProjectDto project)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            return Ok(await _projectService.CreateProject(userId,project));
        }

        [Authorize(Roles = "User,Manager,Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetUserProjects()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            return Ok(await _projectService.GetUserProjects(userId));
        }
    }
}