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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(827, 180);
            label1.Name = "label1";
            label1.Size = new Size(272, 40);
            label1.TabIndex = 0;
            label1.Text = "欢迎使用ToDoList";
            // 
            // UserNameBox
            // 
            UserNameBox.Location = new Point(827, 284);
            UserNameBox.Name = "UserNameBox";
            UserNameBox.Size = new Size(304, 46);
            UserNameBox.TabIndex = 1;
            UserNameBox.Enter += UserNameBox_Enter;
            UserNameBox.Leave += UserNameBox_Leave;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(827, 406);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(304, 46);
            PasswordBox.TabIndex = 2;
            PasswordBox.Enter += PasswordBox_Enter;
            PasswordBox.Leave += PasswordBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(695, 289);
            label2.Name = "label2";
            label2.Size = new Size(137, 39);
            label2.TabIndex = 3;
            label2.Text = "用户名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(695, 406);
            label3.Name = "label3";
            label3.Size = new Size(107, 39);
            label3.TabIndex = 4;
            label3.Text = "密码：";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(827, 516);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(188, 58);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(18F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1417, 974);
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
    }
    }