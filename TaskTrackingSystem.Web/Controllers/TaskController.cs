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
    /// Controller for actions on Task entities
    /// </summary>
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [Authorize]
        [HttpGet("{projectId:int}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetProjectTasks(int projectId)
        {
            return Ok(await _taskService.GetProjectTasksWithUsers(projectId));
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost("{projectId:int}")]
        public async Task<ActionResult<TaskDto>> PostTask(int projectId,[FromBody]TaskDto task)
        {
            try
            {
                return Ok(await _taskService.CreateTask(projectId, task));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("user-tasks/{projectId:int}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetUserTasks(int projectId)
        {
            try
            {
                var userId = User.Claims.First(c => c.Type == "UserID").Value;
                return Ok(await _taskService.GetUserTasksOnProject(userId, projectId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<TaskDto>> UpdateTask(TaskDto task)
        {
            try
            {
                return Ok(await _taskService.UpdateTask(task));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                return Ok(await _taskService.DeleteTask(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}