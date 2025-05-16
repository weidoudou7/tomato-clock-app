using System.Linq;
using TomatoClockApp.Models;
using TomatoClockApp.Services;
using TomatoClockApp.Repository;

namespace TomatoClockApp.Controllers
{
    public class StatisticsController
    {
        private readonly TaskService _taskService;

        public StatisticsController(TaskRepository taskRepository)
        {
            _taskService = new TaskService(taskRepository);
        }

        public int GetTotalTasks()
        {
            return _taskService.GetTasks().Count;
        }

        public int GetCompletedTasks()
        {
            return _taskService.GetTasks().Count(t => t.IsCompleted);
        }
    }
}