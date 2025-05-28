//namespace TomatoClockApp.Views
//{
//    partial class CalendarForm
//    {


//        private System.ComponentModel.IContainer components = null;

//        // 定义所有控件
//        private Label lblMonthYear;
//        private Label lblToday;
//        private TableLayoutPanel weekDaysPanel;
//        private FlowLayoutPanel taskPanel;
//        private Button btnAddTask;


//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            lblMonthYear = new Label();
//            lblToday = new Label();
//            weekDaysPanel = new TableLayoutPanel();
//            taskPanel = new FlowLayoutPanel();
//            btnAddTask = new Button();
//            SuspendLayout();
//            // 
//            // lblMonthYear
//            // 
//            lblMonthYear.AutoSize = true;
//            lblMonthYear.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
//            lblMonthYear.Location = new Point(68, 41);
//            lblMonthYear.Margin = new Padding(6, 0, 6, 0);
//            lblMonthYear.Name = "lblMonthYear";
//            lblMonthYear.Size = new Size(0, 37);
//            lblMonthYear.TabIndex = 0;
//            // 
//            // lblToday
//            // 
//            lblToday.AutoSize = true;
//            lblToday.Font = new Font("微软雅黑", 10F);
//            lblToday.ForeColor = Color.Gray;
//            lblToday.Location = new Point(449, 51);
//            lblToday.Margin = new Padding(6, 0, 6, 0);
//            lblToday.Name = "lblToday";
//            lblToday.Size = new Size(52, 27);
//            lblToday.TabIndex = 1;
//            lblToday.Text = "今天";
//            // 
//            // weekDaysPanel
//            // 
//            weekDaysPanel.ColumnCount = 7;
//            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
//            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
//            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
//            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
//            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
//            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
//            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
//            weekDaysPanel.Location = new Point(68, 124);
//            weekDaysPanel.Margin = new Padding(6);
//            weekDaysPanel.Name = "weekDaysPanel";
//            weekDaysPanel.RowCount = 1;
//            weekDaysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
//            weekDaysPanel.Size = new Size(1027, 83);
//            weekDaysPanel.TabIndex = 2;
//            weekDaysPanel.Paint += weekDaysPanel_Paint;
//            // 
//            // taskPanel
//            // 
//            taskPanel.AutoScroll = true;
//            taskPanel.FlowDirection = FlowDirection.TopDown;
//            taskPanel.Location = new Point(68, 249);
//            taskPanel.Margin = new Padding(6);
//            taskPanel.Name = "taskPanel";
//            taskPanel.Padding = new Padding(18, 21, 18, 21);
//            taskPanel.Size = new Size(1027, 833);
//            taskPanel.TabIndex = 3;
//            taskPanel.WrapContents = false;
//            taskPanel.Paint += taskPanel_Paint;
//            // 
//            // btnAddTask
//            // 
//            btnAddTask.BackColor = Color.White;
//            btnAddTask.FlatAppearance.BorderColor = Color.DodgerBlue;
//            btnAddTask.FlatStyle = FlatStyle.Flat;
//            btnAddTask.Font = new Font("微软雅黑", 10F);
//            btnAddTask.ForeColor = Color.DodgerBlue;
//            btnAddTask.Location = new Point(68, 1103);
//            btnAddTask.Margin = new Padding(6);
//            btnAddTask.Name = "btnAddTask";
//            btnAddTask.Size = new Size(183, 62);
//            btnAddTask.TabIndex = 4;
//            btnAddTask.Text = "添加任务";
//            btnAddTask.UseVisualStyleBackColor = false;
//            btnAddTask.Click += btnAddTask_Click;
//            // 
//            // CalendarForm
//            // 
//            AutoScaleDimensions = new SizeF(11F, 25F);
//            AutoScaleMode = AutoScaleMode.Font;
//            BackColor = Color.White;
//            ClientSize = new Size(1100, 1050);
//            Controls.Add(lblMonthYear);
//            Controls.Add(lblToday);
//            Controls.Add(weekDaysPanel);
//            Controls.Add(taskPanel);
//            Controls.Add(btnAddTask);
//            Margin = new Padding(6);
//            Name = "CalendarForm";
//            Text = "日历";
//            ResumeLayout(false);
//            PerformLayout();
//        }

//    }
//}


namespace TomatoClockApp.Views
{
    partial class CalendarForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMonthYear;
        private Label lblToday;
        private TableLayoutPanel weekDaysPanel;
        private FlowLayoutPanel taskPanel;
        private Button btnAddTask;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {


            // Month Year Label
            lblMonthYear = new Label
            {
                AutoSize = true,
                Font = new Font("微软雅黑", 14F, FontStyle.Bold),
                Location = new Point(20, 20),
                Name = "lblMonthYear"
            };

            // Today Label
            lblToday = new Label
            {
                AutoSize = true,
                Font = new Font("微软雅黑", 10F),
                ForeColor = Color.Gray,
                Location = new Point(180, 25),
                Name = "lblToday",
                Text = "今天"
            };

            // Week Days Panel
            weekDaysPanel = new TableLayoutPanel
            {
                ColumnCount = 7,
                Location = new Point(20, 60),
                Name = "weekDaysPanel",
                Size = new Size(560, 40)
            };
            for (int i = 0; i < 7; i++)
                weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));

            // Task Panel
            taskPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                Location = new Point(20, 120),
                Name = "taskPanel",
                Padding = new Padding(10),
                Size = new Size(560, 400),
                WrapContents = false
            };

            // Add Task Button
            btnAddTask = new Button
            {
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("微软雅黑", 10F),
                ForeColor = Color.DodgerBlue,
                Location = new Point(20, 530),
                Name = "btnAddTask",
                Size = new Size(100, 30),
                Text = "添加任务",
                UseVisualStyleBackColor = false
            };
            btnAddTask.FlatAppearance.BorderColor = Color.DodgerBlue;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            // Form
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(650, 580);
            Controls.AddRange(new Control[] { lblMonthYear, lblToday, weekDaysPanel, taskPanel, btnAddTask });
            Name = "CalendarForm";
            Text = "日历";
        }
    }
}