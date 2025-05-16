using TomatoClockApp.Services;

namespace TomatoClockApp.Controllers
{
    public class TimerController
    {
        private TimerService timerService;

        public TimerController()
        {
            timerService = new TimerService(25 * 60); // 25分钟
        }

        public void Start()
        {
            timerService.Start();
        }

        public void Stop()
        {
            timerService.Stop();
        }
    }
}