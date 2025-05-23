using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Models;
using MaterialSkin.Controls;

namespace TomatoClockApp.Views
{
    public partial class TaskTemplateForm : MaterialForm
    {
        private readonly TaskTemplateController _templateController;
        private readonly int _currentUserId;

        public TaskTemplateForm(TaskTemplateController templateController, int currentUserId)
        {
            InitializeComponent();
            _templateController = templateController;
            _currentUserId = currentUserId;
            LoadTemplates();
        }

        private void InitializeComponent()
        {
            this.Text = "任务模板管理";
            this.Size = new System.Drawing.Size(800, 600);

            // 创建控件
            var dgvTemplates = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            var btnCreate = new MaterialButton
            {
                Text = "创建模板",
                Dock = DockStyle.Bottom
            };

            var btnEdit = new MaterialButton
            {
                Text = "编辑模板",
                Dock = DockStyle.Bottom
            };

            var btnDelete = new MaterialButton
            {
                Text = "删除模板",
                Dock = DockStyle.Bottom
            };

            var btnDownload = new MaterialButton
            {
                Text = "下载模板",
                Dock = DockStyle.Bottom
            };

            // 添加列
            dgvTemplates.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "标题" },
                new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "分类" },
                new DataGridViewTextBoxColumn { Name = "EstimatedPomodoros", HeaderText = "预计番茄数" },
                new DataGridViewTextBoxColumn { Name = "Downloads", HeaderText = "下载次数" },
                new DataGridViewTextBoxColumn { Name = "Likes", HeaderText = "点赞数" },
                new DataGridViewCheckBoxColumn { Name = "IsPublic", HeaderText = "是否公开" }
            });

            // 添加事件处理
            btnCreate.Click += BtnCreate_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnDownload.Click += BtnDownload_Click;

            // 添加控件到窗体
            this.Controls.Add(dgvTemplates);
            this.Controls.Add(btnCreate);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnDownload);
        }

        private void LoadTemplates()
        {
            var templates = _templateController.GetUserTemplates(_currentUserId);
            var dgv = (DataGridView)this.Controls[0];
            dgv.DataSource = templates;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (var form = new TaskTemplateEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var template = new TaskTemplate
                    {
                        Title = form.Title,
                        Description = form.Description,
                        Category = form.Category,
                        EstimatedPomodoros = form.EstimatedPomodoros,
                        IsPublic = form.IsPublic,
                        CreatedByUserId = _currentUserId
                    };

                    _templateController.CreateTemplate(template);
                    LoadTemplates();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var dgv = (DataGridView)this.Controls[0];
            if (dgv.SelectedRows.Count == 0) return;

            var template = (TaskTemplate)dgv.SelectedRows[0].DataBoundItem;
            using (var form = new TaskTemplateEditForm(template))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    template.Title = form.Title;
                    template.Description = form.Description;
                    template.Category = form.Category;
                    template.EstimatedPomodoros = form.EstimatedPomodoros;
                    template.IsPublic = form.IsPublic;

                    _templateController.UpdateTemplate(template);
                    LoadTemplates();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var dgv = (DataGridView)this.Controls[0];
            if (dgv.SelectedRows.Count == 0) return;

            var template = (TaskTemplate)dgv.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("确定要删除这个模板吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _templateController.DeleteTemplate(template.Id);
                LoadTemplates();
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            var dgv = (DataGridView)this.Controls[0];
            if (dgv.SelectedRows.Count == 0) return;

            var template = (TaskTemplate)dgv.SelectedRows[0].DataBoundItem;
            _templateController.DownloadTemplate(template.Id, _currentUserId);
            MessageBox.Show("模板已下载并创建为新任务！");
        }
    }
} 