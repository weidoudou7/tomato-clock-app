using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Data;
using TomatoClockApp.Repository;
using TomatoClockApp.Views;
//// ��Program.cs�������������ӷ�������
//var services = new ServiceCollection();
//services.AddDbContext<AppDbContext>();
//services.AddScoped<TaskRepository>();
//services.AddScoped<TaskController>();
//var serviceProvider = services.BuildServiceProvider();

//// ��������ʱʹ�÷����ṩ����
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
            
            // 确保数据库被创建
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
            
            Application.Run(new todolist登录界面.LoginForm());
        }
    }
}