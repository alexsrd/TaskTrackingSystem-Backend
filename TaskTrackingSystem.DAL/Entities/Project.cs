using System;
using System.Collections.Generic;

namespace TaskTrackingSystem.DAL.Entities
{
    /// <summary>
    /// Entity for project
    /// Project - a set of tasks
    /// </summary>
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Task> Tasks { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}