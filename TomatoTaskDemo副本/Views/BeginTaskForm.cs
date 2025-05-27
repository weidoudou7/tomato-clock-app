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
using TomatoClockApp.Services;
using TomatoTaskDemo.CustomerControls;
using TomatoTaskDemo.Views;


namespace TomatoTaskDemo.Services
{
    public partial class BeginTaskForm : Form
    {
        List<TomatoClockApp.Models.Task> tasks = new List<TomatoClockApp.Models.Task>();
        List<TaskControl> taskControls = new List<TaskControl>();
        TaskController taskController;
        TimerController timerController;
        TimerForm timerForm;
        //public BeginTaskForm(TaskController t, TimerController timerController)
        //{
        //    taskController = t;
        //    tasks = t.GetTasks();
        //    this.timerController = timerController;

        //    InitializeComponent();

        //    InitializeTackControls();

        //    foreach (var taskControl in taskControls)
        //    {
        //        taskControl.btnClick += SeletTask;
        //    }
        //    InitializePanel1();
        //}
        public BeginTaskForm(TaskController taskController, TimerController timerController)
        {
            InitializeComponent();
            this.taskController = taskController;
            this.timerController = timerController;

            // 直接初始化数据
            tasks = taskController.GetTasks();
            InitializeTackControls();
            InitializePanel1();

            // 绑定控件事件
            foreach (var taskControl in taskControls)
            {
                taskControl.btnClick += SeletTask;
            }
        }

        public void InitializeTackControls()
        {
            int i = 0;
            string basepath = @"..\..\..\static\bk";
            foreach (var task in tasks)
            {
                i = (i + 1) % 5 + 1;
                string path = basepath + i.ToString() + ".jpg";
                taskControls.Add(new TaskControl(task.Id, task.Name, task.Deadline, task.IsCompleted, task.Category) { BackgroundImage = Image.FromFile(path) });
            }
        }

        public void InitializePanel1()
        {
            panel1.Controls.Clear();

            foreach (var taskControl in taskControls)
            {
                panel1.Controls.Add(taskControl);
            }
            panel1.Visible = true;
        }

        private void countUp_CheckedChanged(object sender, EventArgs e)
        {
            downTime.Visible = false;
            timerController.Reset(0, TimerMode.CountUp);
        }

        private void countDown_CheckedChanged(object sender, EventArgs e)
        {
            downTime.Visible = true;
            downTime.Value = DateTime.Today;
        }
        private void downTime_ValueChanged(object sender, EventArgs e)
        {
            int seconds = 0;
            seconds = downTime.Value.Second + downTime.Value.Minute * 60 + downTime.Value.Hour * 3600;
            timerController.Reset(seconds, TimerMode.CountDown);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            timerForm = new TimerForm(timerController);
            timerForm.ShowDialog();
        }

        private void SeletTask(TaskControl taskControl)
        {
            if (panel2.Controls.Contains(taskControl))
            {
                panel2.Controls.Remove(taskControl);
                taskControl.SetBtnText("去完成");
                taskControls.Add(taskControl);
                taskControls.Sort();
                InitializePanel1();
            }
            else if (panel2.Controls.Count == 0)
            {
                taskControls.Remove(taskControl);
                taskControl.SetBtnText("卸下");
                InitializePanel1();
                panel2.Controls.Add(taskControl);
            }
            else
            {
                TaskControl taskControl1 = panel2.Controls[0] as TaskControl;
                taskControl1.SetBtnText("去完成");
                taskControls.Add(taskControl1);
                taskControls.Remove(taskControl);
                taskControls.Sort();
                panel2.Controls.Add(taskControl);
                taskControl.SetBtnText("卸下");
                InitializePanel1();
            }
        }

        private void BeginTaskForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
