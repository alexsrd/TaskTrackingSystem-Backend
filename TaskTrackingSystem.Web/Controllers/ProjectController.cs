using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.Web.Controllers
{
    /// <summary>
    /// Controller for actions on Project entities
    /// </summary>
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
            try
            {
                string userId = User.Claims.First(c => c.Type == "UserID").Value;
                return Ok(await _projectService.CreateProject(userId,project));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetUserProjects()
        {
            try
            {
                string userId = User.Claims.First(c => c.Type == "UserID").Value;
                return Ok(await _projectService.GetUserProjects(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            try
            {
                return Ok(await _projectService.GetProject(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            try
            {
                return Ok(await _projectService.DeleteProject(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Manager,Admin")]
        [HttpDelete]
        [Route("deleteFromProject/{id:int}&{email}")]
        public async Task<ActionResult> DeleteUserFromProject(int id,string email)
        {
            try
            {
                return Ok(await _projectService.DeleteUserFromProject(id,email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}