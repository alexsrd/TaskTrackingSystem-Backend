using System.Collections.Generic;
using TaskTrackingSystem.DAL.Entities;
namespace TaskTrackingSystem.BLL.DTOs
{
    /// <summary>
    /// User data transfer object
    /// </summary>
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Project> Projects { get; set; }
    }
}