using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TomatoClockApp.Data;
using TomatoClockApp.Models;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Repository
{
    public class TaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Task> GetTasksByUserId(int userId)
        {
            return _context.Tasks
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public Task GetTaskById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public List<Task> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public List<Task> GetTaskByDate(DateTime date)
        {
            return _context.Tasks
                .Where(t => t.Deadline.Date == date.Date)
                .ToList();
        }

        public void UpdateTask(Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}