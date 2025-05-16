using System.Windows.Forms;
using TomatoClockApp.Controllers;

namespace TomatoClockApp.Views
{
    public partial class StatisticsForm : Form
    {
        private StatisticsController statisticsController;

        public StatisticsForm(StatisticsController statisticsController)
        {
            InitializeComponent();
            this.statisticsController = statisticsController;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            int totalTasks = statisticsController.GetTotalTasks();
            int completedTasks = statisticsController.GetCompletedTasks();
            int completionRate = totalTasks > 0 ? completedTasks * 100 / totalTasks : 0;

            lblTotalTasks.Text = $"总任务数: {totalTasks}";
            lblCompletedTasks.Text = $"已完成任务数: {completedTasks}";
            lblCompletionRate.Text = $"完成率: {completionRate}%";
        }
    }
}