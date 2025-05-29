using TomatoClockApp.Services;

namespace TomatoClockApp.Controllers
{
    public class TimerController
    {
        //private TimerService timerService;

        //public TimerController()
        //{
        //    timerService = new TimerService(25 * 60); // 25分钟
        //}

        //public void Start()
        //{
        //    timerService.Start();
        //}

        //public void Stop()
        //{
        //    timerService.Stop();
        //}
        private TimerService timerService;
        private int seconds;
        public TimerController(int initialSeconds = 0, TimerMode mode = TimerMode.CountUp)
        {
            seconds = initialSeconds;
            timerService = new TimerService(initialSeconds, mode); // 25分钟
        }

        public TimeSpan CurrentTime
        {
            get => timerService.CurrentTime;
        }

        public TimeSpan TotalCost
        {
            get => timerService.TotalCost;
        }

        public void Start()
        {
            timerService.Start();
        }

        public void Pause()
        {
            timerService.Pause();
        }

        public void Stop()
        {
            timerService.Pause();
        }
        public void Reset(int seconds, TimerMode? mode = null)
        {
            timerService.Reset(seconds, mode);
        }
    }
}