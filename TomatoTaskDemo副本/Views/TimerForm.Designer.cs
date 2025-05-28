namespace TomatoTaskDemo.Views
{
    partial class TimerForm
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
            lblTime = new Label();
            splitContainer1 = new SplitContainer();
            btnChangeTime = new Button();
            panel1 = new Panel();
            btnReset = new Button();
            cyclePanel = new FlowLayoutPanel();
            lblTotalTime = new Label();
            btnStop = new Button();
            btnStart = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Font = new Font("Monotype Corsiva", 48F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(70, 70, 70);
            lblTime.Location = new Point(15, 110);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(403, 174);
            lblTime.TabIndex = 0;
            lblTime.Text = "00:00:00";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.MouseDown += lblTime_MouseDown;
            lblTime.MouseUp += lblTime_MouseUp;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(btnChangeTime);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(lblTime);
            splitContainer1.Panel1MinSize = 325;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(250, 250, 250);
            splitContainer1.Panel2.Controls.Add(btnReset);
            splitContainer1.Panel2.Controls.Add(cyclePanel);
            splitContainer1.Panel2.Controls.Add(lblTotalTime);
            splitContainer1.Panel2.Controls.Add(btnStop);
            splitContainer1.Panel2.Controls.Add(btnStart);
            splitContainer1.Size = new Size(960, 450);
            splitContainer1.SplitterDistance = 440;
            splitContainer1.TabIndex = 0;
            // 
            // btnChangeTime
            // 
            btnChangeTime.Location = new Point(116, 11);
            btnChangeTime.Name = "btnChangeTime";
            btnChangeTime.Size = new Size(141, 31);
            btnChangeTime.TabIndex = 2;
            btnChangeTime.Text = "切换为模拟钟";
            btnChangeTime.UseVisualStyleBackColor = true;
            btnChangeTime.Click += btnChangeTime_Click;
            // 
            // panel1
            // 
            panel1.ForeColor = SystemColors.GrayText;
            panel1.Location = new Point(15, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 400);
            panel1.TabIndex = 1;
            panel1.Visible = false;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(47, 311);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 4;
            btnReset.Text = "重置";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // cyclePanel
            // 
            cyclePanel.BackColor = Color.Transparent;
            cyclePanel.Dock = DockStyle.Top;
            cyclePanel.Location = new Point(0, 0);
            cyclePanel.Name = "cyclePanel";
            cyclePanel.Size = new Size(516, 64);
            cyclePanel.TabIndex = 3;
            // 
            // lblTotalTime
            // 
            lblTotalTime.Font = new Font("Microsoft YaHei UI", 15F);
            lblTotalTime.Location = new Point(47, 230);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(345, 55);
            lblTotalTime.TabIndex = 2;
            lblTotalTime.Text = "总用时:0";
            lblTotalTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(180, 180, 180);
            btnStop.Cursor = Cursors.Hand;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 12F);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(255, 137);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(137, 74);
            btnStop.TabIndex = 1;
            btnStop.Text = "停止计时";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(230, 80, 80);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 12F);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(47, 137);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(143, 74);
            btnStart.TabIndex = 0;
            btnStart.Text = "开始计时";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // TimerForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(960, 450);
            Controls.Add(splitContainer1);
            Name = "TimerForm";
            Text = "TimerForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            AddDot();
            InitializeTimeDisplay();
        }

        #endregion

        private void AddDot()
        {
            for (int i = 0; i < 4; i++)
            {
                var dot = new Label
                {
                    Size = new Size(12, 12),
                    Margin = new Padding(5),
                    BackColor = Color.FromArgb(220, 220, 220),
                    Tag = i,
                    Dock = DockStyle.Top
                };
                cyclePanel.Controls.Add(dot);
            }
        }

        private void InitializeTimeDisplay()
        {
            // 日期显示
            var lblDate = new Label
            {
                Text = DateTime.Now.ToString("yyyy年M月d日 dddd"),
                Font = new Font("Microsoft YaHei", 9),
                ForeColor = Color.Gray,
                Dock = DockStyle.Bottom
            };
            cyclePanel.Controls.Add(lblDate);
        }

        private SplitContainer splitContainer1;
        private Label lblTime;
        private Label lblTotalTime;
        private Button btnStop;
        private Button btnStart;
        private Panel panel1;
        private Button btnChangeTime;
        private FlowLayoutPanel cyclePanel;
        private Button btnReset;
    }
}