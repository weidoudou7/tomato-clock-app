namespace TomatoTaskDemo.CustomerControls
{
    partial class TaskControl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblDeadline = new Label();
            lblCategory = new Label();
            btnComp = new Button();
            chkCompleted = new CheckBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Location = new Point(10, 8);
            lblName.Name = "lblName";
            lblName.Size = new Size(67, 25);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.BackColor = Color.Transparent;
            lblDeadline.Location = new Point(10, 47);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(67, 25);
            lblDeadline.TabIndex = 1;
            lblDeadline.Text = "label1";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Location = new Point(131, 36);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(67, 25);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "label1";
            lblCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnComp
            // 
            btnComp.BackColor = Color.Transparent;
            btnComp.Location = new Point(343, 69);
            btnComp.Name = "btnComp";
            btnComp.Size = new Size(94, 38);
            btnComp.TabIndex = 3;
            btnComp.Text = "去完成";
            btnComp.UseVisualStyleBackColor = false;
            btnComp.Click += btnComp_Click;
            // 
            // chkCompleted
            // 
            chkCompleted.AutoCheck = false;
            chkCompleted.AutoSize = true;
            chkCompleted.BackColor = Color.Transparent;
            chkCompleted.Location = new Point(343, 22);
            chkCompleted.Name = "chkCompleted";
            chkCompleted.Size = new Size(22, 21);
            chkCompleted.TabIndex = 4;
            chkCompleted.UseVisualStyleBackColor = false;
            // 
            // TaskControl
            // 
            Controls.Add(chkCompleted);
            Controls.Add(btnComp);
            Controls.Add(lblCategory);
            Controls.Add(lblDeadline);
            Controls.Add(lblName);
            Name = "TaskControl";
            Size = new Size(440, 110);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblDeadline;
        private Label lblCategory;
        private Button btnComp;
        private CheckBox chkCompleted;
    }
}
