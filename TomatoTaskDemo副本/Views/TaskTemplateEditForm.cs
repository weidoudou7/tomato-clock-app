using System;
using System.Windows.Forms;
using TomatoClockApp.Models;
using MaterialSkin.Controls;

namespace TomatoClockApp.Views
{
    public partial class TaskTemplateEditForm : MaterialForm
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public int EstimatedPomodoros { get; private set; }
        public bool IsPublic { get; private set; }

        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtCategory;
        private TextBox txtEstimatedPomodoros;
        private MaterialCheckbox chkIsPublic;
        private MaterialButton btnSave;
        private MaterialButton btnCancel;

        public TaskTemplateEditForm(TaskTemplate template = null)
        {
            InitializeComponent();
            if (template != null)
            {
                txtTitle.Text = template.Title;
                txtDescription.Text = template.Description;
                txtCategory.Text = template.Category;
                txtEstimatedPomodoros.Text = template.EstimatedPomodoros.ToString();
                chkIsPublic.Checked = template.IsPublic;
            }
        }

        private void InitializeComponent()
        {
            this.Text = "编辑任务模板";
            this.Size = new System.Drawing.Size(400, 500);

            // 创建控件
            var lblTitle = new Label { Text = "标题", Dock = DockStyle.Top, Margin = new Padding(10, 10, 10, 0) };
            txtTitle = new TextBox
            {
                Dock = DockStyle.Top,
                Margin = new Padding(10, 0, 10, 10)
            };

            var lblDescription = new Label { Text = "描述", Dock = DockStyle.Top, Margin = new Padding(10, 10, 10, 0) };
            txtDescription = new TextBox
            {
                Dock = DockStyle.Top,
                Margin = new Padding(10, 0, 10, 10),
                Multiline = true,
                Height = 100
            };

            var lblCategory = new Label { Text = "分类", Dock = DockStyle.Top, Margin = new Padding(10, 10, 10, 0) };
            txtCategory = new TextBox
            {
                Dock = DockStyle.Top,
                Margin = new Padding(10, 0, 10, 10)
            };

            var lblEstimatedPomodoros = new Label { Text = "预计番茄数", Dock = DockStyle.Top, Margin = new Padding(10, 10, 10, 0) };
            txtEstimatedPomodoros = new TextBox
            {
                Dock = DockStyle.Top,
                Margin = new Padding(10, 0, 10, 10)
            };

            chkIsPublic = new MaterialCheckbox
            {
                Text = "公开模板",
                Dock = DockStyle.Top,
                Margin = new Padding(10)
            };

            btnSave = new MaterialButton
            {
                Text = "保存",
                Dock = DockStyle.Bottom,
                Margin = new Padding(10)
            };

            btnCancel = new MaterialButton
            {
                Text = "取消",
                Dock = DockStyle.Bottom,
                Margin = new Padding(10)
            };

            // 添加事件处理
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            // 添加控件到窗体
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            this.Controls.Add(lblCategory);
            this.Controls.Add(txtCategory);
            this.Controls.Add(lblEstimatedPomodoros);
            this.Controls.Add(txtEstimatedPomodoros);
            this.Controls.Add(chkIsPublic);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("请输入标题");
                return;
            }

            if (!int.TryParse(txtEstimatedPomodoros.Text, out int pomodoros))
            {
                MessageBox.Show("请输入有效的番茄数");
                return;
            }

            Title = txtTitle.Text;
            Description = txtDescription.Text;
            Category = txtCategory.Text;
            EstimatedPomodoros = pomodoros;
            IsPublic = chkIsPublic.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
} 