namespace TomatoClockApp.Views
{
    partial class AddOrEditTaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblDeadline;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblIsCompleted;
        private System.Windows.Forms.CheckBox chkIsCompleted;
        private System.Windows.Forms.Button btnAddTask;

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
            this.lblTaskName = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblDeadline = new System.Windows.Forms.Label();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblIsCompleted = new System.Windows.Forms.Label();
            this.chkIsCompleted = new System.Windows.Forms.CheckBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(12, 9);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(53, 12);
            this.lblTaskName.TabIndex = 0;
            this.lblTaskName.Text = "任务名称";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(71, 6);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(200, 21);
            this.txtTaskName.TabIndex = 1;
            // 
            // lblDeadline
            // 
            this.lblDeadline.AutoSize = true;
            this.lblDeadline.Location = new System.Drawing.Point(12, 36);
            this.lblDeadline.Name = "lblDeadline";
            this.lblDeadline.Size = new System.Drawing.Size(53, 12);
            this.lblDeadline.TabIndex = 2;
            this.lblDeadline.Text = "截止时间";
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.Location = new System.Drawing.Point(71, 33);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(200, 21);
            this.dtpDeadline.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 63);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(29, 12);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "分类";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(71, 60);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(200, 21);
            this.txtCategory.TabIndex = 5;
            // 
            // lblIsCompleted
            // 
            this.lblIsCompleted.AutoSize = true;
            this.lblIsCompleted.Location = new System.Drawing.Point(12, 90);
            this.lblIsCompleted.Name = "lblIsCompleted";
            this.lblIsCompleted.Size = new System.Drawing.Size(41, 12);
            this.lblIsCompleted.TabIndex = 6;
            this.lblIsCompleted.Text = "状态";
            // 
            // chkIsCompleted
            // 
            this.chkIsCompleted.AutoSize = true;
            this.chkIsCompleted.Location = new System.Drawing.Point(71, 90);
            this.chkIsCompleted.Name = "chkIsCompleted";
            this.chkIsCompleted.Size = new System.Drawing.Size(72, 16);
            this.chkIsCompleted.TabIndex = 7;
            this.chkIsCompleted.Text = "已完成";
            this.chkIsCompleted.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(12, 117);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(259, 30);
            this.btnAddTask.TabIndex = 8;
            this.btnAddTask.Text = "保存任务";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddOrEditTask_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 159);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.chkIsCompleted);
            this.Controls.Add(this.lblIsCompleted);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.lblDeadline);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblTaskName);
            this.Name = "TaskForm";
            this.Text = "任务编辑";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}