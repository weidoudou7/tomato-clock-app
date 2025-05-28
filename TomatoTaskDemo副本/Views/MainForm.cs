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
using MaterialSkin.Controls;
using TomatoClockApp.Views;
using TomatoTaskDemo.Services;
using System.Drawing;
using System.Linq;

namespace TomatoTaskApp.Views
{
    public partial class MainForm : MaterialForm
    {
        private TaskController taskController;
        private TimerController timerController;
        private NLPController nlpController;
        private AIController aiController;
        private CommunityController communityController;
        private StatisticsController statisticsController;
        private readonly AppDbContext _context;
        private TaskTemplateController _templateController;
        private bool showMyTemplates = false;
        private CalendarForm _calendarForm;
        private BeginTaskForm _beginTaskForm;
        private LockScreenForm _lockScreenForm;

        public MainForm()
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

            // 初始化模板控制器
            var templateRepository = new TaskTemplateRepository(_context);
            var taskRepository = new TaskRepository(_context);
            _templateController = new TaskTemplateController(templateRepository, taskRepository);

            // 绑定社区相关事件
            cmbSort.SelectedIndexChanged += (s, e) => LoadTemplates();
            btnUpload.Click += BtnUpload_Click;
            btnMyTemplates.Click += (s, e) => { showMyTemplates = true; LoadTemplates(); };
            btnAllTemplates.Click += (s, e) => { showMyTemplates = false; LoadTemplates(); };

            // 初始化模板列表
            LoadTemplates();
            // 订阅 TabControl 的 SelectedIndexChanged 事件
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var taskForm = new AddOrEditTaskForm(taskController);
            taskForm.ShowDialog();
            LoadTasks();
        }

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            ////timerController.Start();
            //BeginTaskForm beginTask = new BeginTaskForm(taskController, timerController);
            //beginTask.ShowDialog();
            // 切换到tabPage3
            materialTabControl1.SelectedTab = tabPage3;

            // 确保tabPage3已初始化
            InitializeBeginTaskTab();
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
            // 1. 创建 TaskTemplateController
            var templateRepository = new TaskTemplateRepository(_context);
            var taskRepository = new TaskRepository(_context);
            var templateController = new TaskTemplateController(templateRepository, taskRepository);

            // 2. 获取当前用户ID
            int currentUserId = CurrentUser.UserId;

            // 3. 创建并显示 CommunityForm
            var communityForm = new CommunityForm(templateController, currentUserId);
            communityForm.ShowDialog();
            // 当CommunityForm关闭时刷新任务列表
            LoadTasks();
        }

        private void btnLockScreen_Click(object sender, EventArgs e)
        {
            //var lockScreenController = new LockScreenController();
            //var lockScreenForm = new LockScreenForm(lockScreenController);
            //lockScreenForm.ShowDialog();
            // 切换到tabPage6
            materialTabControl1.SelectedTab = tabPage6;

            // 确保tabPage6已初始化
            if (_lockScreenForm == null)
            {
                InitializeLockScreenTab();
            }
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

        public void RefreshTasks()
        {
            LoadTasks();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void LoadTemplates()
        {
            flowPanel.Controls.Clear();
            List<TaskTemplate> templates;
            if (showMyTemplates)
            {
                templates = _templateController.GetUserTemplates(CurrentUser.UserId);
            }
            else
            {
                templates = _templateController.GetAllPublicTemplates();
            }

            // 排序
            switch (cmbSort.SelectedItem?.ToString())
            {
                case "最多下载":
                    templates = templates.OrderByDescending(t => t.Downloads).ToList();
                    break;
                case "最多点赞":
                    templates = templates.OrderByDescending(t => t.Likes).ToList();
                    break;
                default:
                    templates = templates.OrderByDescending(t => t.CreatedAt).ToList();
                    break;
            }

            foreach (var template in templates)
            {
                var card = CreateTemplateCard(template);
                flowPanel.Controls.Add(card);
            }
        }

        private Panel CreateTemplateCard(TaskTemplate template)
        {
            var card = new Panel
            {
                Width = 280,
                Height = 180,
                Margin = new Padding(15),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            var lblTitle = new Label
            {
                Text = template.Title,
                Font = new Font("微软雅黑", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            card.Controls.Add(lblTitle);

            var lblCategory = new Label
            {
                Text = $"分类：{template.Category}",
                Location = new Point(10, 40),
                AutoSize = true
            };
            card.Controls.Add(lblCategory);

            var lblAuthor = new Label
            {
                Text = $"作者ID：{template.CreatedByUserId}",
                Location = new Point(10, 65),
                AutoSize = true
            };
            card.Controls.Add(lblAuthor);

            var lblPomodoros = new Label
            {
                Text = $"预计番茄数：{template.EstimatedPomodoros}",
                Location = new Point(10, 90),
                AutoSize = true
            };
            card.Controls.Add(lblPomodoros);

            var btnUse = new MaterialButton
            {
                Text = "使用模板",
                Location = new Point(10, 130),
                Size = new Size(120, 36)
            };
            btnUse.Click += (s, e) => UseTemplate(template);
            card.Controls.Add(btnUse);

            return card;
        }

        private void UseTemplate(TaskTemplate template)
        {
            var task = new Task
            {
                Name = template.Title,
                Category = template.Category,
                Deadline = DateTime.Now.AddDays(7), // 默认设置为7天后
                IsCompleted = false
            };

            taskController.AddTask(task);
            MessageBox.Show("任务已创建！");
            LoadTasks();
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (var form = new TaskTemplateEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var template = new TaskTemplate
                    {
                        Title = form.Title, 
                        Description = form.Description,
                        Category = form.Category,
                        EstimatedPomodoros = form.EstimatedPomodoros,
                        IsPublic = form.IsPublic,
                        CreatedByUserId = CurrentUser.UserId
                    };
                    _templateController.CreateTemplate(template);
                    showMyTemplates = true;
                    LoadTemplates();
                }
            }
        }

        // Tab 切换事件处理函数
        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == tabPage2)
            {
                InitializeCalendarTab();
            }
            if (materialTabControl1.SelectedTab == tabPage3)
            {
                InitializeBeginTaskTab();
            }
            if(materialTabControl1.SelectedTab == tabPage6)
            {
                InitializeLockScreenTab();
            }
        }

        // 初始化日历 Tab 页
        private void InitializeCalendarTab()
        {
            if (_calendarForm != null)
            {
                _calendarForm.Dispose();
                tabPage2.Controls.Clear();
            }

            // 创建并嵌入 CalendarForm
            _calendarForm = new CalendarForm(taskController)
            {
                TopLevel = false,       // 关键：设置为非顶级窗口
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill   // 填充整个 TabPage
            };

            // 将窗体添加到 TabPage
            tabPage2.Controls.Add(_calendarForm);
            _calendarForm.Show(); // 显示窗体
        }
        // 初始化任务开始 Tab 页
        private void InitializeBeginTaskTab()
        {
            if (_beginTaskForm != null)
            {
                _beginTaskForm.Dispose();
                tabPage3.Controls.Clear();
            }

            // 创建并嵌入 BeginTaskForm
            _beginTaskForm = new BeginTaskForm(taskController, timerController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // 将窗体添加到 TabPage
            tabPage3.Controls.Add(_beginTaskForm);
            _beginTaskForm.Show();

        }

        private void InitializeLockScreenTab()
        {
            if (_lockScreenForm != null)
            {
                _lockScreenForm.Dispose();
                tabPage6.Controls.Clear();
            }

            // 创建并嵌入 LockScreenForm
            var lockScreenForm = new LockScreenForm(new LockScreenController())
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Size = new Size(800, 480),          // 固定大小 800x600
                Location = new Point(20, 10)           // 左上显示
            };

            // 将窗体添加到 TabPage
            tabPage6.Controls.Add(lockScreenForm);
            lockScreenForm.Show();
        }

    }
}
