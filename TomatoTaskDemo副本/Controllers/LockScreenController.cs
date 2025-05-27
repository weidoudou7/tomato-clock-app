using TomatoClockApp.Services;

namespace TomatoClockApp.Controllers
{
    public class LockScreenController
    {
        private LockScreenService lockScreenService;

        public LockScreenController()
        {
            lockScreenService = new LockScreenService();
        }

        public void Lock()
        {
            lockScreenService.StartLock();
        }

        public void Unlock()
        {
            lockScreenService.StopLock();
        }

        public AppLockConfig GetAppLockConfig()
        {
            return lockScreenService.GetAppLockConfig();
        }

        public void UpdateAppLockConfig(AppLockConfig config)
        {
            lockScreenService.UpdateConfig(config);
        }

        public bool IsLocked()
        {
            return lockScreenService.IsLocked();
        }
    }
}