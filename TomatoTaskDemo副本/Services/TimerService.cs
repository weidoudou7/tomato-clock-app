using System;
using System.Timers;

namespace TomatoClockApp.Services
{
    public class TimerService
    {
        private System.Timers.Timer timer;
        private int remainingTime;

        public event Action TimerTick;
        public event Action TimerFinished;

        public TimerService(int duration)
        {
            remainingTime = duration;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimerTick;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            remainingTime--;
            TimerTick?.Invoke();

            if (remainingTime <= 0)
            {
                TimerFinished?.Invoke();
            }
        }
    }
}