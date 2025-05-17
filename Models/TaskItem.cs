using System.ComponentModel.DataAnnotations;

namespace SmartTasksAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public int? AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }
}
