using System;
using System.Timers;

namespace TomatoClockApp.Services
{
    //    public class TimerService
    //    {
    //        private System.Timers.Timer timer;
    //        private int remainingTime;

    //        public event Action TimerTick;
    //        public event Action TimerFinished;

    //        public TimerService(int duration)
    //        {
    //            remainingTime = duration;
    //            timer = new System.Timers.Timer(1000);
    //            timer.Elapsed += OnTimerTick;
    //        }

    //        public void Start()
    //        {
    //            timer.Start();
    //        }

    //        public void Stop()
    //        {
    //            timer.Stop();
    //        }

    //        private void OnTimerTick(object sender, ElapsedEventArgs e)
    //        {
    //            remainingTime--;
    //            TimerTick?.Invoke();

    //            if (remainingTime <= 0)
    //            {
    //                TimerFinished?.Invoke();
    //            }
    //        }
    //    }
    public enum TimerMode
    {
        //倒计时模式
        CountDown,

        //正计时模式
        CountUp
    }


    public class TimerService
    {
        //计时器，时间间隔1秒
        private System.Timers.Timer timer;
        //当前计时模式
        private TimerMode currentMode;
        //基准时间：-倒计时模式：初始剩余时间  -正计时模式：初始累计时间
        private double baseSeconds;
        //最近一次启动计时的时间戳
        private DateTime startTime;

        private TimeSpan currentTime;
        private TimeSpan totalCost;

        //计时模式变更事件
        public event Action<TimerMode> ModeChanged;

        //计时完成事件（倒计时模式专用：计时归零时触发）
        public event Action TimerCompleted;

        //public event Action TimerTick;
        //public event Action TimerFinished;

        //当前计时模式（设置时会触发ModeChanged事件）
        public TimerMode CurrentMode
        {
            get => currentMode;
            set
            {
                if (currentMode != value)
                {
                    currentMode = value;
                    ModeChanged?.Invoke(value);
                }
            }
        }

        //获取当前时间戳
        public TimeSpan CurrentTime
        {
            get
            {
                if (!timer.Enabled) return TimeSpan.FromSeconds(baseSeconds);
                var elapsed = (DateTime.Now - startTime).TotalSeconds;
                return CalculateCurrentTime(elapsed);
            }
        }

        public TimeSpan TotalCost
        {
            get
            {
                if (!timer.Enabled) return totalCost;
                double elapsed = (DateTime.Now - startTime).TotalSeconds;
                if (currentMode == TimerMode.CountDown)
                {
                    return totalCost + TimeSpan.FromSeconds(elapsed + 1);
                }
                else
                {
                    return CurrentTime;
                }
            }
        }

        //初始化计时器
        public TimerService(int initialSeconds = 0, TimerMode mode = TimerMode.CountUp)
        {
            baseSeconds = initialSeconds;
            currentMode = mode;

            timer = new System.Timers.Timer(200);
            timer.Elapsed += OnTimerElapsed;

        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var elapsed = (e.SignalTime - startTime).TotalSeconds;
            var current = CalculateCurrentTime(elapsed);


            //倒计时结束检测
            if (CurrentMode == TimerMode.CountDown && current.TotalSeconds <= 0)
            {
                timer.Stop();
                baseSeconds = 0; // 确保归零
                totalCost += TimeSpan.FromSeconds(elapsed); // 补足最后时段
                TimerCompleted?.Invoke();
            }

        }

        //启动计时器（记录系统时间为开始时间）
        public void Start()
        {
            if (!timer.Enabled)
            {
                startTime = DateTime.Now;
                timer.Start();
            }
        }

        //暂停计时（暂停计时器，更新基准时间）
        public void Pause()
        {
            if (timer.Enabled)
            {
                double elapsed = (DateTime.Now - startTime).TotalSeconds;
                if (currentMode == TimerMode.CountDown)
                {
                    totalCost += TimeSpan.FromSeconds(elapsed);
                }
                else
                {
                    totalCost = CurrentTime;
                    // CountUp模式按需处理
                }
                UpdateBaseTime(elapsed);
                timer.Stop();
            }
        }

        //重置计时器
        public void Reset(int newSeconds = 0, TimerMode? mode = null)
        {
            //Pause();
            timer.Stop();
            baseSeconds = newSeconds;
            totalCost = TimeSpan.Zero;
            if (mode.HasValue) { CurrentMode = mode.Value; }
        }

        private TimeSpan CalculateCurrentTime(double elapsedSeconds)
        {
            return CurrentMode switch
            {
                TimerMode.CountUp => TimeSpan.FromSeconds(baseSeconds + elapsedSeconds),
                TimerMode.CountDown => TimeSpan.FromSeconds(Math.Max(baseSeconds - elapsedSeconds, 0)),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void UpdateBaseTime(double elapsed)
        {
            baseSeconds = CurrentMode switch
            {
                TimerMode.CountUp => baseSeconds + elapsed,
                TimerMode.CountDown => Math.Max(baseSeconds - elapsed, 0),
                _ => baseSeconds
            };
        }
    }

}