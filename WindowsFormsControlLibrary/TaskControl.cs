using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary
{
    public partial class TaskControl : UserControl, IComparable
    {
        private int id;
        private string name;
        private DateTime deadline;
        private bool isCompleted;
        private string category;

        public delegate void EventHandler(TaskControl tackControl);
        public event EventHandler btnClick;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; lblName.Text = Name; }
        }
        public DateTime Deadline
        {
            get { return deadline; }
            set { deadline = value; lblDeadline.Text = Deadline.ToString("yyyy-MM-dd"); }
        }
        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                isCompleted = value; chkCompleted.Checked = IsCompleted;
                chkCompleted.Text = IsCompleted ? "已完成" : "未完成";
            }
        }
        public string Category
        {
            get { return category; }
            set { category = value; lblCategory.Text = "分类：" + Category; }
        }
        public TaskControl(int id, String name, DateTime deadline, bool isCompleted, string category)
        {
            InitializeComponent();
            this.id = id;
            Name = name;
            Deadline = deadline;
            IsCompleted = isCompleted;
            Category = category;

            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 绘制圆角矩形
            using (var path = CreateRoundRectPath(ClientRectangle, 12))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Region = new Region(path);

                // 绘制背景图片
                if (BackgroundImage != null)
                {
                    e.Graphics.DrawImage(BackgroundImage, ClientRectangle);
                }
            }
        }
        private GraphicsPath CreateRoundRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void UpdateDisplay()
        {
            // 实时更新布局
            UpdateLayout();
        }
        private void UpdateLayout()
        {
            // 分类标签居中
            lblCategory.Size = new Size(120, 20);
            lblCategory.Location = new Point(
                (Width - lblCategory.Width) / 2,
                (Height - lblCategory.Height) / 2
            );

            //// 完成状态靠右居中
            //chkCompleted.Location = new Point(
            //    Width - chkCompleted.Width - 15,
            //    (Height - chkCompleted.Height) / 2
            //);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateLayout();
            Invalidate();  // 重绘圆角
        }

        private void btnComp_Click(object sender, EventArgs e)
        {
            btnClick?.Invoke(this);
        }

        public int CompareTo(object obj)
        {
            TaskControl taskControl = obj as TaskControl;
            return id.CompareTo(taskControl.Id);
        }

        public void SetBtnText(string t)
        {
            btnComp.Text = t;
        }
    }
}
