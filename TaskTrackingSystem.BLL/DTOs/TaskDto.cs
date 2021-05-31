using System;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Progress { get; set; }
        public ApplicationUser User { get; set; }
    }
}