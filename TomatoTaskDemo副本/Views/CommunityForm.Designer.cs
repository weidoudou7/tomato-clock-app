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
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnUpload = new MaterialSkin.Controls.MaterialButton();
            this.btnMyTemplates = new MaterialSkin.Controls.MaterialButton();
            this.btnAllTemplates = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // flowPanel
            // 
            this.flowPanel.Location = new System.Drawing.Point(20, 140);
            this.flowPanel.Size = new System.Drawing.Size(940, 500);
            this.flowPanel.AutoScroll = true;
            this.flowPanel.WrapContents = true;
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Location = new System.Drawing.Point(20, 100);
            this.cmbSort.Width = 150;
            this.cmbSort.Items.AddRange(new object[] { "最新", "最多下载", "最多点赞" });
            this.cmbSort.SelectedIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Text = "上传模板";
            this.btnUpload.Location = new System.Drawing.Point(200, 95);
            this.btnUpload.Width = 100;
            // 
            // btnMyTemplates
            // 
            this.btnMyTemplates.Text = "我的模板";
            this.btnMyTemplates.Location = new System.Drawing.Point(320, 95);
            this.btnMyTemplates.Width = 100;
            // 
            // btnAllTemplates
            // 
            this.btnAllTemplates.Text = "全部模板";
            this.btnAllTemplates.Location = new System.Drawing.Point(440, 95);
            this.btnAllTemplates.Width = 100;
            // 
            // CommunityForm
            // 
            this.Text = "社区任务模板";
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnMyTemplates);
            this.Controls.Add(this.btnAllTemplates);
            this.Controls.Add(this.flowPanel);
            this.ResumeLayout(false);
        }
    }
}