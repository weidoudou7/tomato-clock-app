using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;

namespace TomatoClockApp.Views
{
    public partial class CommunityForm : Form
    {
        private CommunityController communityController;

        public CommunityForm(CommunityController communityController)
        {
            InitializeComponent();
            this.communityController = communityController;
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            communityController.Post(txtPost.Text);
            MessageBox.Show("帖子发布成功！");
            txtPost.Clear();
        }
    }
}