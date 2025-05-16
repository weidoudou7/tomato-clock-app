using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;

namespace TomatoClockApp.Views
{
    public partial class LockScreenForm : Form
    {
        private LockScreenController lockScreenController;

        public LockScreenForm(LockScreenController lockScreenController)
        {
            InitializeComponent();
            this.lockScreenController = lockScreenController;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (lockScreenController.Unlock(txtPassword.Text))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }
    }
}