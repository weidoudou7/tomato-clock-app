

using System.Linq;
using TomatoClockApp.Models;
using TomatoClockApp.Services;
using TomatoClockApp.Repository;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Controllers
{
    public class StatisticsController
    {
        private readonly TaskService _taskService;

        public StatisticsController(TaskRepository taskRepository)
        {
            _taskService = new TaskService(taskRepository);
        }

        public int[] GetWeeklyTotalTasks(int currentWeekOffset)
        {
            List<Task> tasks = _taskService.GetTasks();
            int[] weeklyData = new int[7]; // 假设一周有7天

            // 获取当前日期
            DateTime currentDate = DateTime.Now;

            // 计算当前周的起始日期（周日）和结束日期（周六）
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek); // 当前周的周日
            DateTime endOfWeek = startOfWeek.AddDays(6); // 当前周的周六

            // 根据 currentWeekOffset 调整日期范围
            startOfWeek = startOfWeek.AddDays(currentWeekOffset * 7);
            endOfWeek = endOfWeek.AddDays(currentWeekOffset * 7);

            foreach (var task in tasks)
            {


                // 检查任务完成日期是否在当前周的范围内
                if (task.Deadline >= startOfWeek && task.Deadline <= endOfWeek)
                {
                    // 计算任务的完成日期所在的星期几
                    int dayOfWeek = (int)task.Deadline.DayOfWeek; // 0 = 周日，1 = 周一，...，6 = 周六
                    if (dayOfWeek == 0) dayOfWeek = 7; // 将周日调整为7
                    dayOfWeek--; // 调整为从0开始的索引

                    // 增加该任务对应星期的完成数
                    weeklyData[dayOfWeek]++;
                }


            }

            return weeklyData;
        }

        public int GetCompletedTasks()
        {
            return _taskService.GetTasks().Count(t => t.IsCompleted);
        }
        public int[] GetWeeklyTaskCompletion(int currentWeekOffset)
        {
            List<Task> tasks = _taskService.GetTasks();
            int[] weeklyCompletionData = new int[7]; // 假设一周有7天

            // 获取当前日期
            DateTime currentDate = DateTime.Now;

            // 计算当前周的起始日期（周日）和结束日期（周六）
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek); // 当前周的周日
            DateTime endOfWeek = startOfWeek.AddDays(6); // 当前周的周六

            // 根据 currentWeekOffset 调整日期范围
            startOfWeek = startOfWeek.AddDays(currentWeekOffset * 7);
            endOfWeek = endOfWeek.AddDays(currentWeekOffset * 7);

            foreach (var task in tasks)
            {
                if (task.IsCompleted)
                {
                    // 检查任务完成日期是否在当前周的范围内
                    if (task.Deadline >= startOfWeek && task.Deadline <= endOfWeek)
                    {
                        // 计算任务的完成日期所在的星期几
                        int dayOfWeek = (int)task.Deadline.DayOfWeek; // 0 = 周日，1 = 周一，...，6 = 周六
                        if (dayOfWeek == 0) dayOfWeek = 7; // 将周日调整为7
                        dayOfWeek--; // 调整为从0开始的索引

                        // 增加该任务对应星期的完成数
                        weeklyCompletionData[dayOfWeek]++;
                    }
                }
            }

            return weeklyCompletionData;

        }
    }
}