using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Models;
using MaterialSkin.Controls;

namespace TomatoClockApp.Views
{
    public partial class CommunityForm : MaterialForm
    {
        private readonly TaskTemplateController _templateController;
        private readonly int _currentUserId;
        private bool showMyTemplates = false;

        public CommunityForm(TaskTemplateController templateController, int currentUserId)
        {
            _templateController = templateController;
            _currentUserId = currentUserId;
            InitializeComponent();
            // 事件绑定
            cmbSort.SelectedIndexChanged += (s, e) => LoadTemplates();
            btnUpload.Click += BtnUpload_Click;
            btnMyTemplates.Click += (s, e) => { showMyTemplates = true; LoadTemplates(); };
            btnAllTemplates.Click += (s, e) => { showMyTemplates = false; LoadTemplates(); };
            // 初始化模板列表
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            flowPanel.Controls.Clear();
            List<TaskTemplate> templates;
            if (showMyTemplates)
            {
                templates = _templateController.GetUserTemplates(_currentUserId);
            }
            else
            {
                templates = _templateController.GetAllPublicTemplates();
            }

            // 排序
            switch (cmbSort.SelectedItem?.ToString())
            {
                case "最多下载":
                    templates = templates.OrderByDescending(t => t.Downloads).ToList();
                    break;
                case "最多点赞":
                    templates = templates.OrderByDescending(t => t.Likes).ToList();
                    break;
                default:
                    templates = templates.OrderByDescending(t => t.CreatedAt).ToList();
                    break;
            }

            foreach (var template in templates)
            {
                var card = CreateTemplateCard(template);
                flowPanel.Controls.Add(card);
            }
        }

        private Panel CreateTemplateCard(TaskTemplate template)
        {
            var card = new Panel
            {
                Width = 280,
                Height = 180,
                Margin = new Padding(15),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            var lblTitle = new Label
            {
                Text = template.Title,
                Font = new Font("微软雅黑", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            card.Controls.Add(lblTitle);

            var lblCategory = new Label
            {
                Text = $"分类：{template.Category}",
                Location = new Point(10, 40),
                AutoSize = true
            };
            card.Controls.Add(lblCategory);

            var lblAuthor = new Label
            {
                Text = $"作者ID：{template.CreatedByUserId}",
                Location = new Point(10, 65),
                AutoSize = true
            };
            card.Controls.Add(lblAuthor);

            var lblDesc = new Label
            {
                Text = $"描述：{template.Description}",
                Location = new Point(10, 90),
                Size = new Size(250, 40),
                AutoEllipsis = true
            };
            card.Controls.Add(lblDesc);

            var lblStats = new Label
            {
                Text = $"下载：{template.Downloads}  赞：{template.Likes}",
                Location = new Point(10, 135),
                AutoSize = true
            };
            card.Controls.Add(lblStats);

            // 操作按钮
            int btnY = 155;
            int btnX = 10;
            if (!showMyTemplates)
            {
                var btnDownload = new MaterialButton
                {
                    Text = "下载",
                    Location = new Point(btnX, btnY),
                    Width = 60
                };
                btnDownload.Click += (s, e) => { _templateController.DownloadTemplate(template.Id, _currentUserId); MessageBox.Show("已下载到我的任务"); };
                card.Controls.Add(btnDownload);
                btnX += 70;

                var btnLike = new MaterialButton
                {
                    Text = "点赞",
                    Location = new Point(btnX, btnY),
                    Width = 60
                };
                btnLike.Click += (s, e) => { _templateController.LikeTemplate(template.Id); LoadTemplates(); };
                card.Controls.Add(btnLike);
                btnX += 70;
            }
            else
            {
                var btnEdit = new MaterialButton
                {
                    Text = "编辑",
                    Location = new Point(btnX, btnY),
                    Width = 60
                };
                btnEdit.Click += (s, e) =>
                {
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
                };
                card.Controls.Add(btnEdit);
                btnX += 70;

                var btnDelete = new MaterialButton
                {
                    Text = "删除",
                    Location = new Point(btnX, btnY),
                    Width = 60
                };
                btnDelete.Click += (s, e) =>
                {
                    if (MessageBox.Show("确定要删除该模板吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _templateController.DeleteTemplate(template.Id);
                        LoadTemplates();
                    }
                };
                card.Controls.Add(btnDelete);
            }

            return card;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
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
                    showMyTemplates = true;
                    LoadTemplates();
                }
            }
        }
    }
}