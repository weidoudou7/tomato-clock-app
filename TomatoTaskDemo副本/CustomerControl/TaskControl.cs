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

namespace TomatoTaskDemo.CustomerControl
{
    public partial class TaskControl : Control, IComparable
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
        public TaskControl(int id, String name, DateTime deadline, bool isCompleted, string category, int width)
        {
            InitializeComponent();
            this.id = id;
            Name = name;
            Deadline = deadline;
            IsCompleted = isCompleted;
            Category = category;

            this.Size = new Size(width - 25, (width - 25) / 4);

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
        private void UpdateLayout()
        {
            // 任务名称靠左上角
            lblName.Location = new Point(10, 10);

            // 截止时间靠左下角
            lblDeadline.Location = new Point(10, Height - lblDeadline.Height - 10);

            int extraWidth = 10; // 额外的宽度，用于间距

            // 完成状态居中靠右
            chkCompleted.Location = new Point(
                Width / 2 + extraWidth,
                Height / 2 - chkCompleted.Height / 2
            );

            // 分类标签居中靠左
            lblCategory.Location = new Point(
                Width / 2 - lblCategory.Width - extraWidth,
                Height / 2 - lblCategory.Height / 2
            );

            //按钮位置靠右中间
            btnComp.Location = new Point(
                Width - btnComp.Width - extraWidth,
                Height / 2 - btnComp.Height / 2
            );

        }

        private void UpdateSize()
        {
            float rate = Size.Width / 385f;

            //将当前控件的大小设置为原来的rate倍
            lblName.Font = new Font(lblName.Font.FontFamily, lblName.Font.Size * rate, lblName.Font.Style);
            lblDeadline.Font = new Font(lblDeadline.Font.FontFamily, lblDeadline.Font.Size * rate, lblDeadline.Font.Style);
            lblCategory.Font = new Font(lblCategory.Font.FontFamily, lblCategory.Font.Size * rate, lblCategory.Font.Style);
            chkCompleted.Font = new Font(chkCompleted.Font.FontFamily, chkCompleted.Font.Size * rate, chkCompleted.Font.Style);
            btnComp.Font = new Font(btnComp.Font.FontFamily, btnComp.Font.Size * rate, btnComp.Font.Style);

            lblName.Size = new Size((int)(lblName.Width * rate), (int)(lblName.Height * rate));
            lblDeadline.Size = new Size((int)(lblDeadline.Width * rate), (int)(lblDeadline.Height * rate));
            lblCategory.Size = new Size((int)(lblCategory.Width * rate), (int)(lblCategory.Height * rate));
            chkCompleted.Size = new Size((int)(chkCompleted.Width * rate), (int)(chkCompleted.Height * rate));
            btnComp.Size = new Size((int)(btnComp.Width * rate * 0.8f), (int)(btnComp.Height * rate));

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateSize();
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
