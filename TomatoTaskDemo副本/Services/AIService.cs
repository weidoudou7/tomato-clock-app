using System.Collections.Generic;
using TomatoClockApp.Models;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Services
{
    public class AIService
    {
        public List<Task> PlanTasks(List<Task> tasks)
        {
            // 简单的AI任务规划逻辑：按截止时间排序
            tasks.Sort((a, b) => a.Deadline.CompareTo(b.Deadline));
            return tasks;
        }
    }
}