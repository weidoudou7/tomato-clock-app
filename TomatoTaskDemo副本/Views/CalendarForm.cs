//using System.Globalization;
//using System.Windows.Forms;
//using TomatoClockApp.Controllers;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Drawing.Drawing2D;
//using TomatoClockApp.Models;
//using Task = TomatoClockApp.Models.Task;


//namespace TomatoClockApp.Views
//{
//    public partial class CalendarForm : Form
//    {
//        private TaskController taskController;
//        private DateTime currentDate;
//        private List<Task> tasks;

//        public CalendarForm(TaskController taskController)
//        {
//            //InitializeComponent();
//            //this.taskController = taskController;
//            //currentDate = DateTime.Now;
//            //LoadTasks(tasks, currentDate);
//            //DisplayMonthYear();
//            //DisplayDays();
//            InitializeComponent();
//            this.taskController = taskController;
//            currentDate = DateTime.Now;

//            // 初始化数据
//            DisplayMonthYear();
//            DisplayDays();
//            LoadTasksForDate(currentDate); // 直接加载当前日期任务
//        }

//        private void LoadTasks(List<Task> tasks, DateTime selectday)
//        {

//            if (tasks != null)
//                tasks.Clear();

//            tasks = taskController.GetTasks();
//            foreach (var task in tasks)
//            {
//                if (task.Deadline.Date == selectday.Date)
//                {
//                    AddTaskItem(task);
//                }
//            }
//        }
//        // 修改后的任务加载方法
//        private void LoadTasksForDate(DateTime date)
//        {
//            taskPanel.Controls.Clear();
//            var tasks = taskController.GetTasks().Where(t => t.Deadline.Date == date.Date);
//            foreach (var task in tasks)
//            {
//                AddTaskItem(task);
//            }
//        }

//        private void DisplayMonthYear()
//        {
//            // 设置标签文本为当前的年月日，格式为 "yyyy年M月d日"
//            lblMonthYear.Text = currentDate.ToString("yyyy年M月d日", CultureInfo.InvariantCulture);
//        }

//        private DateTime? selectedDay;

//        private void DisplayDays()
//        {
//            weekDaysPanel.Controls.Clear(); // 清除之前的日期标签

//            // 添加星期标签
//            string[] weekDays = { "日", "一", "二", "三", "四", "五", "六" };

//            DateTime today = DateTime.Today;

//            // 获取今天是星期几
//            int currentDayOfWeek = (int)today.DayOfWeek;

//            // 创建一个新的数组存放实时的日期号
//            int[] weekdays = new int[7];

//            // 填充weekdays数组，包含每个星期几对应的日期号
//            for (int i = 0; i < 7; i++)
//            {
//                // 获取当前星期几的日期号
//                DateTime currentDate = today.AddDays(i - currentDayOfWeek); // 获取对应的星期几
//                weekdays[i] = currentDate.Day; // 获取该日期的号
//            }



//            for (int i = 0; i < weekDays.Length; i++)
//            {
//                Label lblDayName = new Label
//                {
//                    Text = weekDays[i][weekDays[i].Length - 1].ToString() + " " + weekdays[i], // 显示星期的缩写
//                    Dock = DockStyle.Fill,
//                    TextAlign = ContentAlignment.MiddleCenter,
//                    Font = new Font("微软雅黑", 10F, FontStyle.Bold),
//                    Cursor = Cursors.Hand, // 设置鼠标指针为手形

//                };
//                if (weekdays[i] == today.Day)
//                {
//                    lblDayName.BackColor = Color.LightCoral; // 设置背景颜色为浅珊瑚色
//                    lblDayName.ForeColor = Color.Red; // 设置前景色为红色 }
//                }
//                lblDayName.MouseEnter += DayName_MouseEnter; // 添加鼠标悬停事件
//                lblDayName.MouseLeave += DayName_MouseLeave; // 添加鼠标离开事件
//                lblDayName.Click += lblDay_Click;
//                weekDaysPanel.Controls.Add(lblDayName);
//            }

//        }

//        private void DayName_MouseEnter(object sender, EventArgs e)
//        {
//            Label lbl = sender as Label;
//            if (lbl != null)
//            {
//                lbl.ForeColor = Color.Red;
//            }
//        }

//        private void DayName_MouseLeave(object sender, EventArgs e)
//        {
//            Label lbl = sender as Label;
//            if (lbl != null)
//            {
//                lbl.ForeColor = Color.Black;
//            }
//        }

//        private void lblDay_Click(object sender, EventArgs e)
//        {

//            Label lblDay = sender as Label;
//            if (lblDay != null)
//            {
//                // 清除所有日期的选中状态
//                foreach (Control ctrl in weekDaysPanel.Controls)
//                {
//                    if (ctrl is Label lbl)
//                    {
//                        lbl.BackColor = Color.White; // 清除背景颜色
//                        lbl.ForeColor = Color.Black; // 清除前景色
//                    }
//                }

//                // 设置当前点击的日期为选中状态
//                lblDay.BackColor = Color.LightCoral; // 设置背景颜色为浅珊瑚色
//                lblDay.ForeColor = Color.Red; // 设置前景色为红色
//                taskPanel.Controls.Clear(); // 清除现有任务
//                DateTime selectDay = new DateTime(currentDate.Year, currentDate.Month, int.Parse(lblDay.Text.Split(' ')[1]));
//                LoadTasks(tasks, selectDay);
//            }
//        }



//        //private void DisplayTasksForDay(int day)
//        //{
//        //    taskPanel.Controls.Clear(); // 清除现有任务

//        //    // 假设有一个方法可以获取某一天的任务列表
//        //    List<Task> tasks = GetTasksForDay(day);
//        //    foreach (Task task in tasks)
//        //    {
//        //        AddTaskItem(task.Text, task.Category, task.Time);
//        //    }
//        //}

//        //    private List<TaskItem> GetTasksForDay(int day)
//        //    {
//        //        // 这里应该是从数据库或数据源获取任务列表的逻辑
//        //        // 为了示例，我们返回一些静态数据
//        //        return new List<TaskItem>
//        //{
//        //    new TaskItem { Text = "打扫所有房间", Category = "家庭", Time = "17:00" },
//        //    new TaskItem { Text = "进行高效方式测验", Category = "工作", Time = "" }
//        //};
//        //    }


//        private void btnAddTask_Click(object sender, EventArgs e)
//        {
//            var taskForm = new AddOrEditTaskForm(taskController);
//            taskForm.ShowDialog();
//            taskPanel.Controls.Clear(); // 清除现有任务
//            LoadTasks(tasks, currentDate);
//        }



//        //添加任务项的辅助方法
//        private void AddTaskItem(Task task)
//        {

//            var taskItem = new Panel
//            {
//                Size = new System.Drawing.Size(540, 50),
//                BackColor = System.Drawing.Color.WhiteSmoke,
//                Margin = new Padding(0, 0, 0, 10)
//            };

//            // 复选框
//            var checkBox = new CheckBox
//            {
//                Appearance = Appearance.Button,
//                Size = new System.Drawing.Size(20, 20),
//                Location = new System.Drawing.Point(10, 15)
//            };

//            // 复选框点击事件，切换其勾选状态
//            checkBox.CheckedChanged += (sender, e) => { checkBox.Invalidate(); };

//            // 复选框绘制事件
//            checkBox.Paint += (sender, e) =>
//            {
//                var checkbox = sender as CheckBox;
//                if (checkbox.Checked) // 如果勾选了
//                {
//                    // 获取绘图对象
//                    var graphics = e.Graphics;

//                    // 绘制√，指定字体和颜色
//                    var font = new Font("Arial", 12, FontStyle.Bold);
//                    var brush = new SolidBrush(Color.Black);

//                    // 画出勾选符号
//                    graphics.DrawString("√", font, brush, new PointF(3, 4));

//                    task.IsCompleted = true;
//                }
//            };
//            // 任务文本
//            var lblText = new Label
//            {
//                Text = "任务名：" + task.Name,
//                Font = new System.Drawing.Font("微软雅黑", 9F),
//                Location = new System.Drawing.Point(40, 10),
//                AutoSize = false,
//                Size = new System.Drawing.Size(350, 30)
//            };


//            // 分类标签
//            var lblCategory = new Label
//            {
//                Text = "类别：" + task.Category,
//                Font = new System.Drawing.Font("微软雅黑", 8F),
//                BackColor = task.Category.Contains("家庭") ? System.Drawing.Color.LightPink : System.Drawing.Color.LightBlue,
//                Location = new System.Drawing.Point(460, 15),
//                Padding = new Padding(3, 1, 3, 1)
//            };

//            taskItem.Controls.Add(checkBox);
//            taskItem.Controls.Add(lblText);
//            taskItem.Controls.Add(lblCategory);
//            taskPanel.Controls.Add(taskItem);
//        }



//        private void weekDaysPanel_Paint(object sender, PaintEventArgs e)
//        {
//            // 可以在这里添加绘制逻辑

//        }

//        private void taskPanel_Paint(object sender, PaintEventArgs e)
//        {

//        }
//    }
//}


using System.Globalization;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using TomatoClockApp.Models;
using Task = TomatoClockApp.Models.Task;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TomatoClockApp.Views
{
    public partial class CalendarForm : Form
    {
        private readonly TaskController _taskController;
        private DateTime _currentDate;
        private List<Task> _tasks = new List<Task>();
        private Dictionary<DateTime, Panel> dateSections = new Dictionary<DateTime, Panel>();
        private DateTime _currentStartDate = DateTime.Today;
        private const int DaysPerLoad = 7; // 每次加载的天数
        private bool isLoading = false;
        private int _scrollThreshold = 200; // 滚动多少像素后切换星期高亮
        private int _accumulatedScroll = 0; // 累计滚动距离
        private DateTime _currentWeekStart; // 当前高亮星期的开始日期(周日)


        public CalendarForm(TaskController taskController)
        {
            InitializeComponent();
            _taskController = taskController;
            _currentDate = DateTime.Today;
            InitializeCalendar();

        }

        private void InitializeCalendar()
        {
            //LoadTasks(_currentDate);
            DisplayMonthYear();
            DisplayWeekDays();
            InitializeTaskPanel();
        }

        private void InitializeTaskPanel()
        {
            taskPanel.AutoScroll = true;

            taskPanel.Scroll += TaskPanel_Scroll;
            CreateDateSection(_currentStartDate);
            // 加载当前日期及前后各3天
            LoadMoreDates(30); // 这会加载今天及前后3天，共7天
        }

        private void LoadMoreDates(int daysToLoad)
        {
            if (isLoading) return;
            isLoading = true;

            // 确定要加载的日期范围
            var existingDates = dateSections.Keys.ToList();
            var minDate = existingDates.Any() ? existingDates.Min() : _currentStartDate;
            var maxDate = existingDates.Any() ? existingDates.Max() : _currentStartDate;

            // 向上加载更多日期


            for (int i = 1; i <= daysToLoad; i++)
            {
                var prevDate = minDate.AddDays(-1);
                if (!dateSections.ContainsKey(prevDate))
                {
                    CreateDateSection(prevDate);
                }
                minDate = prevDate;
            }

            // 向下加载更多日期
            for (int i = 1; i <= daysToLoad; i++)
            {
                var nextDate = maxDate.AddDays(1);
                if (!dateSections.ContainsKey(nextDate))
                {
                    CreateDateSection(nextDate);
                }
                maxDate = nextDate;
            }

            isLoading = false;
        }

        private void CreateDateSection(DateTime date)
        {
            string[] weekDays = { "日", "一", "二", "三", "四", "五", "六" };

            // 创建日期标题
            var dateTitle = new Label
            {
                Text = $"{date.Month}月{date.Day}日 - 星期{weekDays[(int)date.DayOfWeek]}",
                AutoSize = true,
                Font = new Font("Microsoft YaHei", 8, FontStyle.Regular),
                ForeColor = Color.FromArgb(80, 80, 80),
                Margin = new Padding(15, 15, 0, 5)
            };

            // 创建添加任务按钮
            var addButton = new Button
            {
                Text = "+ 添加任务",
                Tag = date,
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft YaHei", 8),
                ForeColor = Color.FromArgb(100, 100, 100),
                BackColor = Color.Transparent,
                Margin = new Padding(15, 0, 0, 15),
                Cursor = Cursors.Hand,
                FlatAppearance = {
            BorderSize = 0,
            MouseDownBackColor = Color.Transparent,
            MouseOverBackColor = Color.FromArgb(240, 240, 240)
        }
            };

            // 为每个日期创建一个容器面板
            var datePanel = new Panel
            {
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 20),
                Tag = date
            };

            // 设置日期标题和按钮位置
            dateTitle.Location = new Point(15, 10);
            addButton.Location = new Point(dateTitle.Right + 10, dateTitle.Top - 2);

            // 将控件添加到日期面板
            datePanel.Controls.Add(dateTitle);
            datePanel.Controls.Add(addButton);

            // 添加到主面板的最前面或最后面
            if (date < _currentStartDate)
            {
                taskPanel.Controls.Add(datePanel);
                taskPanel.Controls.SetChildIndex(datePanel, 0);
            }
            else
            {
                taskPanel.Controls.Add(datePanel);
            }

            // 保存日期和对应面板的引用
            dateSections.Add(date, datePanel);

            // 为按钮添加点击事件
            addButton.Click += (sender, e) =>
            {
                _currentStartDate = date;
                btnAddTask_Click(sender, e);
            };

            // 加载该日期的任务
            LoadTasksForDate(date);
        }

        private void TaskPanel_Scroll(object sender, ScrollEventArgs e)
        {
            //// Ensure UI thread safety and minimize redundant updates
            //if (!isLoading)
            //{
            //    this.BeginInvoke((MethodInvoker)delegate
            //    {
            //        var topVisibleDate = GetTopVisibleDate();
            //        if (topVisibleDate != null)
            //        {
            //            UpdateWeekDaysHighlight(topVisibleDate.Value);
            //        }

            //        // 加载更多日期逻辑保持不变...
            //        if (taskPanel.VerticalScroll.Value == 0)
            //        {
            //            LoadMoreDates(DaysPerLoad);
            //            taskPanel.AutoScrollPosition = new Point(0, 100);
            //        }
            //        else if (taskPanel.VerticalScroll.Value + taskPanel.ClientSize.Height >= taskPanel.VerticalScroll.Maximum - 50)
            //        {
            //            LoadMoreDates(DaysPerLoad);
            //        }
            //    });
            //}
            if (isLoading) return;

            // 计算滚动方向和距离
            int scrollDelta = e.NewValue - e.OldValue;
            _accumulatedScroll += scrollDelta;

            // 当累计滚动距离超过阈值时切换星期
            if (Math.Abs(_accumulatedScroll) >= _scrollThreshold)
            {
                // 判断滚动方向
                bool scrollingDown = _accumulatedScroll > 0;
                _accumulatedScroll = 0; // 重置计数器

                // 获取当前可见区域的顶部日期
                var visibleDate = GetTopVisibleDate() ?? DateTime.Today;

                // 计算新的星期起始日(周日)
                _currentWeekStart = scrollingDown
                    ? _currentWeekStart.AddDays(7) // 向下滚动，切换到下周
                    : _currentWeekStart.AddDays(-7); // 向上滚动，切换到上周

                // 更新星期高亮显示
                UpdateWeekDaysHighlight(_currentWeekStart);
            }

            // 原有的加载更多日期逻辑保持不变
            if (taskPanel.VerticalScroll.Value == 0)
            {
                LoadMoreDates(DaysPerLoad);
                taskPanel.AutoScrollPosition = new Point(0, 100);
            }
            else if (taskPanel.VerticalScroll.Value + taskPanel.ClientSize.Height
                     >= taskPanel.VerticalScroll.Maximum - 50)
            {
                LoadMoreDates(DaysPerLoad);
            }
        }

        private DateTime? GetTopVisibleDate()
        {
            // 获取当前可见区域
            int scrollPos = -taskPanel.AutoScrollPosition.Y;
            int clientHeight = taskPanel.ClientSize.Height;
            int visibleTop = scrollPos;
            int visibleBottom = scrollPos + clientHeight;

            // 找到第一个完全或部分可见的日期面板
            foreach (var kvp in dateSections.OrderBy(x => x.Key))
            {
                var panel = kvp.Value;
                if (panel.Bottom > visibleTop && panel.Top < visibleBottom)
                {
                    return kvp.Key;
                }
            }

            return null;
        }

        private void UpdateWeekDaysHighlight(DateTime currentDate)
        {
            // 获取当前周的起始日(周日)
            var startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);

            // 更新星期标签高亮
            foreach (Control ctrl in weekDaysPanel.Controls)
            {
                if (ctrl is Label lbl && lbl.Tag is DateTime labelDate)
                {
                    bool isCurrentDay = labelDate.Date == currentDate.Date;
                    bool isToday = labelDate.Date == DateTime.Today.Date;

                    lbl.BackColor = isCurrentDay ? Color.LightCoral : (isToday ? Color.LightCoral : Color.White);
                    lbl.ForeColor = isCurrentDay ? Color.Red : (isToday ? Color.Red : Color.Black);
                }
            }

            // 更新月份年份显示
            lblMonthYear.Text = currentDate.ToString("yyyy年M月d日", CultureInfo.InvariantCulture);
        }

        private void LoadTasksForDate(DateTime date)
        {

            var tasksForDate = _taskController.GetTasks().FindAll(t => t.Deadline.Date == date.Date);

            if (dateSections.TryGetValue(date, out var datePanel))
            {
                // 清除现有任务项（保留标题和按钮）
                for (int i = datePanel.Controls.Count - 1; i >= 0; i--)
                {
                    if (datePanel.Controls[i].Tag?.ToString() == "TaskItem")
                    {
                        datePanel.Controls.RemoveAt(i);
                    }
                }

                // 添加新任务项
                int yPos = datePanel.Controls[0].Bottom + 10;
                foreach (var task in tasksForDate)
                {
                    var taskItem = CreateTaskItem(task);
                    taskItem.Location = new Point(25, yPos);
                    taskItem.Tag = "TaskItem";
                    datePanel.Controls.Add(taskItem);
                    yPos += taskItem.Height + 10;
                }

                // 调整面板高度
                datePanel.Height = yPos;
            }
        }

        private void DisplayMonthYear()
        {
            lblMonthYear.Text = _currentDate.ToString("yyyy年M月d日", CultureInfo.InvariantCulture);
        }

        private void DisplayWeekDays()
        {

            weekDaysPanel.Controls.Clear();

            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            string[] weekDays = { "日", "一", "二", "三", "四", "五", "六" };

            for (int i = 0; i < 7; i++)
            {
                var date = startOfWeek.AddDays(i);
                var dayLabel = CreateDayLabel(weekDays[i], date.Day, date.Date == today);
                weekDaysPanel.Controls.Add(dayLabel);
            }

        }


        private Label CreateDayLabel(string dayName, int dayNumber, bool isToday)
        {
            var date = new DateTime(_currentDate.Year, _currentDate.Month, dayNumber);

            var label = new Label
            {
                Text = $"{dayName} {dayNumber}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("微软雅黑", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = date  // 存储日期对象
            };

            if (isToday)
            {
                label.BackColor = Color.LightCoral;
                label.ForeColor = Color.Red;
            }

            label.MouseEnter += (s, e) => { if (!isToday) label.ForeColor = Color.Red; };
            label.MouseLeave += (s, e) => { if (!isToday) label.ForeColor = Color.Black; };
            label.Click += DayLabel_Click;

            return label;
        }
        private void DayLabel_Click(object sender, EventArgs e)
        {

            var label = (Label)sender;
            foreach (Control ctrl in weekDaysPanel.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.BackColor = Color.White;
                    lbl.ForeColor = Color.Black;
                }
            }

            label.BackColor = Color.LightCoral;
            label.ForeColor = Color.Red;

            // 获取点击的星期标签对应的日期
            var day = int.Parse(label.Text.Split(' ')[1]);
            var targetDate = new DateTime(_currentDate.Year, _currentDate.Month, day);

            // 确保目标日期的面板已加载
            if (!dateSections.ContainsKey(targetDate))
            {
                // 计算需要加载的天数
                var daysToLoad = Math.Abs((targetDate - _currentStartDate).Days);
                LoadMoreDates(daysToLoad + 3); // 加载更多日期，确保目标日期在范围内
            }


            // 滚动到对应的日期面板
            if (dateSections.TryGetValue(targetDate, out var datePanel))
            {
                // 确保滚动范围已更新
                taskPanel.PerformLayout();

                // 计算目标面板的滚动位置
                var targetTop = datePanel.Top - taskPanel.AutoScrollPosition.Y;
                taskPanel.AutoScrollPosition = new Point(0, targetTop);


            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {


            //var taskForm = new TaskForm(_taskController);
            //taskForm.ShowDialog();
            //LoadTasksForDate(_currentDate);

            var taskForm = new AddOrEditTaskForm(_taskController);
            taskForm.ShowDialog();
            // 确保日期面板存在
            if (!dateSections.ContainsKey(_currentStartDate))
            {
                CreateDateSection(_currentStartDate);
            }
            LoadTasksForDate(_currentStartDate);

            // 滚动到当前日期
            var panel = dateSections[_currentStartDate];
            taskPanel.ScrollControlIntoView(panel);




        }

        private Panel CreateTaskItem(Task task)
        {
            var taskItem = new Panel
            {
                Size = new Size(540, 50),
                BackColor = Color.WhiteSmoke,
                Margin = new Padding(0, 0, 0, 10)
            };

            var checkBox = new CheckBox
            {
                Appearance = Appearance.Button,
                Size = new Size(20, 20),
                Location = new Point(10, 15),
                Checked = task.IsCompleted
            };

            checkBox.CheckedChanged += (s, e) =>
            {
                task.IsCompleted = checkBox.Checked;
                _taskController.UpdateTask(task);
            };

            checkBox.Paint += (s, e) =>
            {
                if (checkBox.Checked)
                {
                    e.Graphics.DrawString("√", new Font("Arial", 12, FontStyle.Bold),
                                        Brushes.Black, new PointF(3, 4));
                }
            };

            taskItem.Controls.Add(checkBox);
            taskItem.Controls.Add(new Label
            {
                Text = $"任务名：{task.Name}",
                Font = new Font("微软雅黑", 9F),
                Location = new Point(40, 10),
                Size = new Size(350, 30)
            });

            taskItem.Controls.Add(new Label
            {
                Text = $"类别：{task.Category}",
                Font = new Font("微软雅黑", 8F),
                BackColor = task.Category.Contains("家庭") ? Color.LightPink : Color.LightBlue,
                Location = new Point(460, 15),
                Padding = new Padding(3, 1, 3, 1)
            });

            return taskItem;
        }



    }
}





