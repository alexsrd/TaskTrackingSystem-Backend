using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.BLL.Services.SmtpService;
using TaskTrackingSystem.DAL;
using Task = TaskTrackingSystem.DAL.Entities.Task;

namespace TaskTrackingSystem.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _database;
        private readonly Mapper _mapper;
        private readonly IEmailService _emailService;
        public TaskService(IUnitOfWork database,IEmailService emailService)
        {
            _database = database;
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
            var user = await _database.UserManager.FindByEmailAsync(task.User.Email);
            var taskTmp = _mapper.Map<Task>(task);
            taskTmp.ProjectId = projectId;
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
            var createdTask =  await _database.Tasks.InsertAsync(taskTmp);
            _database.Save();

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
            var task = await _database.Tasks.GetFirstWhereAsync(t => t.Id == taskDto.Id);
            task = _mapper.Map(taskDto,task);
            var updatedTask = await _database.Tasks.UpdateAsync(task);
            _database.Save();
            return _mapper.Map<TaskDto>(updatedTask);
        }
        
    }
}