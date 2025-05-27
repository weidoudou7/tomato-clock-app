using TomatoClockApp.Services;

namespace TomatoClockApp.Views
{
    partial class LockScreenForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnUnlock;

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
            // 基础窗体设置
            this.Text = "应用锁定管理器";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("微软雅黑", 9F);

            // 主表格布局（2列）
            tableLayoutPanel1 = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                RowCount = 1,
                Padding = new Padding(60,0,0,0),
                BackColor = Color.FromArgb(45, 45, 48)
            };
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

            // 左侧 - 分类选择区
            InitializeCategoryPanel();

            // 右侧 - 应用列表区
            InitializeAppListPanel();

            // 底部操作栏
            InitializeActionPanel();

            // 添加主控件
            this.Controls.Add(tableLayoutPanel1);
            this.Controls.Add(pnlActions);

            // 应用主题
            ApplyClassicTheme();
        }

        private void InitializeCategoryPanel()
        {
            grpCategories = new GroupBox
            {
                Text = "选择锁定类型",
                Dock = DockStyle.Fill,
                ForeColor = Color.SteelBlue
            };

            flowCategories = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            foreach (var category in AppLockConfig.CategoryProcessMap.Keys)
            {
                var chk = new CheckBox
                {
                    Text = category,
                    Tag = category,
                    Margin = new Padding(5),
                    AutoSize = true,
                    Checked = config.LockCategories.Contains(category)
                };
                chk.CheckedChanged += OnCategoryChecked;
                flowCategories.Controls.Add(chk);
            }

            grpCategories.Controls.Add(flowCategories);
            tableLayoutPanel1.Controls.Add(grpCategories, 0, 0);
        }

        private void InitializeAppListPanel()
        {
            grpApplications = new GroupBox
            {
                Text = "选择具体应用",
                Dock = DockStyle.Fill,
                ForeColor = Color.SteelBlue
            };

            lstApps = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                CheckBoxes = true,
                MultiSelect = true,
                FullRowSelect = true,
                BackColor = Color.FromArgb(37, 37, 38),
                ForeColor = Color.White
            };

            lstApps.Columns.Add("应用名称", 150);
            lstApps.Columns.Add("进程标识", 200);

            grpApplications.Controls.Add(lstApps);
            tableLayoutPanel1.Controls.Add(grpApplications, 1, 0);
        }

        private void InitializeActionPanel()
        {
            pnlActions = new Panel
            {
                Padding = new Padding(60,0,0,0),
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(60, 60, 60)
            };

            // 操作按钮布局
            var buttonLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10, 5, 10, 5)
            };

            btnAddCustom = new Button
            {
                Text = "添加应用",
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White
            };
            btnAddCustom.Click += ShowAddDialog;

            btnSave = new Button
            {
                Text = "保存配置",
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White
            };
            btnSave.Click += SaveConfiguration;

            btnStart = new Button
            {
                Text = "开始锁屏",
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White
            };
            btnStart.Click += StartLocking;

            btnStop = new Button
            {
                Text = "停止锁屏",
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                //Enabled = false
            };
            btnStop.Click += StopLocking;

            btnStyle = new Button
            {
                Dock = DockStyle.Right,
                Text = "切换主题",
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White
            };
            btnStyle.Click += ChangeStyle;

            buttonLayout.Controls.AddRange(new Control[] {
                btnAddCustom, btnSave, btnStart, btnStop, btnStyle
            });
            pnlActions.Controls.Add(buttonLayout);
        }

        // 控件声明
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox grpCategories;
        private FlowLayoutPanel flowCategories;
        private GroupBox grpApplications;
        private ListView lstApps;
        private Panel pnlActions;
        private Button btnAddCustom;
        private Button btnSave;
        private Button btnStart;
        private Button btnStop;
        private  Button btnStyle;

    }
}