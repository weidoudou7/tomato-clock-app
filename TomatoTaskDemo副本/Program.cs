using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Data;
using TomatoClockApp.Repository;
using TomatoClockApp.Views;
//// 在Program.cs或启动类中添加服务配置
//var services = new ServiceCollection();
//services.AddDbContext<AppDbContext>();
//services.AddScoped<TaskRepository>();
//services.AddScoped<TaskController>();
//var serviceProvider = services.BuildServiceProvider();

//// 创建窗体时使用服务提供程序
//var taskController = serviceProvider.GetRequiredService<TaskController>();
//var taskForm = new TaskForm(taskController);
namespace TomatoClockApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainFormdemo());
            Application.Run(new todolist登录界面.LoginForm());
        }
    }
}