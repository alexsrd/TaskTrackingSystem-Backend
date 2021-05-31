using System.Collections.Generic;
using TaskTrackingSystem.DAL.Entities;
namespace TaskTrackingSystem.BLL.DTOs
{
    public class UserProfileDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Project> Projects { get; set; }
    }
}