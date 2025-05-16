using System.Collections.Generic;
using System.Linq;
using TomatoClockApp.Models;
using TomatoClockApp.Repository;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Services
{
    public class CalendarService
    {
        private readonly TaskRepository _taskRepository ;

        public CalendarService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<Task> GetTasks()
        {
            return _taskRepository.GetAllTasks();
        }
    }
}