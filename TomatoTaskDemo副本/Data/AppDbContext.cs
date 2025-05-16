using Microsoft.EntityFrameworkCore;
using System.IO;
using TomatoClockApp.Models;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(Application.StartupPath, "app.db");
            Console.WriteLine($"数据库路径：{path}");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }
    }
}