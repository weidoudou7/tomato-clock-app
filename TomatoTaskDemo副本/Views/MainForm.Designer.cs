
namespace TomatoTaskApp.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            dateTimePicker1 = new DateTimePicker();
            lvTasks = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            btnFindTask = new Button();
            btnAddTask = new Button();
            btnLockScreen = new Button();
            btnStartTimer = new Button();
            btnCommunity = new Button();
            btnStopTimer = new Button();
            btnStatistics = new Button();
            btnPlanTasks = new Button();
            btnCalendar = new Button();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            imageList1 = new ImageList(components);
            editTask = new ToolStripMenuItem();
            contextMenu = new ContextMenuStrip(components);
            deleteTask = new ToolStripMenuItem();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Controls.Add(tabPage5);
            materialTabControl1.Controls.Add(tabPage6);
            materialTabControl1.Depth = 0;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(25, 133);
            materialTabControl1.Margin = new Padding(5, 5, 5, 5);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(2191, 1125);
            materialTabControl1.SizeMode = TabSizeMode.FillToRight;
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dateTimePicker1);
            tabPage1.Controls.Add(lvTasks);
            tabPage1.Controls.Add(btnFindTask);
            tabPage1.Controls.Add(btnAddTask);
            tabPage1.Controls.Add(btnLockScreen);
            tabPage1.Controls.Add(btnStartTimer);
            tabPage1.Controls.Add(btnCommunity);
            tabPage1.Controls.Add(btnStopTimer);
            tabPage1.Controls.Add(btnStatistics);
            tabPage1.Controls.Add(btnPlanTasks);
            tabPage1.Controls.Add(btnCalendar);
            tabPage1.ImageKey = "任务总览.png";
            tabPage1.Location = new Point(10, 56);
            tabPage1.Margin = new Padding(5, 5, 5, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(5, 5, 5, 5);
            tabPage1.Size = new Size(2171, 1059);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "任务总览";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1031, 3);
            dateTimePicker1.Margin = new Padding(5, 5, 5, 5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(488, 46);
            dateTimePicker1.TabIndex = 21;
            // 
            // lvTasks
            // 
            lvTasks.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvTasks.ForeColor = SystemColors.ActiveCaptionText;
            lvTasks.FullRowSelect = true;
            lvTasks.GridLines = true;
            lvTasks.Location = new Point(229, 50);
            lvTasks.Margin = new Padding(10, 9, 10, 9);
            lvTasks.Name = "lvTasks";
            lvTasks.Size = new Size(1701, 761);
            lvTasks.TabIndex = 11;
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
            // btnFindTask
            // 
            btnFindTask.Location = new Point(484, 948);
            btnFindTask.Margin = new Padding(10, 9, 10, 9);
            btnFindTask.Name = "btnFindTask";
            btnFindTask.Size = new Size(236, 94);
            btnFindTask.TabIndex = 20;
            btnFindTask.Text = "查找任务";
            btnFindTask.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(229, 831);
            btnAddTask.Margin = new Padding(10, 9, 10, 9);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(236, 94);
            btnAddTask.TabIndex = 12;
            btnAddTask.Text = "添加任务";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnLockScreen
            // 
            btnLockScreen.Location = new Point(229, 948);
            btnLockScreen.Margin = new Padding(10, 9, 10, 9);
            btnLockScreen.Name = "btnLockScreen";
            btnLockScreen.Size = new Size(236, 94);
            btnLockScreen.TabIndex = 19;
            btnLockScreen.Text = "锁屏";
            btnLockScreen.UseVisualStyleBackColor = true;
            // 
            // btnStartTimer
            // 
            btnStartTimer.Location = new Point(484, 836);
            btnStartTimer.Margin = new Padding(10, 9, 10, 9);
            btnStartTimer.Name = "btnStartTimer";
            btnStartTimer.Size = new Size(236, 94);
            btnStartTimer.TabIndex = 13;
            btnStartTimer.Text = "开始计时";
            btnStartTimer.UseVisualStyleBackColor = true;
            btnStartTimer.Click += btnStartTimer_Click;
            // 
            // btnCommunity
            // 
            btnCommunity.Location = new Point(740, 948);
            btnCommunity.Margin = new Padding(10, 9, 10, 9);
            btnCommunity.Name = "btnCommunity";
            btnCommunity.Size = new Size(236, 94);
            btnCommunity.TabIndex = 18;
            btnCommunity.Text = "社区";
            btnCommunity.UseVisualStyleBackColor = true;
            btnCommunity.Click += btnCommunity_Click;
            // 
            // btnStopTimer
            // 
            btnStopTimer.Location = new Point(740, 831);
            btnStopTimer.Margin = new Padding(10, 9, 10, 9);
            btnStopTimer.Name = "btnStopTimer";
            btnStopTimer.Size = new Size(236, 94);
            btnStopTimer.TabIndex = 14;
            btnStopTimer.Text = "停止计时";
            btnStopTimer.UseVisualStyleBackColor = true;
            // 
            // btnStatistics
            // 
            btnStatistics.Location = new Point(1505, 831);
            btnStatistics.Margin = new Padding(10, 9, 10, 9);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(236, 94);
            btnStatistics.TabIndex = 17;
            btnStatistics.Text = "统计";
            btnStatistics.UseVisualStyleBackColor = true;
            // 
            // btnPlanTasks
            // 
            btnPlanTasks.Location = new Point(995, 831);
            btnPlanTasks.Margin = new Padding(10, 9, 10, 9);
            btnPlanTasks.Name = "btnPlanTasks";
            btnPlanTasks.Size = new Size(236, 94);
            btnPlanTasks.TabIndex = 15;
            btnPlanTasks.Text = "规划任务";
            btnPlanTasks.UseVisualStyleBackColor = true;
            // 
            // btnCalendar
            // 
            btnCalendar.Location = new Point(1250, 831);
            btnCalendar.Margin = new Padding(10, 9, 10, 9);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(236, 94);
            btnCalendar.TabIndex = 16;
            btnCalendar.Text = "日历";
            btnCalendar.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.ImageKey = "日历视图.png";
            tabPage2.Location = new Point(10, 56);
            tabPage2.Margin = new Padding(5, 5, 5, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(5, 5, 5, 5);
            tabPage2.Size = new Size(2171, 1059);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "日历视图";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.ImageKey = "开始专注.png";
            tabPage3.Location = new Point(10, 56);
            tabPage3.Margin = new Padding(5, 5, 5, 5);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(5, 5, 5, 5);
            tabPage3.Size = new Size(2171, 1059);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "开始专注";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.ImageKey = "任务规划.png";
            tabPage4.Location = new Point(10, 56);
            tabPage4.Margin = new Padding(5, 5, 5, 5);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(5, 5, 5, 5);
            tabPage4.Size = new Size(2171, 1059);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "任务规划";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.ImageKey = "社区一览.png";
            tabPage5.Location = new Point(10, 56);
            tabPage5.Margin = new Padding(5, 5, 5, 5);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(5, 5, 5, 5);
            tabPage5.Size = new Size(2171, 1059);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "社区一览";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.ImageKey = "个人主页.png";
            tabPage6.Location = new Point(10, 56);
            tabPage6.Margin = new Padding(5, 5, 5, 5);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(5, 5, 5, 5);
            tabPage6.Size = new Size(2171, 1059);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "个人主页";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "任务总览.png");
            imageList1.Images.SetKeyName(1, "日历视图.png");
            imageList1.Images.SetKeyName(2, "开始专注.png");
            imageList1.Images.SetKeyName(3, "任务规划.png");
            imageList1.Images.SetKeyName(4, "社区一览.png");
            imageList1.Images.SetKeyName(5, "个人主页.png");
            // 
            // editTask
            // 
            editTask.Name = "editTask";
            editTask.Size = new Size(214, 46);
            editTask.Text = "修改任务";
            editTask.Click += EditTask_Click;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(24, 24);
            contextMenu.Items.AddRange(new ToolStripItem[] { editTask, deleteTask });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(215, 96);
            // 
            // deleteTask
            // 
            deleteTask.Name = "deleteTask";
            deleteTask.Size = new Size(214, 46);
            deleteTask.Text = "删除任务";
            deleteTask.Click += DeleteTask_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(2225, 1292);
            Controls.Add(materialTabControl1);
            DrawerAutoShow = true;
            DrawerBackgroundWithAccent = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            DrawerWidth = 150;
            Margin = new Padding(5, 5, 5, 5);
            Name = "MainForm";
            Padding = new Padding(5, 100, 5, 5);
            Text = "Form1";
            Load += Form1_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }



        #endregion
        public MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private DateTimePicker dateTimePicker1;
        private ListView lvTasks;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button btnFindTask;
        private Button btnAddTask;
        private Button btnLockScreen;
        private Button btnStartTimer;
        private Button btnCommunity;
        private Button btnStopTimer;
        private Button btnStatistics;
        private Button btnPlanTasks;
        private Button btnCalendar;
        private ToolStripMenuItem editTask;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem deleteTask;
        private ImageList imageList1;
    }
}