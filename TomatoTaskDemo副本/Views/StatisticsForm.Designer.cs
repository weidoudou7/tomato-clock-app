namespace TomatoClockApp.Views
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotalTasks;
        private System.Windows.Forms.Label lblCompletedTasks;
        private System.Windows.Forms.Label lblCompletionRate;

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
            this.lblTotalTasks = new System.Windows.Forms.Label();
            this.lblCompletedTasks = new System.Windows.Forms.Label();
            this.lblCompletionRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotalTasks
            // 
            this.lblTotalTasks.AutoSize = true;
            this.lblTotalTasks.Location = new System.Drawing.Point(12, 9);
            this.lblTotalTasks.Name = "lblTotalTasks";
            this.lblTotalTasks.Size = new System.Drawing.Size(65, 12);
            this.lblTotalTasks.TabIndex = 0;
            this.lblTotalTasks.Text = "总任务数:";
            // 
            // lblCompletedTasks
            // 
            this.lblCompletedTasks.AutoSize = true;
            this.lblCompletedTasks.Location = new System.Drawing.Point(12, 36);
            this.lblCompletedTasks.Name = "lblCompletedTasks";
            this.lblCompletedTasks.Size = new System.Drawing.Size(89, 12);
            this.lblCompletedTasks.TabIndex = 1;
            this.lblCompletedTasks.Text = "已完成任务数:";
            // 
            // lblCompletionRate
            // 
            this.lblCompletionRate.AutoSize = true;
            this.lblCompletionRate.Location = new System.Drawing.Point(12, 63);
            this.lblCompletionRate.Name = "lblCompletionRate";
            this.lblCompletionRate.Size = new System.Drawing.Size(41, 12);
            this.lblCompletionRate.TabIndex = 2;
            this.lblCompletionRate.Text = "完成率:";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.lblCompletionRate);
            this.Controls.Add(this.lblCompletedTasks);
            this.Controls.Add(this.lblTotalTasks);
            this.Name = "StatisticsForm";
            this.Text = "统计视图";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}