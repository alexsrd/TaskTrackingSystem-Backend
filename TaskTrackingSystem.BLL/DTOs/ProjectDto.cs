using System;
using System.Collections.Generic;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.DTOs
{
    /// <summary>
    /// Project data transfer object
    /// </summary>
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<ApplicationUser> Users { get; set; }
    }
}