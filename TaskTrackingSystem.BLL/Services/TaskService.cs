using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.BLL.Services.SmtpService;
using TaskTrackingSystem.DAL;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Repositories.Interfaces;
using Task = TaskTrackingSystem.DAL.Entities.Task;

namespace TaskTrackingSystem.BLL.Services
{
    /// <summary>
    /// Service for actions with Task entities
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly Mapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _database;
        public TaskService(IUnitOfWork database,IEmailService emailService,UserManager<ApplicationUser> userManager)
        {
            _database = database;
            _userManager = userManager;
            _emailService = emailService;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDto, Task>().ReverseMap();
            }));
        }
        
        public async Task<IEnumerable<TaskDto>> GetProjectTasksWithUsers(int id)
        {
            var tasks = await _database.Tasks.GetProjectTasksWithUsers(id);
            var tasksDto = new List<TaskDto>();
            foreach (var task in tasks)
            {
                tasksDto.Add(_mapper.Map<TaskDto>(task));
            }
            return tasksDto;
        }

        public async Task<TaskDto> CreateTask(int projectId,TaskDto task)
        {
            var taskTmp = _mapper.Map<Task>(task);
            taskTmp.ProjectId = projectId;
            taskTmp.Progress = "Not Assigned";
            if (task.User.Email != null)
            {
                var user = await _userManager.FindByEmailAsync(task.User.Email);
                taskTmp.User = user;
                if (user != null)
                {
                    taskTmp.Progress = "Assigned";
                    var mailInfo = new EmailInfo
                    {
                        EmailTo = user.Email,
                        Subject = "Task Management System",
                        Body = $"Task with name \"{task.Name}\" was assigned to you."
                    };
                    await _emailService.SendEmailAsync(mailInfo);
                }
            }
            
            var createdTask =  await _database.Tasks.InsertAsync(taskTmp);

            return _mapper.Map<TaskDto>(createdTask);
        }

        public async Task<IEnumerable<TaskDto>> GetUserTasksOnProject(string userId, int projectId)
        {
            var tasks = await _database.Tasks.GetProjectTasksWithUsers(projectId);
            var userTasks = tasks.Where(t => t.UserId == userId);
            var userTasksDto = new List<TaskDto>();
            foreach (var task in userTasks)
            {
                userTasksDto.Add(_mapper.Map<TaskDto>(task));
            }
            return userTasksDto;
        }

        public async Task<TaskDto> UpdateTask(TaskDto taskDto)
        {
            var task = await _database.Tasks
                .GetFirstWhereAsync(t => t.Id == taskDto.Id);
            task = _mapper.Map(taskDto,task);
            if (taskDto.User != null)
            {
                var user = await _userManager.FindByEmailAsync(taskDto.User.Email);
                task.User = user;
                if (user != null)
                {
                    var mailInfo = new EmailInfo
                    {
                        EmailTo = user.Email,
                        Subject = "Task Management System",
                        Body = $"Task with name \"{task.Name}\" was assigned to you."
                    };
                    await _emailService.SendEmailAsync(mailInfo);
                }
            }
            var updatedTask = await _database.Tasks.UpdateAsync(task);
            return _mapper.Map<TaskDto>(updatedTask);
        }
        
        public async Task<TaskDto> DeleteTask(int id)
        {
            var task = await _database.Tasks.GetFirstWhereAsync(t => t.Id == id);
            _database.Tasks.Delete(task);
            
            return _mapper.Map<TaskDto>(task);
        }
        
    }
}