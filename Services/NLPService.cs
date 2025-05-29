using System;
using System.Text.RegularExpressions;
using TomatoClockApp.Models;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Services
{
    public class NLPService
    {
        public Task ParseTask(string input)
        {
            var task = new Task();

            // 提取任务名称
            var nameMatch = Regex.Match(input, @"(?<=task\s)(.*?)(?=\s+at\s|$)");
            if (nameMatch.Success)
            {
                task.Name = nameMatch.Value.Trim();
            }

            // 提取任务时间
            var timeMatch = Regex.Match(input, @"\b\d{1,2}:\d{2}\b");
            if (timeMatch.Success)
            {
                var time = DateTime.ParseExact(timeMatch.Value, "HH:mm", null);
                task.Deadline = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, time.Hour, time.Minute, 0);
            }

            return task;
        }
    }
}