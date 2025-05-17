using SmartTasksAPI.DTOs;

namespace SmartTasksAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<TaskDto> CreateTaskAsync(TaskDto dto);
        Task<bool> UpdateTaskAsync(int id, TaskDto dto);
        Task<bool> DeleteTaskAsync(int id);
        Task<IEnumerable<TaskDto>> GetFilteredTasksAsync(string? priority, DateTime? dueDate,string? status);
    }
}
