using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoTaskDemo.CustomerControls;


namespace TomatoTaskDemo.Views
{
    public partial class TimerForm : Form
    {
        private System.Timers.Timer timer;
        ClockControl clockContorl;
        private TimerController timerController;

        // 时间标签按压效果
        private bool lblTimePressed;
        public TimerForm(TimerController controller)
        {
            timerController = controller;
            timer = new System.Timers.Timer(200);
            timer.Elapsed += Timer_Elapsed;
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            clockContorl = new ClockControl(panel1.Width, panel1.Height);

            panel1.Controls.Add(clockContorl);

            this.FormClosing += (s, e) =>
            {
                timerController.Stop();
            };
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (timer.Enabled)
            {
                lblTime.Text = timerController.CurrentTime.ToString(@"hh\:mm\:ss");
                lblTotalTime.Text = "总用时:" + timerController.TotalCost.ToString(@"hh\:mm\:ss");
            }

            DateTime baseTime = DateTime.Today.Add(timerController.CurrentTime);
            clockContorl.setTime(baseTime);
            // 添加呼吸灯效果
            var alpha = (Math.Sin(DateTime.Now.Second * 0.1) + 1) * 120;
            lblTime.ForeColor = Color.FromArgb((int)alpha, 230, 80, 80);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            timerController.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timerController.Pause();
        }

        private void btnChangeTime_Click(object sender, EventArgs e)
        {
            if (btnChangeTime.Text == "切换为电子钟")
            {
                btnChangeTime.Text = "切换为模拟钟";
                panel1.Visible = false;
            }
            else
            {
                btnChangeTime.Text = "切换为电子钟";
                panel1.Visible = true;
            }
        }

        private void lblTime_MouseDown(object sender, MouseEventArgs e)
        {
            lblTimePressed = true;
            lblTime.Font = new Font(lblTime.Font, FontStyle.Bold);
        }

        private void lblTime_MouseUp(object sender, MouseEventArgs e)
        {
            lblTimePressed = false;
            lblTime.Font = new Font(lblTime.Font, FontStyle.Regular);
        }

        // 使用阴影效果
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, splitContainer1.Panel2.ClientRectangle,
                Color.FromArgb(30, 30, 30), ButtonBorderStyle.Outset);
        }
        // 添加快捷键支持
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                if (btnStart.Enabled) btnStart.PerformClick();
                else btnStop.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timerController.Reset(0,TomatoClockApp.Services.TimerMode.CountUp);
            lblTime.Text  = "00:00:00";
            lblTotalTime.Text = "00:00:00";
        }
    }
}
