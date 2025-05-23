namespace todolist登录界面
{
    partial class LoginForm
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
            UserNameBox = new TextBox();
            PasswordBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnLogin = new Button();
            checkBoxPassword = new CheckBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(193, 103);
            label1.Name = "label1";
            label1.Size = new Size(272, 40);
            label1.TabIndex = 0;
            label1.Text = "欢迎使用ToDoList";
            // 
            // UserNameBox
            // 
            UserNameBox.Location = new Point(193, 212);
            UserNameBox.Name = "UserNameBox";
            UserNameBox.Size = new Size(304, 46);
            UserNameBox.TabIndex = 1;
            UserNameBox.Enter += UserNameBox_Enter;
            UserNameBox.Leave += UserNameBox_Leave;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(193, 329);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(304, 46);
            PasswordBox.TabIndex = 2;
            PasswordBox.Enter += PasswordBox_Enter;
            PasswordBox.Leave += PasswordBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 212);
            label2.Name = "label2";
            label2.Size = new Size(137, 39);
            label2.TabIndex = 3;
            label2.Text = "用户名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 330);
            label3.Name = "label3";
            label3.Size = new Size(107, 39);
            label3.TabIndex = 4;
            label3.Text = "密码：";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(193, 439);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(304, 63);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // checkBoxPassword
            // 
            checkBoxPassword.AutoSize = true;
            checkBoxPassword.Location = new Point(518, 330);
            checkBoxPassword.Name = "checkBoxPassword";
            checkBoxPassword.Size = new Size(205, 43);
            checkBoxPassword.TabIndex = 6;
            checkBoxPassword.Text = "显示密码？";
            checkBoxPassword.UseVisualStyleBackColor = true;
            checkBoxPassword.CheckedChanged += checkBoxPassword_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold | FontStyle.Underline);
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(206, 555);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(287, 40);
            label4.TabIndex = 7;
            label4.Text = "没有账户？点击注册";
            label4.Click += label4_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(18F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 796);
            Controls.Add(label4);
            Controls.Add(checkBoxPassword);
            Controls.Add(btnLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PasswordBox);
            Controls.Add(UserNameBox);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox UserNameBox;
        private TextBox PasswordBox;
        private Label label2;
        private Label label3;
        private Button btnLogin;
        private CheckBox checkBoxPassword;
        private Label label4;
    }
    }