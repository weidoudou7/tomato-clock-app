using System.Collections.Generic;
using TomatoClockApp.Models;
using TomatoClockApp.Repository;
using TomatoClockApp.Services;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Controllers
{
    public class CalendarController
    {
        private readonly TaskService _taskService;

        public CalendarController(TaskRepository taskRepository)
        {
            _taskService = new TaskService(taskRepository);
        }

        public List<Task> GetTasks()
        {
            return _taskService.GetTasks();
        }
    }
}