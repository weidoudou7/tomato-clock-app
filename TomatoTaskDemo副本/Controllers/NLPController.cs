using TomatoClockApp.Models;
using TomatoClockApp.Services;

namespace TomatoClockApp.Controllers
{
    public class NLPController
    {
        private NLPService nlpService;

        public NLPController()
        {
            nlpService = new NLPService();
        }

        public Models.Task ParseTask(string input)
        {
            return nlpService.ParseTask(input);
        }
    }
}