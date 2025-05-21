using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TomatoTaskDemo.Views
{
    public partial class SignupForm : Form
    {
        readonly string _connectionString;
        public SignupForm()
        {
            InitializeComponent();
            _connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\app.db";
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
            textPassword.PasswordChar = '*';
            textConfirmPassword.PasswordChar = '*';
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text.Trim();
            string password = textPassword.Text.Trim();
            string confirmPassword = textConfirmPassword.Text.Trim();
            string email = textEmail.Text.Trim();
            
            //验证邮箱有效性
            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            string GetPasswordHash(string password)
            {
                using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return System.BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("请填写所有字段", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("两次输入的密码不一致", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("请输入有效的邮箱地址", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    // 检查用户名是否已存在
                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                    checkCmd.Parameters.AddWithValue("@UserName", username);

                    if ((long)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("用户名已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 插入新用户
                    var insertCmd = connection.CreateCommand();
                    insertCmd.CommandText = @"
                        INSERT INTO Users (UserName, PasswordHash, Email, CreateTime)
                        VALUES (@UserName, @PasswordHash, @Email, CURRENT_TIMESTAMP)
                    ";
                    insertCmd.Parameters.AddWithValue("@UserName", username);
                    insertCmd.Parameters.AddWithValue("@PasswordHash", GetPasswordHash(password));
                    insertCmd.Parameters.AddWithValue("@Email", email);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("注册成功，请登录", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // 关闭注册窗体
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"注册失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
