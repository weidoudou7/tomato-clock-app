namespace TomatoTaskDemo.CustomerControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblDeadline = new System.Windows.Forms.Label();
            this.btnComp = new System.Windows.Forms.Button();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("华文彩云", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(10, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(93, 29);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // lblDeadline
            // 
            this.lblDeadline.AutoSize = true;
            this.lblDeadline.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadline.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadline.Location = new System.Drawing.Point(10, 69);
            this.lblDeadline.Name = "lblDeadline";
            this.lblDeadline.Size = new System.Drawing.Size(71, 24);
            this.lblDeadline.TabIndex = 1;
            this.lblDeadline.Text = "label1";
            // 
            // btnComp
            // 
            this.btnComp.BackColor = System.Drawing.Color.Transparent;
            this.btnComp.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnComp.Location = new System.Drawing.Point(331, 26);
            this.btnComp.Name = "btnComp";
            this.btnComp.Size = new System.Drawing.Size(94, 38);
            this.btnComp.TabIndex = 3;
            this.btnComp.Text = "去完成";
            this.btnComp.UseVisualStyleBackColor = false;
            this.btnComp.Click += new System.EventHandler(this.btnComp_Click);
            // 
            // chkCompleted
            // 
            this.chkCompleted.AutoCheck = false;
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.BackColor = System.Drawing.Color.Transparent;
            this.chkCompleted.Location = new System.Drawing.Point(228, 36);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(22, 21);
            this.chkCompleted.TabIndex = 4;
            this.chkCompleted.UseVisualStyleBackColor = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Location = new System.Drawing.Point(131, 36);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 18);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "label1";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaskControl
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkCompleted);
            this.Controls.Add(this.btnComp);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDeadline);
            this.Controls.Add(this.lblName);
            this.Name = "TaskControl";
            this.Size = new System.Drawing.Size(440, 110);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblDeadline;
        private Button btnComp;
        private CheckBox chkCompleted;
        private Label lblCategory;
    }
}
