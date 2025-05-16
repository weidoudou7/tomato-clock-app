using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Data;
using TomatoClockApp.Models;
using TomatoClockApp.Repository;
using TomatoClockApp.Services;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Views
{
    public partial class MainFormdemo : Form
    {
        private TaskController taskController;
        private TimerController timerController;
        private NLPController nlpController;
        private AIController aiController;
        private CommunityController communityController;
        private StatisticsController statisticsController;
        private readonly AppDbContext _context; 

        public MainFormdemo()
        {
            InitializeComponent();
            // 初始化单一上下文
            _context = new AppDbContext();
            _context.Database.EnsureCreated();

            // 所有控制器共享此上下文
            taskController = new TaskController(new TaskRepository(_context));
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }

            taskController = new TaskController(new TaskRepository(new AppDbContext()));
            timerController = new TimerController();
            nlpController = new NLPController();
            aiController = new AIController();
            communityController = new CommunityController();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var taskForm = new AddOrEditTaskForm(taskController);
            taskForm.ShowDialog();
            LoadTasks();
        }

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            timerController.Start();
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            timerController.Stop();
        }

        private void btnPlanTasks_Click(object sender, EventArgs e)
        {
            var tasks = taskController.GetTasks();
            var plannedTasks = aiController.PlanTasks(tasks);
            LoadTasks(plannedTasks);
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            var calendarForm = new CalendarForm(taskController);
            calendarForm.ShowDialog();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            var statisticsForm = new StatisticsForm(statisticsController);
            statisticsForm.ShowDialog();
        }

        private void btnCommunity_Click(object sender, EventArgs e)
        {
            var communityForm = new CommunityForm(communityController);
            communityForm.ShowDialog();
        }

        private void btnLockScreen_Click(object sender, EventArgs e)
        {
            var lockScreenController = new LockScreenController();
            var lockScreenForm = new LockScreenForm(lockScreenController);
            lockScreenForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void LoadTasks(List<Task> tasks = null)
        {
            if (tasks == null)
            {
                tasks = taskController.GetTasks();
            }

            lvTasks.Items.Clear();
            foreach (var task in tasks)
            {
                var taskItem = new ListViewItem(new[] { task.Name, task.Deadline.ToString("yyyy-MM-dd HH:mm"), task.Category, task.IsCompleted ? "已完成" : "未完成" });
                taskItem.Tag = task.Id; // 将任务的 ID 存储在 Tag 属性中
                lvTasks.Items.Add(taskItem);
            }
        }
        private void EditTask_Click(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvTasks.SelectedItems[0];
                int taskId = (int)selectedItem.Tag; // 从 Tag 属性中获取任务的 ID
                Task taskToEdit = taskController.GetTaskById(taskId);
                if (taskToEdit != null)
                {
                    AddOrEditTaskForm editForm = new AddOrEditTaskForm(taskController, taskToEdit);
                    editForm.ShowDialog();
                    // 刷新任务列表
                    LoadTasks();
                }
                else
                {
                    MessageBox.Show("无法找到任务！");
                }
            }
        }

        private void DeleteTask_Click(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvTasks.SelectedItems[0];
                lvTasks.Items.Remove(selectedItem); // 删除表中选中的任务
                int taskId = (int)selectedItem.Tag; // 获取任务的 ID
                taskController.DeleteTask(taskId); // 删除数据库中的任务
            }
        }
        private void LvTasks_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // 检查是否是右键点击
            {
                // 获取鼠标点击位置的 ListViewItem
                ListViewItem item = lvTasks.GetItemAt(e.X, e.Y);
                if (item != null) // 如果点击位置在某一行上
                {
                    // 显示右键菜单
                    contextMenu.Show(lvTasks, new Point(e.X, e.Y));
                }
            }
        }
        private void lvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}