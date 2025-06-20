﻿namespace TomatoTaskDemo.Services
{
    partial class BeginTaskForm
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
            panel1 = new FlowLayoutPanel();
            countUp = new RadioButton();
            countDown = new RadioButton();
            downTime = new DateTimePicker();
            btnStart = new Button();
            panel2 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(60, 0, 0, 0);
            panel1.Size = new Size(697, 881);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // countUp
            // 
            countUp.AutoSize = true;
            countUp.Location = new Point(802, 293);
            countUp.Name = "countUp";
            countUp.Size = new Size(94, 29);
            countUp.TabIndex = 2;
            countUp.TabStop = true;
            countUp.Text = "正计时";
            countUp.UseVisualStyleBackColor = true;
            countUp.CheckedChanged += countUp_CheckedChanged;
            // 
            // countDown
            // 
            countDown.AutoSize = true;
            countDown.Location = new Point(1101, 293);
            countDown.Name = "countDown";
            countDown.Size = new Size(94, 29);
            countDown.TabIndex = 3;
            countDown.TabStop = true;
            countDown.Text = "倒计时";
            countDown.UseVisualStyleBackColor = true;
            countDown.CheckedChanged += countDown_CheckedChanged;
            // 
            // downTime
            // 
            downTime.CustomFormat = "HH:mm:ss";
            downTime.Format = DateTimePickerFormat.Time;
            downTime.Location = new Point(1045, 385);
            downTime.Name = "downTime";
            downTime.ShowUpDown = true;
            downTime.Size = new Size(300, 32);
            downTime.TabIndex = 4;
            downTime.Value = new DateTime(2025, 5, 19, 0, 0, 0, 0);
            downTime.Visible = false;
            downTime.ValueChanged += downTime_ValueChanged;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(948, 496);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(204, 74);
            btnStart.TabIndex = 5;
            btnStart.Text = "开始计时";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(792, 38);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 20, 0);
            panel2.Size = new Size(600, 188);
            panel2.TabIndex = 6;
            // 
            // BeginTaskForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1462, 881);
            Controls.Add(panel2);
            Controls.Add(btnStart);
            Controls.Add(downTime);
            Controls.Add(countDown);
            Controls.Add(countUp);
            Controls.Add(panel1);
            Name = "BeginTaskForm";
            Text = "BeginTask";
            Load += BeginTaskForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panel1;
        private RadioButton countUp;
        private RadioButton countDown;
        private DateTimePicker downTime;
        private Button btnStart;
        private FlowLayoutPanel panel2;
    }
}