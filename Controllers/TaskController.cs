using System;
using System.Collections.Generic;
using System.Linq;
using TomatoClockApp.Models;
using TomatoClockApp.Repository;
using TomatoClockApp.Services;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Controllers
{
    public class TaskController
    {
        private readonly TaskRepository _taskRepository;
        private readonly TaskService _taskService;

        public TaskController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _taskService = new TaskService(taskRepository);
        }

        public List<Task> GetTasks()
        {
            return _taskRepository.GetTasksByUserId(CurrentUser.UserId);
        }

        public Task GetTaskById(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task != null && task.UserId != CurrentUser.UserId)
            {
                return null;
            }
            return task;
        }

        public void AddTask(Task task)
        {
            task.UserId = CurrentUser.UserId;
            _taskRepository.AddTask(task);
        }

        public void UpdateTask(Task task)
        {
            if (task.UserId != CurrentUser.UserId)
            {
                throw new UnauthorizedAccessException("您没有权限修改此任务");
            }
            _taskRepository.UpdateTask(task);
        }

        public void DeleteTask(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task != null && task.UserId != CurrentUser.UserId)
            {
                throw new UnauthorizedAccessException("您没有权限删除此任务");
            }
            _taskRepository.DeleteTask(id);
        }
    }
}