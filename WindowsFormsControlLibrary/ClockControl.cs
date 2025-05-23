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
    public partial class ClockControl : UserControl
    {
        // 常量定义
        private const int SIN_WAVE_COUNT = 12;//波形数量
        private const float HOUR_HAND_LENGTH = 0.4f;
        private const float MINUTE_HAND_LENGTH = 0.6f;
        private const float SECOND_HAND_RADIUS = 0.04f;

        // 颜色定义
        private readonly Color WAVE_COLOR = ColorTranslator.FromHtml("#FFEED9");
        private readonly Color HAND_COLOR = ColorTranslator.FromHtml("#5E4000");
        private readonly Color HOUR_COLOR = ColorTranslator.FromHtml("#5E4000");
        private readonly Color MINUTE_COLOR = ColorTranslator.FromHtml("#9C6D00");
        private readonly Color SECOND_COLOR = ColorTranslator.FromHtml("#657E3F");

        private int screenWidth = 1920;
        private int screenHeight = 1080;
        private DateTime currentTime;
        private System.Timers.Timer timer;

        public ClockControl(int width, int height)
        {
            InitializeComponent();

            screenHeight = height;
            screenWidth = width;
            this.Size = new Size(screenWidth, screenHeight);
            this.DoubleBuffered = true; // 开启双缓冲
            this.SetStyle(ControlStyles.ResizeRedraw, true); // 设置控件在大小改变时重绘

            InitializeClock();
        }

        private void InitializeClock()
        {

            // 初始化定时器
            timer = new System.Timers.Timer { Interval = 500 };

            timer.Elapsed += (s, e) =>
            {
                this.Invalidate(); // 请求重绘
            };

            timer.Start();
        }

        public void setTime(DateTime dt)
        {
            currentTime = dt;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 获取绘图对象
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 计算中心点和半径
            PointF center = new PointF(this.Width / 2, this.Height / 2);
            float radius = Math.Min(this.Width, this.Height) / 2 * 0.9f;

            // 绘制波形表盘
            DrawWaveDial(g, center, radius);

            // 绘制时钟刻度
            DrawMarkers(g, center, radius);

            // 绘制指针
            DrawHands(g, center, radius);
        }

        // 绘制波形表盘
        private void DrawWaveDial(Graphics g, PointF center, float radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                float waveAmplitude = radius * 0.12f;//波形振幅
                float angleStep = 360f / SIN_WAVE_COUNT;

                // 预计算第一个点
                PointF? firstPoint = null;

                for (int i = 0; i < SIN_WAVE_COUNT; i++)
                {
                    float angle = i * angleStep;
                    float wave = (float)Math.Sin(Math.PI * 2 * i / SIN_WAVE_COUNT);
                    float r = radius + wave * waveAmplitude;

                    PointF currentPoint = new PointF(
                        center.X + r * (float)Math.Cos(angle * Math.PI / 180),
                        center.Y + r * (float)Math.Sin(angle * Math.PI / 180));

                    if (i == 0)
                    {
                        path.StartFigure();
                        path.AddLine(currentPoint, currentPoint); // 初始化起始点
                        firstPoint = currentPoint;
                    }
                    else
                    {
                        // 安全添加线段
                        if (path.PointCount > 0)
                        {
                            path.AddLine(path.GetLastPoint(), currentPoint);
                        }
                    }
                }

                // 闭合路径（自动连接首尾点）
                if (firstPoint.HasValue && path.PointCount > 2)
                {
                    path.AddLine(path.GetLastPoint(), firstPoint.Value);
                }

                using (SolidBrush brush = new SolidBrush(WAVE_COLOR))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        // 绘制刻度
        private void DrawMarkers(Graphics g, PointF center, float radius)
        {
            for (int i = 0; i < 60; i++)
            {
                float angle = i * 6;
                float inner = radius * (i % 5 == 0 ? 0.85f : 0.9f);
                float outer = radius * 0.95f;

                PointF p1 = GetPoint(center, inner, angle);
                PointF p2 = GetPoint(center, outer, angle);

                using (Pen pen = new Pen(HAND_COLOR, i % 5 == 0 ? 3f : 1f))
                {
                    g.DrawLine(pen, p1, p2);
                }
            }
        }

        // 绘制指针
        private void DrawHands(Graphics g, PointF center, float radius)
        {
            float hourAngle = (currentTime.Hour % 12) * 30 + currentTime.Minute * 0.5f; // -90度调整初始位置
            float minuteAngle = currentTime.Minute * 6 + currentTime.Second * 0.1f;
            float secondAngle = currentTime.Second * 6 - 90;

            // 绘制时针（圆角矩形）
            DrawRoundedRectHand(g, center, hourAngle,
                radius * HOUR_HAND_LENGTH,
                radius * 0.1f, // 宽度为半径的10%
                HOUR_COLOR);

            // 绘制分针（圆角矩形）
            DrawRoundedRectHand(g, center, minuteAngle,
                radius * MINUTE_HAND_LENGTH,
                radius * 0.075f, // 宽度为半径的7.5%
                MINUTE_COLOR);

            // 绘制秒针（圆形）
            using (SolidBrush brush = new SolidBrush(SECOND_COLOR))
            {
                PointF endPoint = GetPoint(center, radius * 0.85f, secondAngle);
                float diameter = radius * SECOND_HAND_RADIUS * 2;
                g.FillEllipse(brush,
                    endPoint.X - diameter / 2,
                    endPoint.Y - diameter / 2,
                    diameter,
                    diameter);
            }
        }

        // 修复 CS0747 和 CS1003 错误：将 `pen.LineJoin` 的赋值移到 `using` 块外部，并正确初始化 `Pen` 对象。
        private void DrawRoundedRectHand(Graphics g, PointF center, float angle,
            float length, float width, Color color)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                // 计算矩形参数
                RectangleF rect = new RectangleF(
                    -width / 2,
                    -length,
                    width,
                    length);

                // 创建圆角矩形
                float cornerRadius = width / 2;
                path.AddArc(rect.Left, rect.Top, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Top, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                // 应用旋转变换
                using (Matrix matrix = new Matrix())
                {
                    matrix.Translate(center.X, center.Y);
                    matrix.Rotate(angle);
                    path.Transform(matrix);
                }

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        // 坐标计算辅助方法
        private PointF GetPoint(PointF center, float radius, float angle)
        {
            float radians = angle * (float)Math.PI / 180f;
            return new PointF(
                center.X + radius * (float)Math.Cos(radians),
                center.Y + radius * (float)Math.Sin(radians));
        }
    }
}
