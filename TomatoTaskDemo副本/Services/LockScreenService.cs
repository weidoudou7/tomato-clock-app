namespace TomatoClockApp.Services
{
    public class LockScreenService
    {
        // 锁机系统的逻辑可以在这里实现，例如验证密码等
        public bool Unlock(string password)
        {
            return password == "123456"; // 假设密码是123456
        }
    }
}