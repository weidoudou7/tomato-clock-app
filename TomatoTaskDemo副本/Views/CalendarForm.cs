using System.Windows.Forms;
using TomatoClockApp.Controllers;

namespace TomatoClockApp.Views
{
    public partial class CalendarForm : Form
    {
        private TaskController taskController;

        public CalendarForm(TaskController taskController)
        {
            InitializeComponent();
            this.taskController = taskController;
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = taskController.GetTasks();
            lvTasks.Items.Clear();
            foreach (var task in tasks)
            {
                var taskItem = new ListViewItem(new[] { task.Name, task.Deadline.ToString("yyyy-MM-dd HH:mm"), task.Category, task.IsCompleted ? "已完成" : "未完成" });
                lvTasks.Items.Add(taskItem);
            }
        }
    }
}