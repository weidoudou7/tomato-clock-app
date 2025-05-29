using System.Collections.Generic;
using TomatoClockApp.Models;
using TomatoClockApp.Services;

namespace TomatoClockApp.Controllers
{
    public class AIController
    {
        private AIService aiService;

        public AIController()
        {
            aiService = new AIService();
        }

        public List<Models.Task> PlanTasks(List<Models.Task> tasks)
        {
            return aiService.PlanTasks(tasks);
        }
    }
}