using System.Linq;
using TomatoClockApp.Repository;

namespace TomatoClockApp.Services
{
    public class StatisticsService
    {
        private readonly TaskRepository _taskRepository;

        public StatisticsService(TaskRepository taskRepository)
        {
            _taskRepository= taskRepository;
        }

        public int GetTotalTasks()
        {
            return _taskRepository.GetAllTasks().Count;
        }

        public int GetCompletedTasks()
        {
            return _taskRepository.GetAllTasks().Count(t => t.IsCompleted);
        }
    }
}