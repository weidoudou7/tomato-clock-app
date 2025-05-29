namespace TomatoTaskDemo.Views
{
    partial class AddProcessForm
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
            // 窗体基本设置
            this.Text = "添加应用程序";
            this.Size = new Size(500, 400);
            this.Font = new Font("微软雅黑", 9F);
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;

            // 主布局容器
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                Padding = new Padding(10)
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            // 进程列表
            lstProcesses = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                Columns = {
                    new ColumnHeader() { Text = "进程名称", Width = 150 },
                    new ColumnHeader() { Text = "文件路径", Width = 250 }
                },
                BackColor = Color.FromArgb(37, 37, 38),
                ForeColor = Color.White
            };
            lstProcesses.SmallImageList = new ImageList();
            lstProcesses.Columns.Add(new ColumnHeader() { Text = "图标", Width = 40 });


            lstProcesses.MouseDoubleClick += (s, e) => { SelectProcess(); ValidateInput(); };
            mainLayout.Controls.Add(lstProcesses, 0, 0);

            // 手动输入区
            var inputPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 40
            };

            txtCustom = new TextBox
            {
                PlaceholderText = "输入或选择可执行文件...",
                Size = new Size(300, 30),
                Location = new Point(0, 5),
                BackColor = Color.FromArgb(65, 65, 70),
                ForeColor = Color.White
            };

            btnBrowse = new Button
            {
                Text = "浏览...",
                Size = new Size(80, 30),
                Location = new Point(310, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White
            };
            btnBrowse.Click += BrowseExecutable;

            inputPanel.Controls.Add(txtCustom);
            inputPanel.Controls.Add(btnBrowse);
            mainLayout.Controls.Add(inputPanel, 0, 1);

            // 按钮区
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 5, 0, 0),
                AutoSize = true
            };

            btnOK = new Button
            {
                Text = "确定",
                DialogResult = DialogResult.OK,
                Size = new Size(80, 30),
                Location = new Point(300, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White
            };
            btnOK.Click += (s, e) => ValidateInput();

            btnCancel = new Button
            {
                Text = "取消",
                DialogResult = DialogResult.Cancel,
                Size = new Size(80, 30),
                Location = new Point(390, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White
            };

            buttonPanel.Controls.Add(btnOK);
            buttonPanel.Controls.Add(btnCancel);
            mainLayout.Controls.Add(buttonPanel, 0, 2);

            btnOK.MinimumSize = new Size(90, 32);
            btnCancel.MinimumSize = new Size(90, 32);
            buttonPanel.Controls.AddRange(new[] { btnCancel, btnOK });

            cmbCategory = new ComboBox();
            cmbCategory.Items.Add("社交");
            cmbCategory.Items.Add("音乐");
            cmbCategory.Items.Add("视频");
            cmbCategory.Items.Add("游戏");
            cmbCategory.Items.Add("其他");
            cmbCategory.SelectedItem = cmbCategory.Items[0];

            var searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(5)
            };
            searchPanel.Controls.Add(cmbCategory);
            mainLayout.Controls.Add(searchPanel);


            this.Controls.Add(mainLayout);

        }

        #endregion

        // 控件声明
        private ListView lstProcesses;
        private TextBox txtCustom;
        private Button btnBrowse;
        private Button btnOK;
        private Button btnCancel;
        private ComboBox cmbCategory;
    }
}