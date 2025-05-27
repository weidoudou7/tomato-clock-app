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


        public TimerForm(TimerController controller)
        {
            timerController = controller;
            timer = new System.Timers.Timer(200);
            timer.Elapsed += Timer_Elapsed;
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            clockContorl = new ClockControl(panel1.Width, panel1.Height);

            panel1.Controls.Add(clockContorl);

            this.FormClosing += (s,e) =>
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

    }
}
