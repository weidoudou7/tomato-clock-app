namespace TomatoClockApp.Views
{
    partial class CommunityForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ComboBox cmbSort;
        private MaterialSkin.Controls.MaterialButton btnUpload;
        private MaterialSkin.Controls.MaterialButton btnMyTemplates;
        private MaterialSkin.Controls.MaterialButton btnAllTemplates;

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
            flowPanel = new FlowLayoutPanel();
            cmbSort = new ComboBox();
            btnUpload = new MaterialSkin.Controls.MaterialButton();
            btnMyTemplates = new MaterialSkin.Controls.MaterialButton();
            btnAllTemplates = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // flowPanel
            // 
            flowPanel.AutoScroll = true;
            flowPanel.Location = new Point(20, 140);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(940, 500);
            flowPanel.TabIndex = 4;
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.Items.AddRange(new object[] { "最新", "最多下载", "最多点赞" });
            cmbSort.Location = new Point(20, 100);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(214, 33);
            cmbSort.TabIndex = 0;
            // 
            // btnUpload
            // 
            btnUpload.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpload.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUpload.Depth = 0;
            btnUpload.HighEmphasis = true;
            btnUpload.Icon = null;
            btnUpload.Location = new Point(349, 97);
            btnUpload.Margin = new Padding(4, 6, 4, 6);
            btnUpload.MouseState = MaterialSkin.MouseState.HOVER;
            btnUpload.Name = "btnUpload";
            btnUpload.NoAccentTextColor = Color.Empty;
            btnUpload.Size = new Size(85, 36);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "上传模板";
            btnUpload.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUpload.UseAccentColor = false;
            // 
            // btnMyTemplates
            // 
            btnMyTemplates.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMyTemplates.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMyTemplates.Depth = 0;
            btnMyTemplates.HighEmphasis = true;
            btnMyTemplates.Icon = null;
            btnMyTemplates.Location = new Point(506, 97);
            btnMyTemplates.Margin = new Padding(4, 6, 4, 6);
            btnMyTemplates.MouseState = MaterialSkin.MouseState.HOVER;
            btnMyTemplates.Name = "btnMyTemplates";
            btnMyTemplates.NoAccentTextColor = Color.Empty;
            btnMyTemplates.Size = new Size(85, 36);
            btnMyTemplates.TabIndex = 2;
            btnMyTemplates.Text = "我的模板";
            btnMyTemplates.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMyTemplates.UseAccentColor = false;
            // 
            // btnAllTemplates
            // 
            btnAllTemplates.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAllTemplates.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAllTemplates.Depth = 0;
            btnAllTemplates.HighEmphasis = true;
            btnAllTemplates.Icon = null;
            btnAllTemplates.Location = new Point(657, 97);
            btnAllTemplates.Margin = new Padding(4, 6, 4, 6);
            btnAllTemplates.MouseState = MaterialSkin.MouseState.HOVER;
            btnAllTemplates.Name = "btnAllTemplates";
            btnAllTemplates.NoAccentTextColor = Color.Empty;
            btnAllTemplates.Size = new Size(85, 36);
            btnAllTemplates.TabIndex = 3;
            btnAllTemplates.Text = "全部模板";
            btnAllTemplates.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAllTemplates.UseAccentColor = false;
            // 
            // CommunityForm
            // 
            ClientSize = new Size(1000, 700);
            Controls.Add(cmbSort);
            Controls.Add(btnUpload);
            Controls.Add(btnMyTemplates);
            Controls.Add(btnAllTemplates);
            Controls.Add(flowPanel);
            Name = "CommunityForm";
            Text = "社区任务模板";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}