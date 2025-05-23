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
        private DataGridView dgvTemplates;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private MaterialButton btnCreate;
        private MaterialButton btnEdit;
        private MaterialButton btnDelete;
        private MaterialButton btnDownload;
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
            dgvTemplates = new DataGridView();
            btnCreate = new MaterialButton();
            btnEdit = new MaterialButton();
            btnDelete = new MaterialButton();
            btnDownload = new MaterialButton();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).BeginInit();
            SuspendLayout();
            // 
            // dgvTemplates
            // 
            dgvTemplates.ColumnHeadersHeight = 58;
            dgvTemplates.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewCheckBoxColumn1 });
            dgvTemplates.Location = new Point(31, 78);
            dgvTemplates.Name = "dgvTemplates";
            dgvTemplates.RowHeadersWidth = 102;
            dgvTemplates.Size = new Size(143, 136);
            dgvTemplates.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCreate.Density = MaterialButton.MaterialButtonDensity.Default;
            btnCreate.Depth = 0;
            btnCreate.HighEmphasis = true;
            btnCreate.Icon = null;
            btnCreate.Location = new Point(0, 0);
            btnCreate.Margin = new Padding(4, 6, 4, 6);
            btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnCreate.Name = "btnCreate";
            btnCreate.NoAccentTextColor = Color.Empty;
            btnCreate.Size = new Size(64, 36);
            btnCreate.TabIndex = 1;
            btnCreate.Type = MaterialButton.MaterialButtonType.Contained;
            btnCreate.UseAccentColor = false;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEdit.Density = MaterialButton.MaterialButtonDensity.Default;
            btnEdit.Depth = 0;
            btnEdit.HighEmphasis = true;
            btnEdit.Icon = null;
            btnEdit.Location = new Point(0, 0);
            btnEdit.Margin = new Padding(4, 6, 4, 6);
            btnEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnEdit.Name = "btnEdit";
            btnEdit.NoAccentTextColor = Color.Empty;
            btnEdit.Size = new Size(64, 36);
            btnEdit.TabIndex = 2;
            btnEdit.Type = MaterialButton.MaterialButtonType.Contained;
            btnEdit.UseAccentColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDelete.Density = MaterialButton.MaterialButtonDensity.Default;
            btnDelete.Depth = 0;
            btnDelete.HighEmphasis = true;
            btnDelete.Icon = null;
            btnDelete.Location = new Point(0, 0);
            btnDelete.Margin = new Padding(4, 6, 4, 6);
            btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            btnDelete.Name = "btnDelete";
            btnDelete.NoAccentTextColor = Color.Empty;
            btnDelete.Size = new Size(64, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Type = MaterialButton.MaterialButtonType.Contained;
            btnDelete.UseAccentColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnDownload
            // 
            btnDownload.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDownload.Density = MaterialButton.MaterialButtonDensity.Default;
            btnDownload.Depth = 0;
            btnDownload.HighEmphasis = true;
            btnDownload.Icon = null;
            btnDownload.Location = new Point(0, 0);
            btnDownload.Margin = new Padding(4, 6, 4, 6);
            btnDownload.MouseState = MaterialSkin.MouseState.HOVER;
            btnDownload.Name = "btnDownload";
            btnDownload.NoAccentTextColor = Color.Empty;
            btnDownload.Size = new Size(64, 36);
            btnDownload.TabIndex = 4;
            btnDownload.Type = MaterialButton.MaterialButtonType.Contained;
            btnDownload.UseAccentColor = false;
            btnDownload.Click += BtnDownload_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 12;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 12;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 12;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 12;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 12;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 250;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.MinimumWidth = 12;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 250;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.MinimumWidth = 12;
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Width = 250;
            // 
            // TaskTemplateForm
            // 
            ClientSize = new Size(1464, 822);
            Controls.Add(dgvTemplates);
            Controls.Add(btnCreate);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnDownload);
            Name = "TaskTemplateForm";
            Text = "任务模板管理";
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).EndInit();
            ResumeLayout(false);
            PerformLayout();
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