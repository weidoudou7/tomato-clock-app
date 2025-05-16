using System.Collections.Generic;
using TomatoClockApp.Models;
using TomatoClockApp.Repository;
using TomatoClockApp.Services;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Controllers
{
    public class TaskController
    {
        private readonly TaskService _taskService;

        public TaskController(TaskRepository taskRepository)
        {
            _taskService = new TaskService(taskRepository);
        }

        public void AddTask(Task task)
        {
            _taskService.AddTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
        }

        public void UpdateTask(Task task)
        {
            _taskService.UpdateTask(task);
        }
        public Task GetTaskById(int id)
        {
            return _taskService.GetTaskById(id);
        }
        public List<Task> GetTasks()
        {
            return _taskService.GetTasks();
        }
    }
}