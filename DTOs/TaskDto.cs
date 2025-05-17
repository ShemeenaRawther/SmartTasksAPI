using SmartTasksAPI.Models;

namespace SmartTasksAPI.DTOs
{
    public class TaskDto
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public Models.TaskStatus Status { get; set; }
        public int? AssignedUserId { get; set; }
        public string AssignedUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
