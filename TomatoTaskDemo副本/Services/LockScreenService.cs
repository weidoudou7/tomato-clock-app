using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace TomatoClockApp.Services
{
    public class AppLockConfig
    {
        public int Version { get; set; } = 1;

        //是否开启锁屏功能
        public bool EnableLock { get; set; } = true;

        //锁屏的类别
        public HashSet<string> LockCategories { get; set; } = new HashSet<string>() { "社交", "音乐", "视频", "游戏" };

        //允许的进程白名单
        public HashSet<string> AllowedProcesses { get; set; } = new HashSet<string>();

        public static readonly Dictionary<string, HashSet<String>> CategoryProcessMap = new()
        {
            ["社交"] = ["wechat", "qq", "tim", "telegram", "discord"],
            ["音乐"] = ["spotify", "neteasemusic", "qqmusic", "cloudmusic"],
            ["视频"] = ["bilibili", "youku", "iqiyi", "potplayer", "vlc"],
            ["游戏"] = ["wegame", "steam", "origin", "epicgameslauncher"]
        };
    }
    public class LockScreenService : IDisposable
    {
        private System.Timers.Timer timer;
        private AppLockConfig config = new AppLockConfig();
        private bool disposedValue;

        private bool _hasPromptedForAdmin = false;
        private readonly object _promptLock = new object();

        public LockScreenService()
        {
            InitializeTimer();
            ProtectProcess();
        }

        public void StartLock()
        {
            timer.Start();
        }

        public void StopLock()
        {
            timer.Stop();
        }

        // 更新config白名单内容
        public void UpdateConfig(AppLockConfig config)
        {
            this.config = config;
        }

        public AppLockConfig GetAppLockConfig()
        {
            return config;
        }
        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(1500) { SynchronizingObject = null };
            timer.Elapsed += (s, e) => CheckProcesses();
        }

        public bool IsLocked()
        {
            return timer.Enabled;
        }

        // 进程检查逻辑
        private void CheckProcesses()
        {
            //  获取当前所有非空进程名的进程
            var processes = System.Diagnostics.Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.ProcessName)).ToList();

            foreach (var process in processes)
            {
                try
                {
                    if (ShouldBlockProcess(process))
                    {
                        //KillProcessTree(process);
                        CloseProcess(process);
                    }
                }
                catch (Win32Exception ex) when (ex.NativeErrorCode == 5)
                {
                    bool shouldPrompt = false;

                    // 使用双重检查锁确保线程安全
                    if (!_hasPromptedForAdmin)
                    {
                        lock (_promptLock)
                        {
                            if (!_hasPromptedForAdmin)
                            {
                                shouldPrompt = true;
                                _hasPromptedForAdmin = true;
                            }
                        }
                    }

                    if (shouldPrompt)
                    {
                        // 在UI线程执行提示（如果定时器不在UI线程）
                        if (timer.SynchronizingObject != null && timer.SynchronizingObject.InvokeRequired)
                        {
                            timer.SynchronizingObject.BeginInvoke((MethodInvoker)delegate
                            {
                                HandleAdminPrompt(process.ProcessName);
                            }, null);
                        }
                        else
                        {
                            HandleAdminPrompt(process.ProcessName);
                        }
                    }
                    continue;
                }
            }
        }

        // 提取提示处理逻辑到独立方法
        private void HandleAdminPrompt(string processName)
        {
            var result = MessageBox.Show(
                $"需要管理员权限操作 {processName}，是否立即以管理员身份重启？\n\n" +
                "(若选择否，本次运行期间将不再提示)",
                "权限不足",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2  // 默认选择否
            );

            if (result == DialogResult.Yes)
            {
                RestartAsAdmin();
            }
        }


        // 以管理员身份重启应用程序
        private static void RestartAsAdmin()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = Application.ExecutablePath,
                UseShellExecute = true,
                Verb = "runas" // 触发UAC提权
            };

            try
            {
                Process.Start(startInfo);
                Application.Exit();
            }
            catch (Win32Exception)
            {
                // 用户取消了UAC提示
            }
        }

        private static bool IsSystemProcess(Process process)
        {
            try
            {
                return process.SessionId == 0 ||
                       process.ProcessName.StartsWith("csrss") ||
                       process.ProcessName.StartsWith("wininit");
            }
            catch
            {
                return true;
            }
        }

        //------------------------------------
        // 关闭进程
        private static void CloseProcess(Process process)
        {
            try
            {
                if (process.HasExited || IsSystemProcess(process)) return;

                //尝试关闭主窗口
                if (process.CloseMainWindow())
                {
                    //等待最多5秒让程序自行退出
                    if (process.WaitForExit(5000))
                    {
                        KillProcessTree(process);
                    }
                }
                else
                {
                    // MessageBox.Show("无法关闭");
                }
            }
            catch (InvalidOperationException) { /* 进程已退出 */ }
        }


        private static void KillProcessTree(Process process)
        {
            var children = new ManagementObjectSearcher(
                $"Select * From Win32_Process Where ParentProcessID={process.Id}"
            );
            foreach (var mo in children.Get())
            {
                var childPid = Convert.ToInt32(mo["ProcessID"]);
                using var childProcess = Process.GetProcessById(childPid);
                KillProcessTree(childProcess);  // 递归终止子进程
            }

            try
            {
                if (!process.HasExited) process.Kill();
            }
            catch (InvalidOperationException) { /* 进程已退出 */ }
        }

        //--------------------------------------------------
        // 判断进程是否需要被阻止
        private bool ShouldBlockProcess(Process process)
        {
            var processSign = GetProcessSignature(process);

            // 检查白名单
            foreach (var allowedProcess in config.AllowedProcesses)
            {
                if (processSign.Contains(allowedProcess))
                {
                    return false;
                }
            }

            return config.LockCategories.Any(category =>
            AppLockConfig.CategoryProcessMap[category]
            .Any(keyword => processSign.Contains(keyword)));

        }

        //进程特征识别机制
        private string GetProcessSignature(Process process)
        {
            //进程名称（小写）+进程标题（小写）+文件描述符
            try
            {
                return $"{process.ProcessName.ToLower()} " +
               $"{process.MainWindowTitle.ToLower()} " +
               $"{GetFileDescription(process)}";
            }
            catch
            {
                return process.ProcessName.ToLower();
            }
        }

        // 获取文件描述符
        private string GetFileDescription(Process process)
        {
            var filePath = process.MainModule?.FileName;
            var versionInfo = FileVersionInfo.GetVersionInfo(filePath);
            return versionInfo.FileDescription?.ToLower() ?? "";
        }

        //提升进程优先级防止意外关闭
        private static void ProtectProcess()
        {
            var currentProcess = Process.GetCurrentProcess();

            // 设置最高优先级
            currentProcess.PriorityClass = ProcessPriorityClass.High;

            // 使用Windows API设置关机参数（0x3FF表示最后关闭）
            SetProcessShutdownParameters(0x3FF, 0);
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool SetProcessShutdownParameters(int dwLevel, int dwFlags);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~LockScreenService()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}