namespace TomatoTaskDemo.Views
{
    partial class SignupForm
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
            label1 = new Label();
            textUserName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textPassword = new TextBox();
            textConfirmPassword = new TextBox();
            buttonRegister = new Button();
            textEmail = new TextBox();
            label4 = new Label();
            ReturnToLogin_label = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(286, 171);
            label1.Name = "label1";
            label1.Size = new Size(137, 39);
            label1.TabIndex = 0;
            label1.Text = "用户名：";
            // 
            // textUserName
            // 
            textUserName.Location = new Point(429, 171);
            textUserName.Name = "textUserName";
            textUserName.Size = new Size(250, 46);
            textUserName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 256);
            label2.Name = "label2";
            label2.Size = new Size(107, 39);
            label2.TabIndex = 2;
            label2.Text = "密码：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 334);
            label3.Name = "label3";
            label3.Size = new Size(167, 39);
            label3.TabIndex = 3;
            label3.Text = "确认密码：";
            // 
            // textPassword
            // 
            textPassword.Location = new Point(429, 256);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(250, 46);
            textPassword.TabIndex = 4;
            // 
            // textConfirmPassword
            // 
            textConfirmPassword.Location = new Point(429, 334);
            textConfirmPassword.Name = "textConfirmPassword";
            textConfirmPassword.Size = new Size(250, 46);
            textConfirmPassword.TabIndex = 5;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(451, 523);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(188, 58);
            buttonRegister.TabIndex = 6;
            buttonRegister.Text = "注册";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(429, 428);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(250, 46);
            textEmail.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(316, 435);
            label4.Name = "label4";
            label4.Size = new Size(107, 39);
            label4.TabIndex = 8;
            label4.Text = "邮箱：";
            // 
            // ReturnToLogin_label
            // 
            ReturnToLogin_label.AutoSize = true;
            ReturnToLogin_label.Cursor = Cursors.Hand;
            ReturnToLogin_label.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold | FontStyle.Underline);
            ReturnToLogin_label.ForeColor = SystemColors.Highlight;
            ReturnToLogin_label.Location = new Point(451, 625);
            ReturnToLogin_label.Name = "ReturnToLogin_label";
            ReturnToLogin_label.Size = new Size(197, 40);
            ReturnToLogin_label.TabIndex = 9;
            ReturnToLogin_label.Text = "返回登录界面";
            ReturnToLogin_label.Click += returnToLogin_Click;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(18F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 849);
            Controls.Add(ReturnToLogin_label);
            Controls.Add(label4);
            Controls.Add(textEmail);
            Controls.Add(buttonRegister);
            Controls.Add(textConfirmPassword);
            Controls.Add(textPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textUserName);
            Controls.Add(label1);
            Name = "SignupForm";
            Text = "SignupForm";
            Load += SignupForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textUserName;
        private Label label2;
        private Label label3;
        private TextBox textPassword;
        private TextBox textConfirmPassword;
        private Button buttonRegister;
        private TextBox textEmail;
        private Label label4;
        private Label ReturnToLogin_label;
    }
}