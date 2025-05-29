using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Services;
using TomatoTaskDemo.Views;

namespace TomatoClockApp.Views
{
    public partial class LockScreenForm : Form
    {
        public bool IsModernTheme = false;
        private AppLockConfig config;
        private LockScreenController lockScreenController;
        public LockScreenForm(LockScreenController lockScreenController)
        {
            this.lockScreenController = lockScreenController;
            config = lockScreenController.GetAppLockConfig();
            InitializeComponent();
            
            this.FormClosing += (s, e) => lockScreenController.Unlock();
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            foreach (Control ctrl in GetAllControls(this))
            {
                ctrl.BackColor = Color.FromArgb(45, 45, 48);
                ctrl.ForeColor = Color.White;

                if (ctrl is Button btn)
                {
                    btn.FlatAppearance.BorderColor = Color.SteelBlue;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
                }
            }
        }

        private void ApplyClassicTheme()
        {
            this.BackColor = Color.White;
            foreach (Control ctrl in GetAllControls(this))
            {
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = Color.Black;

                if (ctrl is Button btn)
                {
                    btn.FlatAppearance.BorderColor = Color.Black;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
                }
            }
        }

        private IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(GetAllControls).Concat(controls);
        }

        #region 事件处理
        private void OnCategoryChecked(object sender, EventArgs e)
        {
            lstApps.Items.Clear();
            var selectedCategories = flowCategories.Controls
                .OfType<CheckBox>()
                .Where(c => c.Checked)
                .Select(c => c.Tag.ToString());

            // 默认全选逻辑
            foreach (var category in selectedCategories)
            {
                foreach (var process in AppLockConfig.CategoryProcessMap[category])
                {
                    var isAllowed = config.AllowedProcesses.Contains(process);
                    lstApps.Items.Add(new ListViewItem(GetFriendlyName(process))
                    {
                        Tag = process,
                        Checked = !isAllowed // 反向逻辑：勾选表示需要锁定
                    });
                }
            }
        }

        private void StartLocking(object sender, EventArgs e)
        {
            if (lockScreenController.IsLocked()) { return; }
            MessageBox.Show("锁屏已启动！", "提示",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            lockScreenController.Lock();

        }

        private void StopLocking(object sender, EventArgs e)
        {
            if (!lockScreenController.IsLocked()) return;
            MessageBox.Show("锁屏已停止！", "提示",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            lockScreenController.Unlock();
        }

        private void ChangeStyle(object sender, EventArgs e)
        {
            if (IsModernTheme)
            {
                ApplyClassicTheme();
                IsModernTheme = false;
            }
            else
            {
                ApplyModernTheme();
                IsModernTheme = true;
            }
        }

        private void ShowAddDialog(object sender, EventArgs e)
        {
            using (var dialog = new AddProcessForm(config))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var category = dialog.SelectedCategory();
                    var process = dialog.SelectedProcess;

                    // 动态更新分类映射
                    if (!AppLockConfig.CategoryProcessMap.ContainsKey(category))
                        AppLockConfig.CategoryProcessMap[category] = new HashSet<string>();

                    AppLockConfig.CategoryProcessMap[category].Add(process);

                    // 更新界面
                    if (!flowCategories.Controls.OfType<CheckBox>().Any(c => c.Tag.ToString() == category))
                    {
                        var chk = new CheckBox
                        {
                            Text = category,
                            Tag = category,
                            Checked = true
                        };
                        chk.CheckedChanged += OnCategoryChecked;
                        flowCategories.Controls.Add(chk);
                    }
                }
            }
        }


        private void SaveConfiguration(object sender, EventArgs e)
        {
            // 收集未选中的进程到白名单
            config.AllowedProcesses = lstApps.Items
                .Cast<ListViewItem>()
                .Where(item => !item.Checked)
                .Select(item => item.Tag.ToString())
                .ToHashSet();

            // 收集选中的分类
            config.LockCategories = flowCategories.Controls
                .OfType<CheckBox>()
                .Where(c => c.Checked)
                .Select(c => c.Tag.ToString())
                .ToHashSet();

            //File.WriteAllText("lock_config.json", JsonConvert.SerializeObject(config));
        }
        #endregion

        #region 辅助方法
        

        private string GetFriendlyName(string processName)
        {
            // 实现进程名到友好名称的转换逻辑
            return processName switch
            {
                "chrome" => "Google Chrome",
                "wechat" => "微信",
                "qq" => "QQ",
                _ => processName
            };
        }
        #endregion
    }
}