

//namespace TomatoClockApp.Views
//{
//    partial class CalendarForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private Label lblMonthYear;
//        private Label lblToday;
//        private TableLayoutPanel weekDaysPanel;
//        private FlowLayoutPanel taskPanel;
//        private Button btnAddTask;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && components != null)
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            // Month Year Label
//            lblMonthYear = new Label
//            {
//                AutoSize = true,
//                Font = new Font("微软雅黑", 14F, FontStyle.Bold),
//                Location = new Point(50, 20),  // Moved right from 20 to 50
//                Name = "lblMonthYear"
//            };

//            // Today Label
//            lblToday = new Label
//            {
//                AutoSize = true,
//                Font = new Font("微软雅黑", 10F),
//                ForeColor = Color.Gray,
//                Location = new Point(250, 25),  // Moved right from 180 to 250
//                Name = "lblToday",
//                Text = "今天"
//            };

//            // Week Days Panel
//            weekDaysPanel = new TableLayoutPanel
//            {
//                ColumnCount = 7,
//                Location = new Point(50, 60),  // Moved right from 20 to 50
//                Name = "weekDaysPanel",
//                Size = new Size(700, 50)       // Reduced width from 760 to 700 to maintain right margin
//            };
//            for (int i = 0; i < 7; i++)
//                weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));

//            // Task Panel
//            taskPanel = new FlowLayoutPanel
//            {
//                AutoScroll = true,
//                FlowDirection = FlowDirection.TopDown,
//                Location = new Point(50, 130),  // Moved right from 20 to 50
//                Name = "taskPanel",
//                Padding = new Padding(10),
//                Size = new Size(700, 400),      // Reduced width from 760 to 700 to maintain right margin
//                WrapContents = false
//            };

//            // Add Task Button
//            btnAddTask = new Button
//            {
//                BackColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Font = new Font("微软雅黑", 10F),
//                ForeColor = Color.DodgerBlue,
//                Location = new Point(50, 550),  // Moved right from 20 to 50
//                Name = "btnAddTask",
//                Size = new Size(120, 35),
//                Text = "添加任务",
//                UseVisualStyleBackColor = false
//            };
//            btnAddTask.FlatAppearance.BorderColor = Color.DodgerBlue;
//            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

//            // Form
//            AutoScaleDimensions = new SizeF(6F, 12F);
//            AutoScaleMode = AutoScaleMode.Font;
//            BackColor = Color.White;
//            ClientSize = new Size(800, 600);
//            Controls.AddRange(new Control[] { lblMonthYear, lblToday, weekDaysPanel, taskPanel, btnAddTask });
//            Name = "CalendarForm";
//            Text = "日历";
//        }
//    }
//}

//namespace TomatoClockApp.Views
//{
//    partial class CalendarForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private Label lblMonthYear;
//        private Label lblToday;
//        private TableLayoutPanel weekDaysPanel;
//        private FlowLayoutPanel taskPanel;
//        private Button btnAddTask;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && components != null)
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            // Month Year Label (Original: 20,20 → Now: 70,0)
//            lblMonthYear = new Label
//            {
//                AutoSize = true,
//                Font = new Font("微软雅黑", 14F, FontStyle.Bold),
//                Location = new Point(70, 0),    // Right +50, Up -20
//                Name = "lblMonthYear"
//            };

//            // Today Label (Original: 180,25 → Now: 230,5)
//            lblToday = new Label
//            {
//                AutoSize = true,
//                Font = new Font("微软雅黑", 10F),
//                ForeColor = Color.Gray,
//                Location = new Point(230, 5),   // Right +50, Up -20
//                Name = "lblToday",
//                Text = "今天"
//            };

//            // Week Days Panel (Original: 20,60 → Now: 70,40)
//            weekDaysPanel = new TableLayoutPanel
//            {
//                ColumnCount = 7,
//                Location = new Point(70, 40),  // Right +50, Up -20
//                Name = "weekDaysPanel",
//                Size = new Size(700, 50)        // Width reduced to maintain margins
//            };

//            // Task Panel (Original: 20,130 → Now: 70,110)
//            taskPanel = new FlowLayoutPanel
//            {
//                AutoScroll = true,
//                FlowDirection = FlowDirection.TopDown,
//                Location = new Point(70, 110),  // Right +50, Up -20
//                Name = "taskPanel",
//                Padding = new Padding(10),
//                Size = new Size(700, 430),      // Height increased to utilize extra vertical space
//                WrapContents = false
//            };

//            // Add Task Button (Original: 20,550 → Now: 70,530)
//            //btnAddTask = new Button
//            //{
//            //    BackColor = Color.White,
//            //    FlatStyle = FlatStyle.Flat,
//            //    Font = new Font("微软雅黑", 10F),
//            //    ForeColor = Color.DodgerBlue,
//            //    Location = new Point(70, 530),  // Right +50, Up -20
//            //    Name = "btnAddTask",
//            //    Size = new Size(120, 35),
//            //    Text = "添加任务",
//            //    UseVisualStyleBackColor = false
//            //};
//            //btnAddTask.FlatAppearance.BorderColor = Color.DodgerBlue;
//            //this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

//            // Form Settings
//            AutoScaleDimensions = new SizeF(6F, 12F);
//            AutoScaleMode = AutoScaleMode.Font;
//            BackColor = Color.White;
//            ClientSize = new Size(800, 600);
//            Controls.AddRange(new Control[] { lblMonthYear, lblToday, weekDaysPanel, taskPanel, btnAddTask });
//            Name = "CalendarForm";
//            Text = "日历";
//            Padding = new Padding(0, 0, 30, 30); // Added padding to prevent controls from touching edges
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
            // Month Year Label - Adjusted for new size
            lblMonthYear = new Label
            {
                AutoSize = true,
                Font = new Font("微软雅黑", 14F, FontStyle.Bold),
                Location = new Point(30, 10),    // Adjusted position
                Name = "lblMonthYear"
            };

            // Today Label - Adjusted for new size
            lblToday = new Label
            {
                AutoSize = true,
                Font = new Font("微软雅黑", 10F),
                ForeColor = Color.Gray,
                Location = new Point(190, 15),   // Adjusted position
                Name = "lblToday",
                Text = "今天"
            };

            // Week Days Panel - Adjusted for new size
            weekDaysPanel = new TableLayoutPanel
            {
                ColumnCount = 7,
                Location = new Point(30, 50),    // Adjusted position
                Name = "weekDaysPanel",
                Size = new Size(860, 40),        // Adjusted size (900 - 40 padding)
                ColumnStyles = {
                    new ColumnStyle(SizeType.Percent, 14.28f),
                    new ColumnStyle(SizeType.Percent, 14.28f),
                    new ColumnStyle(SizeType.Percent, 14.28f),
                    new ColumnStyle(SizeType.Percent, 14.28f),
                    new ColumnStyle(SizeType.Percent, 14.28f),
                    new ColumnStyle(SizeType.Percent, 14.28f),
                    new ColumnStyle(SizeType.Percent, 14.28f)
                }
            };

            // Task Panel - Adjusted for new size
            taskPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                Location = new Point(30, 100),   // Adjusted position
                Name = "taskPanel",
                Padding = new Padding(10),
                Size = new Size(870, 350),       // Adjusted size (480 - 130 vertical space)
                WrapContents = false
            };

            // Add Task Button - Adjusted for new size
            btnAddTask = new Button
            {
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("微软雅黑", 10F),
                ForeColor = Color.DodgerBlue,
                Location = new Point(30, 460),   // Adjusted position
                Name = "btnAddTask",
                Size = new Size(150, 35),
                Text = "添加任务",
                UseVisualStyleBackColor = false
            };
            btnAddTask.FlatAppearance.BorderColor = Color.DodgerBlue;

            // Form Settings
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(910, 480);     // Set to required size
            Controls.AddRange(new Control[] { lblMonthYear, lblToday, weekDaysPanel, taskPanel, btnAddTask });
            Name = "CalendarForm";
            Text = "日历";
            Padding = new Padding(20);           // Added padding to prevent controls from touching edges
        }
    }
} 