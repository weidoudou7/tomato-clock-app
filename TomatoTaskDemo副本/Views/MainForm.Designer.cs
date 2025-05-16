namespace TomatoClockApp.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnStartTimer;
        private System.Windows.Forms.Button btnStopTimer;
        private System.Windows.Forms.Button btnPlanTasks;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnCommunity;
        private System.Windows.Forms.Button btnLockScreen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lvTasks = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            contextMenu = new ContextMenuStrip(components);//右键功能菜单
            editTask = new ToolStripMenuItem();
            deleteTask = new ToolStripMenuItem();
            btnAddTask = new Button();
            btnStartTimer = new Button();
            btnStopTimer = new Button();
            btnPlanTasks = new Button();
            btnCalendar = new Button();
            btnStatistics = new Button();
            btnCommunity = new Button();
            btnLockScreen = new Button();
            btnFindTask = new Button();
            dateTimePicker1 = new DateTimePicker();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // lvTasks
            // 
            lvTasks.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvTasks.ForeColor = SystemColors.ActiveCaptionText;
            lvTasks.FullRowSelect = true;
            lvTasks.GridLines = true;
            lvTasks.Location = new Point(22, 25);
            lvTasks.Margin = new Padding(6);
            lvTasks.Name = "lvTasks";
            lvTasks.Size = new Size(1419, 489);
            lvTasks.TabIndex = 0;
            lvTasks.UseCompatibleStateImageBehavior = false;
            lvTasks.View = View.Details;
            lvTasks.SelectedIndexChanged += lvTasks_SelectedIndexChanged;
            lvTasks.MouseUp += LvTasks_MouseUp;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "任务名称";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "截止时间";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "分类";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "状态";
            columnHeader4.Width = 100;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(24, 24);
            contextMenu.Items.AddRange(new ToolStripItem[] { editTask, deleteTask });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(161, 68);
            // 
            // editTask
            // 
            editTask.Name = "editTask";
            editTask.Size = new Size(160, 32);
            editTask.Text = "修改任务";
            editTask.Click += EditTask_Click;
            // 
            // deleteTask
            // 
            deleteTask.Name = "deleteTask";
            deleteTask.Size = new Size(160, 32);
            deleteTask.Text = "删除任务";
            deleteTask.Click += DeleteTask_Click;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(22, 531);
            btnAddTask.Margin = new Padding(6);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(183, 62);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "添加任务";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnStartTimer
            // 
            btnStartTimer.Location = new Point(216, 531);
            btnStartTimer.Margin = new Padding(6);
            btnStartTimer.Name = "btnStartTimer";
            btnStartTimer.Size = new Size(183, 62);
            btnStartTimer.TabIndex = 2;
            btnStartTimer.Text = "开始计时";
            btnStartTimer.UseVisualStyleBackColor = true;
            btnStartTimer.Click += btnStartTimer_Click;
            // 
            // btnStopTimer
            // 
            btnStopTimer.Location = new Point(411, 531);
            btnStopTimer.Margin = new Padding(6);
            btnStopTimer.Name = "btnStopTimer";
            btnStopTimer.Size = new Size(183, 62);
            btnStopTimer.TabIndex = 3;
            btnStopTimer.Text = "停止计时";
            btnStopTimer.UseVisualStyleBackColor = true;
            btnStopTimer.Click += btnStopTimer_Click;
            // 
            // btnPlanTasks
            // 
            btnPlanTasks.Location = new Point(605, 531);
            btnPlanTasks.Margin = new Padding(6);
            btnPlanTasks.Name = "btnPlanTasks";
            btnPlanTasks.Size = new Size(183, 62);
            btnPlanTasks.TabIndex = 4;
            btnPlanTasks.Text = "规划任务";
            btnPlanTasks.UseVisualStyleBackColor = true;
            btnPlanTasks.Click += btnPlanTasks_Click;
            // 
            // btnCalendar
            // 
            btnCalendar.Location = new Point(799, 531);
            btnCalendar.Margin = new Padding(6);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(183, 62);
            btnCalendar.TabIndex = 5;
            btnCalendar.Text = "日历";
            btnCalendar.UseVisualStyleBackColor = true;
            btnCalendar.Click += btnCalendar_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.Location = new Point(994, 531);
            btnStatistics.Margin = new Padding(6);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(183, 62);
            btnStatistics.TabIndex = 6;
            btnStatistics.Text = "统计";
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnCommunity
            // 
            btnCommunity.Location = new Point(1188, 531);
            btnCommunity.Margin = new Padding(6);
            btnCommunity.Name = "btnCommunity";
            btnCommunity.Size = new Size(183, 62);
            btnCommunity.TabIndex = 7;
            btnCommunity.Text = "社区";
            btnCommunity.UseVisualStyleBackColor = true;
            btnCommunity.Click += btnCommunity_Click;
            // 
            // btnLockScreen
            // 
            btnLockScreen.Location = new Point(22, 606);
            btnLockScreen.Margin = new Padding(6);
            btnLockScreen.Name = "btnLockScreen";
            btnLockScreen.Size = new Size(183, 62);
            btnLockScreen.TabIndex = 8;
            btnLockScreen.Text = "锁屏";
            btnLockScreen.UseVisualStyleBackColor = true;
            btnLockScreen.Click += btnLockScreen_Click;
            // 
            // btnFindTask
            // 
            btnFindTask.Location = new Point(217, 606);
            btnFindTask.Margin = new Padding(6);
            btnFindTask.Name = "btnFindTask";
            btnFindTask.Size = new Size(183, 62);
            btnFindTask.TabIndex = 9;
            btnFindTask.Text = "查找任务";
            btnFindTask.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(506, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 32);
            dateTimePicker1.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 694);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnFindTask);
            Controls.Add(btnLockScreen);
            Controls.Add(btnCommunity);
            Controls.Add(btnStatistics);
            Controls.Add(btnCalendar);
            Controls.Add(btnPlanTasks);
            Controls.Add(btnStopTimer);
            Controls.Add(btnStartTimer);
            Controls.Add(btnAddTask);
            Controls.Add(lvTasks);
            Margin = new Padding(6);
            Name = "MainForm";
            Text = "番茄钟应用";
            Load += MainForm_Load;
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Button btnFindTask;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem editTask;
        private ToolStripMenuItem deleteTask;
        private DateTimePicker dateTimePicker1;
    }
}