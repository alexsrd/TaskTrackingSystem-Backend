using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.Web.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpGet("{projectId:int}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetProjectTasks(int projectId)
        {
            return Ok(await _taskService.GetProjectTasksWithUsers(projectId));
        }

        [HttpPost("{projectId:int}")]
        public async Task<ActionResult<TaskDto>> PostTask(int projectId,[FromBody]TaskDto task)
        {
            return Ok(await _taskService.CreateTask(projectId, task));
        }
    }
}