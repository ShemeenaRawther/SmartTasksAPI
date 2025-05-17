using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTasksAPI.Data;
using SmartTasksAPI.DTOs;
using SmartTasksAPI.Models;

namespace SmartTasksAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskDto> CreateTaskAsync(TaskDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null) return false;

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            return task == null ? null : _mapper.Map<TaskDto>(task);
        }

        public async Task<IEnumerable<TaskDto>> GetFilteredTasksAsync(
        string? priority,
        DateTime? dueDate,
        string? status)
        {
            var query = _dbContext.Tasks.AsQueryable();
            if (!string.IsNullOrEmpty(priority))
                query = query.Where(t => t.Priority.ToString() == priority);

            if (dueDate.HasValue)
                query = query.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == dueDate.Value.Date);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(t => t.Status.ToString() == status);

            var tasks = await query.ToListAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }


        public async Task<bool> UpdateTaskAsync(int id, TaskDto dto)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null) return false;

            _mapper.Map(dto, task);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
