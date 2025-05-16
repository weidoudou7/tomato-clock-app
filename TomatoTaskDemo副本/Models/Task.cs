using System;

namespace TomatoClockApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public string? Category { get; set; }
    }
}