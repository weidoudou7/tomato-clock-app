using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomatoClockApp.Services;

namespace TomatoTaskDemo.Views
{
    public partial class AddProcessForm : Form
    {
        public string SelectedProcess { get; private set; }
        public AppLockConfig config;

        // 在类级别添加变量
        private List<ListViewItem> _allProcessItems = new List<ListViewItem>();
        public AddProcessForm(AppLockConfig config)
        {
            InitializeComponent();
            LoadRunningProcesses();
            this.StartPosition = FormStartPosition.CenterParent;
            this.config = config;
        }


        public String SelectedCategory()
        {
            return cmbCategory.SelectedItem.ToString();
        }

        private void LoadRunningProcesses()
        {
            try
            {
                var processes = Process.GetProcesses()
                .Where(p => !string.IsNullOrEmpty(p.ProcessName))
                .GroupBy(p => p.ProcessName.ToLower())
                .Select(g => g.First())
                .OrderBy(p => p.ProcessName)  // 增加按名称排序
                .ToList();  // 避免多次枚举

                foreach (var process in processes)
                {
                    // ... 原有创建 item 的代码 ...
                    var item = new ListViewItem(process.ProcessName) { Text = process.ProcessName };
                    _allProcessItems.Add(item);
                }

                // 在加载进程时添加图标
                foreach (var process in processes)
                {
                    try
                    {
                        var icon = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
                        lstProcesses.SmallImageList.Images.Add(icon);

                        var item = new ListViewItem("", lstProcesses.SmallImageList.Images.Count - 1)
                        {
                            Tag = process.ProcessName.ToLower()
                        };
                        item.SubItems.Add(process.ProcessName);
                        item.SubItems.Add(process.MainModule?.FileName ?? "N/A");
                        lstProcesses.Items.Add(item);
                    }
                    catch { /* 异常处理保持不变 */ }
                }

                foreach (var process in processes)
                {
                    try
                    {
                        var item = new ListViewItem(process.ProcessName);
                        item.SubItems.Add(process.MainModule?.FileName ?? "N/A");
                        item.Tag = process.ProcessName.ToLower();
                        lstProcesses.Items.Add(item);
                    }
                    catch (Exception ex) when (
                        ex is System.ComponentModel.Win32Exception ||
                        ex is InvalidOperationException)
                    {
                        // 忽略权限不足的进程
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法加载进程列表：{ex.Message}");
            }
        }

        private void BrowseExecutable(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "可执行文件|*.exe";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                    txtCustom.Text = fileName.ToLower();
                }
            }
        }

        private void SelectProcess()
        {
            if (lstProcesses.SelectedItems.Count > 0)
            {
                var processName = lstProcesses.SelectedItems[0].Tag.ToString();
                txtCustom.Text = processName;
            }
        }

        private void ValidateInput()
        {
            var input = txtCustom.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("请输入有效的进程名称", "输入错误",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 添加进程存在性检查
            bool isProcessRunning = Process.GetProcesses()
                .Any(p => p.ProcessName.ToLower() == input);

            if (!isProcessRunning)
            {
                var dialogResult = MessageBox.Show(
                    "该进程当前未运行，是否继续添加？",
                    "进程未运行",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;
            }

            SelectedProcess = input;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
