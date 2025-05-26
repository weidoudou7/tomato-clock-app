using System;
using System.Collections.Generic;
using TomatoClockApp.Models;
using TomatoClockApp.Repository;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Controllers
{
    public class TaskTemplateController
    {
        private readonly TaskTemplateRepository _templateRepository;
        private readonly TaskRepository _taskRepository;

        public TaskTemplateController(TaskTemplateRepository templateRepository, TaskRepository taskRepository)
        {
            _templateRepository = templateRepository;
            _taskRepository = taskRepository;
        }

        public List<TaskTemplate> GetAllPublicTemplates()
        {
            return _templateRepository.GetAllPublic();
        }

        public List<TaskTemplate> GetUserTemplates(int userId)
        {
            return _templateRepository.GetUserTemplates(userId);
        }

        public TaskTemplate GetTemplateById(int id)
        {
            return _templateRepository.GetById(id);
        }

        public void CreateTemplate(TaskTemplate template)
        {
            if (string.IsNullOrWhiteSpace(template.Title))
                throw new ArgumentException("模板标题不能为空");

            _templateRepository.Add(template);
        }

        public void UpdateTemplate(TaskTemplate template)
        {
            if (string.IsNullOrWhiteSpace(template.Title))
                throw new ArgumentException("模板标题不能为空");

            _templateRepository.Update(template);
        }

        public void DeleteTemplate(int id)
        {
            _templateRepository.Delete(id);
        }

        public void DownloadTemplate(int templateId, int userId)
        {
            var template = _templateRepository.GetById(templateId);
            if (template == null)
                throw new ArgumentException("模板不存在");

            // 创建新任务
            var task = new Task
            {
                Name = template.Title,
                Category = template.Category,
                Deadline = DateTime.Now.AddDays(7), // 默认一周后截止
                IsCompleted = false,
                UserId = userId  // 设置用户ID
            };

            _taskRepository.AddTask(task);
            _templateRepository.IncrementDownloads(templateId);
        }

        public void LikeTemplate(int id)
        {
            _templateRepository.ToggleLike(id);
        }
    }
} 