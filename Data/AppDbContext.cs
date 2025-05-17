using Microsoft.EntityFrameworkCore;
using SmartTasksAPI.Models;

namespace SmartTasksAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}