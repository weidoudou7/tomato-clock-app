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
            lblTime.Font = new Font("Ink Free", 39.9999962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.ForeColor = SystemColors.ControlDarkDark;
            lblTime.Location = new Point(12, 118);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(403, 174);
            lblTime.TabIndex = 0;
            lblTime.Text = "00:00:00";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnChangeTime);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(lblTime);
            splitContainer1.Panel1MinSize = 325;
            // 
            // splitContainer1.Panel2
            // 
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
            // lblTotalTime
            // 
            lblTotalTime.Font = new Font("Microsoft YaHei UI", 15F);
            lblTotalTime.Location = new Point(37, 253);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(345, 55);
            lblTotalTime.TabIndex = 2;
            lblTotalTime.Text = "总用时:0";
            lblTotalTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(261, 118);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(121, 57);
            btnStop.TabIndex = 1;
            btnStop.Text = "停止计时";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(30, 118);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(129, 57);
            btnStart.TabIndex = 0;
            btnStart.Text = "开始计时";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // TimerForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 450);
            Controls.Add(splitContainer1);
            Name = "TimerForm";
            Text = "TimerForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblTime;
        private Label lblTotalTime;
        private Button btnStop;
        private Button btnStart;
        private Panel panel1;
        private Button btnChangeTime;


    }
}