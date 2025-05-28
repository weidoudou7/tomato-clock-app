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
            lblMonthYear = new Label();
            lblToday = new Label();
            weekDaysPanel = new TableLayoutPanel();
            taskPanel = new FlowLayoutPanel();
            button1 = new Button();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            cmbSort = new ComboBox();
            btnUpload = new MaterialSkin.Controls.MaterialButton();
            btnMyTemplates = new MaterialSkin.Controls.MaterialButton();
            btnAllTemplates = new MaterialSkin.Controls.MaterialButton();
            flowPanel = new FlowLayoutPanel();
            tabPage6 = new TabPage();
            imageList1 = new ImageList(components);
            editTask = new ToolStripMenuItem();
            contextMenu = new ContextMenuStrip(components);
            deleteTask = new ToolStripMenuItem();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage5.SuspendLayout();
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
            materialTabControl1.Location = new Point(15, 85);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1401, 830);
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
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1393, 792);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "任务总览";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(630, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 32);
            dateTimePicker1.TabIndex = 21;
            // 
            // lvTasks
            // 
            lvTasks.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvTasks.ForeColor = SystemColors.ActiveCaptionText;
            lvTasks.FullRowSelect = true;
            lvTasks.GridLines = true;
            lvTasks.Location = new Point(140, 32);
            lvTasks.Margin = new Padding(6);
            lvTasks.Name = "lvTasks";
            lvTasks.Size = new Size(1041, 466);
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
            btnFindTask.Location = new Point(298, 582);
            btnFindTask.Margin = new Padding(6);
            btnFindTask.Name = "btnFindTask";
            btnFindTask.Size = new Size(144, 60);
            btnFindTask.TabIndex = 20;
            btnFindTask.Text = "查找任务";
            btnFindTask.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(142, 507);
            btnAddTask.Margin = new Padding(6);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(144, 60);
            btnAddTask.TabIndex = 12;
            btnAddTask.Text = "添加任务";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnLockScreen
            // 
            btnLockScreen.Location = new Point(142, 582);
            btnLockScreen.Margin = new Padding(6);
            btnLockScreen.Name = "btnLockScreen";
            btnLockScreen.Size = new Size(144, 60);
            btnLockScreen.TabIndex = 19;
            btnLockScreen.Text = "锁屏";
            btnLockScreen.UseVisualStyleBackColor = true;
            btnLockScreen.Click += btnLockScreen_Click;
            // 
            // btnStartTimer
            // 
            btnStartTimer.Location = new Point(298, 510);
            btnStartTimer.Margin = new Padding(6);
            btnStartTimer.Name = "btnStartTimer";
            btnStartTimer.Size = new Size(144, 60);
            btnStartTimer.TabIndex = 13;
            btnStartTimer.Text = "开始计时";
            btnStartTimer.UseVisualStyleBackColor = true;
            btnStartTimer.Click += btnStartTimer_Click;
            // 
            // btnCommunity
            // 
            btnCommunity.Location = new Point(454, 582);
            btnCommunity.Margin = new Padding(6);
            btnCommunity.Name = "btnCommunity";
            btnCommunity.Size = new Size(144, 60);
            btnCommunity.TabIndex = 18;
            btnCommunity.Text = "社区";
            btnCommunity.UseVisualStyleBackColor = true;
            btnCommunity.Click += btnCommunity_Click;
            // 
            // btnStopTimer
            // 
            btnStopTimer.Location = new Point(454, 507);
            btnStopTimer.Margin = new Padding(6);
            btnStopTimer.Name = "btnStopTimer";
            btnStopTimer.Size = new Size(144, 60);
            btnStopTimer.TabIndex = 14;
            btnStopTimer.Text = "停止计时";
            btnStopTimer.UseVisualStyleBackColor = true;
            // 
            // btnStatistics
            // 
            btnStatistics.Location = new Point(922, 507);
            btnStatistics.Margin = new Padding(6);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(144, 60);
            btnStatistics.TabIndex = 17;
            btnStatistics.Text = "统计";
            btnStatistics.UseVisualStyleBackColor = true;
            // 
            // btnPlanTasks
            // 
            btnPlanTasks.Location = new Point(610, 507);
            btnPlanTasks.Margin = new Padding(6);
            btnPlanTasks.Name = "btnPlanTasks";
            btnPlanTasks.Size = new Size(144, 60);
            btnPlanTasks.TabIndex = 15;
            btnPlanTasks.Text = "规划任务";
            btnPlanTasks.UseVisualStyleBackColor = true;
            // 
            // btnCalendar
            // 
            btnCalendar.Location = new Point(766, 507);
            btnCalendar.Margin = new Padding(6);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(144, 60);
            btnCalendar.TabIndex = 16;
            btnCalendar.Text = "日历";
            btnCalendar.UseVisualStyleBackColor = true;
            btnCalendar.Click += btnCalendar_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lblMonthYear);
            tabPage2.Controls.Add(lblToday);
            tabPage2.Controls.Add(weekDaysPanel);
            tabPage2.Controls.Add(taskPanel);
            tabPage2.Controls.Add(button1);
            tabPage2.ImageKey = "日历视图.png";
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1393, 792);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "日历视图";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblMonthYear
            // 
            lblMonthYear.AutoSize = true;
            lblMonthYear.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
            lblMonthYear.Location = new Point(31, -74);
            lblMonthYear.Margin = new Padding(6, 0, 6, 0);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(0, 37);
            lblMonthYear.TabIndex = 5;
            // 
            // lblToday
            // 
            lblToday.AutoSize = true;
            lblToday.Font = new Font("微软雅黑", 10F);
            lblToday.ForeColor = Color.Gray;
            lblToday.Location = new Point(269, -64);
            lblToday.Margin = new Padding(6, 0, 6, 0);
            lblToday.Name = "lblToday";
            lblToday.Size = new Size(52, 27);
            lblToday.TabIndex = 6;
            lblToday.Text = "今天";
            // 
            // weekDaysPanel
            // 
            weekDaysPanel.ColumnCount = 7;
            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            weekDaysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            weekDaysPanel.Location = new Point(31, 9);
            weekDaysPanel.Margin = new Padding(6);
            weekDaysPanel.Name = "weekDaysPanel";
            weekDaysPanel.RowCount = 1;
            weekDaysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            weekDaysPanel.Size = new Size(1027, 83);
            weekDaysPanel.TabIndex = 7;
            // 
            // taskPanel
            // 
            taskPanel.AutoScroll = true;
            taskPanel.FlowDirection = FlowDirection.TopDown;
            taskPanel.Location = new Point(31, 104);
            taskPanel.Margin = new Padding(6);
            taskPanel.Name = "taskPanel";
            taskPanel.Padding = new Padding(18, 21, 18, 21);
            taskPanel.Size = new Size(1027, 543);
            taskPanel.TabIndex = 8;
            taskPanel.WrapContents = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("微软雅黑", 10F);
            button1.ForeColor = Color.DodgerBlue;
            button1.Location = new Point(31, 988);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(183, 62);
            button1.TabIndex = 9;
            button1.Text = "添加任务";
            button1.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            tabPage3.ImageKey = "开始专注.png";
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1393, 792);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "开始专注";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.ImageKey = "任务规划.png";
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1393, 792);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "任务规划";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(cmbSort);
            tabPage5.Controls.Add(btnUpload);
            tabPage5.Controls.Add(btnMyTemplates);
            tabPage5.Controls.Add(btnAllTemplates);
            tabPage5.Controls.Add(flowPanel);
            tabPage5.ImageKey = "社区一览.png";
            tabPage5.Location = new Point(4, 34);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1393, 792);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "社区一览";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.Items.AddRange(new object[] { "最新", "最多下载", "最多点赞" });
            cmbSort.Location = new Point(90, 14);
            cmbSort.Margin = new Padding(2);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(308, 33);
            cmbSort.TabIndex = 5;
            // 
            // btnUpload
            // 
            btnUpload.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpload.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUpload.Depth = 0;
            btnUpload.HighEmphasis = true;
            btnUpload.Icon = null;
            btnUpload.Location = new Point(436, 14);
            btnUpload.Margin = new Padding(2, 4, 2, 4);
            btnUpload.MouseState = MaterialSkin.MouseState.HOVER;
            btnUpload.Name = "btnUpload";
            btnUpload.NoAccentTextColor = Color.Empty;
            btnUpload.Size = new Size(85, 36);
            btnUpload.TabIndex = 6;
            btnUpload.Text = "上传模板";
            btnUpload.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUpload.UseAccentColor = false;
            // 
            // btnMyTemplates
            // 
            btnMyTemplates.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMyTemplates.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMyTemplates.Depth = 0;
            btnMyTemplates.HighEmphasis = true;
            btnMyTemplates.Icon = null;
            btnMyTemplates.Location = new Point(580, 14);
            btnMyTemplates.Margin = new Padding(2, 4, 2, 4);
            btnMyTemplates.MouseState = MaterialSkin.MouseState.HOVER;
            btnMyTemplates.Name = "btnMyTemplates";
            btnMyTemplates.NoAccentTextColor = Color.Empty;
            btnMyTemplates.Size = new Size(85, 36);
            btnMyTemplates.TabIndex = 7;
            btnMyTemplates.Text = "我的模板";
            btnMyTemplates.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMyTemplates.UseAccentColor = false;
            // 
            // btnAllTemplates
            // 
            btnAllTemplates.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAllTemplates.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAllTemplates.Depth = 0;
            btnAllTemplates.HighEmphasis = true;
            btnAllTemplates.Icon = null;
            btnAllTemplates.Location = new Point(728, 14);
            btnAllTemplates.Margin = new Padding(2, 4, 2, 4);
            btnAllTemplates.MouseState = MaterialSkin.MouseState.HOVER;
            btnAllTemplates.Name = "btnAllTemplates";
            btnAllTemplates.NoAccentTextColor = Color.Empty;
            btnAllTemplates.Size = new Size(85, 36);
            btnAllTemplates.TabIndex = 8;
            btnAllTemplates.Text = "全部模板";
            btnAllTemplates.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAllTemplates.UseAccentColor = false;
            // 
            // flowPanel
            // 
            flowPanel.AutoScroll = true;
            flowPanel.Location = new Point(90, 40);
            flowPanel.Margin = new Padding(2);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(1163, 565);
            flowPanel.TabIndex = 9;
            // 
            // tabPage6
            // 
            tabPage6.ImageKey = "个人主页.png";
            tabPage6.Location = new Point(4, 34);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1393, 792);
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
            editTask.Size = new Size(160, 32);
            editTask.Text = "修改任务";
            editTask.Click += EditTask_Click;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(24, 24);
            contextMenu.Items.AddRange(new ToolStripItem[] { editTask, deleteTask });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(161, 68);
            // 
            // deleteTask
            // 
            deleteTask.Name = "deleteTask";
            deleteTask.Size = new Size(160, 32);
            deleteTask.Text = "删除任务";
            deleteTask.Click += DeleteTask_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(1422, 921);
            Controls.Add(materialTabControl1);
            DrawerAutoShow = true;
            DrawerBackgroundWithAccent = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            DrawerWidth = 150;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "番茄时钟";
            Load += Form1_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
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
        private ComboBox cmbSort;
        private MaterialSkin.Controls.MaterialButton btnUpload;
        private MaterialSkin.Controls.MaterialButton btnMyTemplates;
        private MaterialSkin.Controls.MaterialButton btnAllTemplates;
        private FlowLayoutPanel flowPanel;
        private Label lblMonthYear;
        private Label lblToday;
        private TableLayoutPanel weekDaysPanel;
        private FlowLayoutPanel taskPanel;
        private Button button1;
    }
}