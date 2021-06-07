using System;

namespace TaskTrackingSystem.DAL.Entities
{
    /// <summary>
    /// Entity of task
    /// </summary>
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Progress { get; set; }
        public ApplicationUser User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}