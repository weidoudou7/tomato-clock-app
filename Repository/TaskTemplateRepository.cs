using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TomatoClockApp.Data;
using TomatoClockApp.Models;

namespace TomatoClockApp.Repository
{
    public class TaskTemplateRepository
    {
        private readonly AppDbContext _context;

        public TaskTemplateRepository(AppDbContext context)
        {
            _context = context;
        }

        public TaskTemplate GetById(int id)
        {
            return _context.TaskTemplates
                .Include(t => t.CreatedBy)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<TaskTemplate> GetAllPublic()
        {
            return _context.TaskTemplates
                .Include(t => t.CreatedBy)
                .Where(t => t.IsPublic)
                .OrderByDescending(t => t.Downloads)
                .ToList();
        }

        public List<TaskTemplate> GetUserTemplates(int userId)
        {
            return _context.TaskTemplates
                .Include(t => t.CreatedBy)
                .Where(t => t.CreatedByUserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }

        public void Add(TaskTemplate template)
        {
            template.CreatedAt = DateTime.Now;
            _context.TaskTemplates.Add(template);
            _context.SaveChanges();
        }

        public void Update(TaskTemplate template)
        {
            _context.TaskTemplates.Update(template);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var template = _context.TaskTemplates.Find(id);
            if (template != null)
            {
                _context.TaskTemplates.Remove(template);
                _context.SaveChanges();
            }
        }

        public void IncrementDownloads(int id)
        {
            var template = _context.TaskTemplates.Find(id);
            if (template != null)
            {
                template.Downloads++;
                _context.SaveChanges();
            }
        }

        public void ToggleLike(int id)
        {
            var template = _context.TaskTemplates.Find(id);
            if (template != null)
            {
                template.Likes++;
                _context.SaveChanges();
            }
        }
    }
} 