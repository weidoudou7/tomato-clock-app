using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Data;
using TomatoClockApp.Repository;
using TomatoClockApp.Views;
//// ��Program.cs������������ӷ�������
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
            //Application.Run(new MainFormdemo());
            Application.Run(new todolist��¼����.LoginForm());
        }
    }
}