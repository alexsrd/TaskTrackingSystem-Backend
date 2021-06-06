
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TaskTrackingSystem.DAL.Entities
{
    /// <summary>
    /// Entity for user
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Project> Projects { get; set; }

    }
}