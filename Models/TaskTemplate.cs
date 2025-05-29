using System;

namespace TomatoClockApp.Models
{
    public class TaskTemplate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int EstimatedPomodoros { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserId { get; set; }
        public int Downloads { get; set; }
        public int Likes { get; set; }
        public bool IsPublic { get; set; }
        
        // 导航属性
        public User CreatedBy { get; set; }
    }
} 