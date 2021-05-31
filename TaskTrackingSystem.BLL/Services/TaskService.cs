using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackingSystem.BLL.DTOs;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.DAL;
using Task = TaskTrackingSystem.DAL.Entities.Task;

namespace TaskTrackingSystem.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _database;
        private readonly Mapper _mapper;
        public TaskService(IUnitOfWork database)
        {
            _database = database;
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
            var createdTask =  await _database.Tasks.InsertAsync(taskTmp);
            return _mapper.Map<TaskDto>(createdTask);
        }
        
        
    }
}