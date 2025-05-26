using System.Globalization;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using TomatoClockApp.Models;
using Task = TomatoClockApp.Models.Task;


namespace TomatoClockApp.Views
{
    public partial class CalendarForm : Form
    {
        private TaskController taskController;
        private DateTime currentDate;
        private List<Task> tasks;

        public CalendarForm(TaskController taskController)
        {
            //InitializeComponent();
            //this.taskController = taskController;
            //currentDate = DateTime.Now;
            //LoadTasks(tasks, currentDate);
            //DisplayMonthYear();
            //DisplayDays();
            InitializeComponent();
            this.taskController = taskController;
            currentDate = DateTime.Now;

            // 初始化数据
            DisplayMonthYear();
            DisplayDays();
            LoadTasksForDate(currentDate); // 直接加载当前日期任务
        }

        private void LoadTasks(List<Task> tasks, DateTime selectday)
        {

            if (tasks != null)
                tasks.Clear();

            tasks = taskController.GetTasks();
            foreach (var task in tasks)
            {
                if (task.Deadline.Date == selectday.Date)
                {
                    AddTaskItem(task);
                }
            }
        }
        // 修改后的任务加载方法
        private void LoadTasksForDate(DateTime date)
        {
            taskPanel.Controls.Clear();
            var tasks = taskController.GetTasks().Where(t => t.Deadline.Date == date.Date);
            foreach (var task in tasks)
            {
                AddTaskItem(task);
            }
        }

        private void DisplayMonthYear()
        {
            // 设置标签文本为当前的年月日，格式为 "yyyy年M月d日"
            lblMonthYear.Text = currentDate.ToString("yyyy年M月d日", CultureInfo.InvariantCulture);
        }

        private DateTime? selectedDay;

        private void DisplayDays()
        {
            weekDaysPanel.Controls.Clear(); // 清除之前的日期标签

            // 添加星期标签
            string[] weekDays = { "日", "一", "二", "三", "四", "五", "六" };

            DateTime today = DateTime.Today;

            // 获取今天是星期几
            int currentDayOfWeek = (int)today.DayOfWeek;

            // 创建一个新的数组存放实时的日期号
            int[] weekdays = new int[7];

            // 填充weekdays数组，包含每个星期几对应的日期号
            for (int i = 0; i < 7; i++)
            {
                // 获取当前星期几的日期号
                DateTime currentDate = today.AddDays(i - currentDayOfWeek); // 获取对应的星期几
                weekdays[i] = currentDate.Day; // 获取该日期的号
            }



            for (int i = 0; i < weekDays.Length; i++)
            {
                Label lblDayName = new Label
                {
                    Text = weekDays[i][weekDays[i].Length - 1].ToString() + " " + weekdays[i], // 显示星期的缩写
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("微软雅黑", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand, // 设置鼠标指针为手形

                };
                if (weekdays[i] == today.Day)
                {
                    lblDayName.BackColor = Color.LightCoral; // 设置背景颜色为浅珊瑚色
                    lblDayName.ForeColor = Color.Red; // 设置前景色为红色 }
                }
                lblDayName.MouseEnter += DayName_MouseEnter; // 添加鼠标悬停事件
                lblDayName.MouseLeave += DayName_MouseLeave; // 添加鼠标离开事件
                lblDayName.Click += lblDay_Click;
                weekDaysPanel.Controls.Add(lblDayName);
            }

        }

        private void DayName_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.ForeColor = Color.Red;
            }
        }

        private void DayName_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.ForeColor = Color.Black;
            }
        }

        private void lblDay_Click(object sender, EventArgs e)
        {

            Label lblDay = sender as Label;
            if (lblDay != null)
            {
                // 清除所有日期的选中状态
                foreach (Control ctrl in weekDaysPanel.Controls)
                {
                    if (ctrl is Label lbl)
                    {
                        lbl.BackColor = Color.White; // 清除背景颜色
                        lbl.ForeColor = Color.Black; // 清除前景色
                    }
                }

                // 设置当前点击的日期为选中状态
                lblDay.BackColor = Color.LightCoral; // 设置背景颜色为浅珊瑚色
                lblDay.ForeColor = Color.Red; // 设置前景色为红色
                taskPanel.Controls.Clear(); // 清除现有任务
                DateTime selectDay = new DateTime(currentDate.Year, currentDate.Month, int.Parse(lblDay.Text.Split(' ')[1]));
                LoadTasks(tasks, selectDay);
            }
        }



        //private void DisplayTasksForDay(int day)
        //{
        //    taskPanel.Controls.Clear(); // 清除现有任务

        //    // 假设有一个方法可以获取某一天的任务列表
        //    List<Task> tasks = GetTasksForDay(day);
        //    foreach (Task task in tasks)
        //    {
        //        AddTaskItem(task.Text, task.Category, task.Time);
        //    }
        //}

        //    private List<TaskItem> GetTasksForDay(int day)
        //    {
        //        // 这里应该是从数据库或数据源获取任务列表的逻辑
        //        // 为了示例，我们返回一些静态数据
        //        return new List<TaskItem>
        //{
        //    new TaskItem { Text = "打扫所有房间", Category = "家庭", Time = "17:00" },
        //    new TaskItem { Text = "进行高效方式测验", Category = "工作", Time = "" }
        //};
        //    }


        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var taskForm = new AddOrEditTaskForm(taskController);
            taskForm.ShowDialog();
            taskPanel.Controls.Clear(); // 清除现有任务
            LoadTasks(tasks, currentDate);
        }



        //添加任务项的辅助方法
        private void AddTaskItem(Task task)
        {

            var taskItem = new Panel
            {
                Size = new System.Drawing.Size(540, 50),
                BackColor = System.Drawing.Color.WhiteSmoke,
                Margin = new Padding(0, 0, 0, 10)
            };

            // 复选框
            var checkBox = new CheckBox
            {
                Appearance = Appearance.Button,
                Size = new System.Drawing.Size(20, 20),
                Location = new System.Drawing.Point(10, 15)
            };

            // 复选框点击事件，切换其勾选状态
            checkBox.CheckedChanged += (sender, e) => { checkBox.Invalidate(); };

            // 复选框绘制事件
            checkBox.Paint += (sender, e) =>
            {
                var checkbox = sender as CheckBox;
                if (checkbox.Checked) // 如果勾选了
                {
                    // 获取绘图对象
                    var graphics = e.Graphics;

                    // 绘制√，指定字体和颜色
                    var font = new Font("Arial", 12, FontStyle.Bold);
                    var brush = new SolidBrush(Color.Black);

                    // 画出勾选符号
                    graphics.DrawString("√", font, brush, new PointF(3, 4));

                    task.IsCompleted = true;
                }
            };
            // 任务文本
            var lblText = new Label
            {
                Text = "任务名：" + task.Name,
                Font = new System.Drawing.Font("微软雅黑", 9F),
                Location = new System.Drawing.Point(40, 10),
                AutoSize = false,
                Size = new System.Drawing.Size(350, 30)
            };


            // 分类标签
            var lblCategory = new Label
            {
                Text = "类别：" + task.Category,
                Font = new System.Drawing.Font("微软雅黑", 8F),
                BackColor = task.Category.Contains("家庭") ? System.Drawing.Color.LightPink : System.Drawing.Color.LightBlue,
                Location = new System.Drawing.Point(460, 15),
                Padding = new Padding(3, 1, 3, 1)
            };

            taskItem.Controls.Add(checkBox);
            taskItem.Controls.Add(lblText);
            taskItem.Controls.Add(lblCategory);
            taskPanel.Controls.Add(taskItem);
        }



        private void weekDaysPanel_Paint(object sender, PaintEventArgs e)
        {
            // 可以在这里添加绘制逻辑

        }

        private void taskPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
