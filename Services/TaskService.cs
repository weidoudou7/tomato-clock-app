using System.Collections.Generic;
using System.Linq;
using TomatoClockApp.Models;
using TomatoClockApp.Repository;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;

        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(Task task)
        {
            _taskRepository.AddTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }

        public void UpdateTask(Task task)
        {
            _taskRepository.UpdateTask(task);
        }

        public List<Task> GetTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        internal Task GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }
    }
}