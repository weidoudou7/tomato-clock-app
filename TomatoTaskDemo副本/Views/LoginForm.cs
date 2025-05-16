using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomatoClockApp.Views;
using Microsoft.Data.Sqlite;
namespace todolist登录界面
{
    public partial class LoginForm : Form
    {
        private string usernamePlaceholder = "请输入用户名";
        private string passwordPlaceholder = "请输入密码";
        private readonly string _connectionString; // 数据库连接字符串
        public LoginForm()
        {
            InitializeComponent();
            Console.WriteLine($"实际连接路径: {_connectionString}");
            // 配置连接字符串
            _connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\app.db";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // 初始化提示文本
            SetPlaceholder(UserNameBox, usernamePlaceholder);
            SetPlaceholder(PasswordBox, passwordPlaceholder);
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray; // 提示文本使用灰色
        }

        private void UserNameBox_Enter(object sender, EventArgs e)
        {
            ClearPlaceholder((TextBox)sender, usernamePlaceholder);
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            ClearPlaceholder((TextBox)sender, passwordPlaceholder);
        }

        private void ClearPlaceholder(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black; // 输入文本使用黑色
            }
        }

        private void UserNameBox_Leave(object sender, EventArgs e)
        {
            RestorePlaceholder((TextBox)sender, usernamePlaceholder);
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            RestorePlaceholder((TextBox)sender, passwordPlaceholder);
        }

        private void RestorePlaceholder(TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;
            }
        }
        //密码的哈希方法加密
        private string GetPasswordHash(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return System.BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = UserNameBox.Text.Trim(); 
            string password = PasswordBox.Text.Trim(); 

            // 输入不合规
            if (string.IsNullOrEmpty(username) || username == usernamePlaceholder || string.IsNullOrEmpty(password)|| password == passwordPlaceholder)
            {
                MessageBox.Show("请填写用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 连接数据库并查询
            using (var connection = new SqliteConnection(_connectionString))
            {
                try
                {
                    connection.Open(); // 打开数据库连接
                    string query = "SELECT * FROM Users WHERE UserName = @Username AND PasswordHash = @PasswordHash";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", GetPasswordHash(password)); // 哈希方法

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // 登录成功，跳转到主界面
                                MainForm mainForm = new MainForm();
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("用户名或密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqliteException ex)
                {
                    MessageBox.Show($"SQLite 错误: {ex.SqliteErrorCode}\n{ex.Message}");
                    Console.WriteLine(ex.StackTrace); // 输出完整堆栈信息
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"登录异常：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
    }



}
