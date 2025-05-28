using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Linq;
using TomatoClockApp.Controllers;

namespace TomatoClockApp.Views
{
    public partial class StatisticsForm : Form
    {

        // 主题相关常量
        private const string LightThemeIcon = "🌞";
        private const string DarkThemeIcon = "🌙";
        // 主题常量
        private static readonly Color LightBackColor = Color.WhiteSmoke;
        private static readonly Color LightControlBackColor = Color.White;
        private static readonly Color LightTextColor = Color.FromArgb(64, 64, 64);
        private static readonly Color LightGridColor = Color.LightGray;

        // 标准深夜模式配色
        private static readonly Color DarkBackColor = Color.FromArgb(40, 36, 35);
        private static readonly Color DarkControlBackColor = Color.FromArgb(50, 45, 43);
        private static readonly Color DarkTextColor = Color.FromArgb(255, 235, 200);
        private static readonly Color DarkGridColor = Color.FromArgb(70, 60, 55);

        // 系列颜色（根据主题动态调整）
        private Color ColorCompletion => isDarkMode ? Color.FromArgb(255, 195, 135) : Color.SteelBlue;
        private Color ColorTotal => isDarkMode ? Color.FromArgb(255, 155, 90) : Color.Orange;

        // 主题状态
        private bool isDarkMode = false;
        private ToolStripMenuItem darkModeMenuItem;
        private Button btnToggleTheme;

        // 常量定义
        private const string SeriesNameCompletion = "任务完成量";
        private const string SeriesNameTotal = "任务总量";

        // 控件和字段
        private StatisticsController statisticsController;
        private Chart taskCompletionChart;
        private bool isColumnChart = true;
        private int currentWeekOffset = 0;
        private Label lblWeek;
        private ComboBox cmbDataSource;

        // 枚举定义
        private enum DataSourceType { CompletionData, TotalData, CompareBoth };
        private DataSourceType currentDataSource = DataSourceType.CompletionData;

        public StatisticsForm(StatisticsController statisticsController)
        {
            InitializeComponent();
            this.statisticsController = statisticsController;

            // 添加暗黑模式菜单项
            AddDarkModeMenuItem();

            LoadStatistics();
        }

        private void LoadStatistics()
        {
            LoadTaskCompletionChart();
        }

        private void AddDarkModeMenuItem()
        {
            var menuStrip = new MenuStrip();
            var viewMenu = new ToolStripMenuItem("视图(&V)");

            darkModeMenuItem = new ToolStripMenuItem("暗黑模式", null, ToggleDarkMode)
            {
                CheckOnClick = true
            };

            viewMenu.DropDownItems.Add(darkModeMenuItem);
            menuStrip.Items.Add(viewMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void ToggleDarkMode(object sender, EventArgs e)
        {
            isDarkMode = darkModeMenuItem.Checked;
            ApplyTheme();
            LoadTaskCompletionChart(); // 重新加载图表应用主题
        }

        private void ApplyTheme()
        {
            // 更新窗体背景
            this.BackColor = isDarkMode ? DarkBackColor : LightBackColor;

            // 更新主题按钮图标
            btnToggleTheme.Text = isDarkMode ? DarkThemeIcon : LightThemeIcon;
            btnToggleTheme.BackColor = isDarkMode ? DarkControlBackColor : LightControlBackColor;
            btnToggleTheme.ForeColor = isDarkMode ? DarkTextColor : LightTextColor;
            btnToggleTheme.FlatAppearance.BorderColor = isDarkMode ? Color.DimGray : Color.Silver;

            // 递归更新所有控件
            UpdateControlColors(this);
        }

        private void LoadTaskCompletionChart()
        {
            this.Controls.Clear();

            // 获取数据
            int[] weeklyCompletionData = statisticsController.GetWeeklyTaskCompletion(currentWeekOffset);
            int[] weeklytotalData = statisticsController.GetWeeklyTotalTasks(currentWeekOffset);
            string[] weekDays = { "一", "二", "三", "四", "五", "六", "日" };

            // 主容器
            var mainPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(10) };
            this.Controls.Add(mainPanel);

            // 图表容器
            var chartContainer = new Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke, Margin = new Padding(0, 50, 0, 0) };
            mainPanel.Controls.Add(chartContainer);

            // 初始化图表
            taskCompletionChart = new Chart { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke, Padding = new Padding(10) };
            chartContainer.Controls.Add(taskCompletionChart);

            // 控制面板
            var controlPanel = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.Transparent, Padding = new Padding(10, 5, 10, 5) };
            mainPanel.Controls.Add(controlPanel);

            // 按钮组
            var buttonGroup = new Panel { AutoSize = false, Size = new Size(700, 40), BackColor = Color.Transparent };
            controlPanel.Controls.Add(buttonGroup);

            // 应用主题到控件
            mainPanel.BackColor = isDarkMode ? DarkBackColor : LightBackColor;
            chartContainer.BackColor = isDarkMode ? DarkBackColor : LightBackColor;

            // 初始化图表时应用主题
            taskCompletionChart.BackColor = isDarkMode ? DarkBackColor : LightBackColor;

            // 添加控件
            AddControlButtons(buttonGroup);

            // 初始化图表基础
            InitializeChartBase();

            // 更新图表数据
            UpdateChartData(weeklyCompletionData, weeklytotalData, weekDays);

            // 更新控件样式
            UpdateControlColors(controlPanel);
            UpdateChartTheme();
        }

        private void UpdateControlColors(Control container)
        {
            foreach (Control control in container.Controls)
            {
                // 跳过主题按钮（已单独处理）
                if (control.Tag?.ToString() == "themeButton") continue;

                if (control is Button button)
                {
                    button.BackColor = isDarkMode ? DarkControlBackColor : LightControlBackColor;
                    button.ForeColor = isDarkMode ? DarkTextColor : LightTextColor;
                    button.FlatAppearance.BorderColor = isDarkMode ? Color.DimGray : Color.SteelBlue;
                    button.FlatAppearance.MouseOverBackColor = isDarkMode ?
                        Color.FromArgb(60, 60, 70) : Color.FromArgb(240, 240, 255);
                }
                else if (control is Label label && label != lblWeek) // 排除周标签
                {
                    label.ForeColor = isDarkMode ? Color.DimGray : Color.LightGray;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = isDarkMode ? DarkControlBackColor : LightControlBackColor;
                    comboBox.ForeColor = isDarkMode ? DarkTextColor : LightTextColor;
                }
                else if (control is Panel panel)
                {
                    panel.BackColor = isDarkMode ? DarkBackColor : LightBackColor;
                }

                if (control.HasChildren)
                {
                    UpdateControlColors(control);
                }

            }
        }

        private void UpdateChartTheme()
        {
            if (taskCompletionChart == null) return;

            // 更新图表区域样式
            foreach (ChartArea area in taskCompletionChart.ChartAreas)
            {
                area.BackColor = isDarkMode ? DarkBackColor : LightBackColor;

                // 坐标轴样式
                area.AxisX.LineColor = isDarkMode ? DarkTextColor : LightTextColor;
                area.AxisY.LineColor = isDarkMode ? DarkTextColor : LightTextColor;
                area.AxisY2.LineColor = isDarkMode ? DarkTextColor : LightTextColor;

                // 标签样式
                area.AxisX.LabelStyle.ForeColor = isDarkMode ? DarkTextColor : LightTextColor;
                area.AxisY.LabelStyle.ForeColor = isDarkMode ? DarkTextColor : LightTextColor;
                area.AxisY2.LabelStyle.ForeColor = isDarkMode ? DarkTextColor : LightTextColor;

                // 标题样式
                area.AxisX.TitleForeColor = isDarkMode ? DarkTextColor : LightTextColor;
                area.AxisY.TitleForeColor = isDarkMode ? DarkTextColor : LightTextColor;
                area.AxisY2.TitleForeColor = isDarkMode ? DarkTextColor : LightTextColor;

                // 网格线
                area.AxisX.MajorGrid.LineColor = isDarkMode ? DarkGridColor : LightGridColor;
                area.AxisY.MajorGrid.LineColor = isDarkMode ? DarkGridColor : LightGridColor;
                area.AxisY2.MajorGrid.LineColor = isDarkMode ? DarkGridColor : LightGridColor;
            }

            // 更新系列颜色
            foreach (Series series in taskCompletionChart.Series)
            {
                if (series.Name == "任务完成量")
                {
                    series.Color = ColorCompletion;
                    if (series.MarkerStyle != MarkerStyle.None)
                    {
                        series.MarkerColor = ColorCompletion;
                    }
                }
                else if (series.Name == "任务总量")
                {
                    series.Color = ColorTotal;
                    if (series.MarkerStyle != MarkerStyle.None)
                    {
                        series.MarkerColor = ColorTotal;
                    }
                }

                // 更新数据点标签颜色
                series.Font = new Font("Microsoft YaHei", 8);
                series.LabelForeColor = isDarkMode ? DarkTextColor : LightTextColor;
            }
        }

        private void AddControlButtons(Panel buttonGroup)
        {

            // 1. 主题切换按钮（最左侧新增）
            btnToggleTheme = new Button
            {
                Text = isDarkMode ? DarkThemeIcon : LightThemeIcon,
                Size = new Size(40, 30),
                Location = new Point(10, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = isDarkMode ? DarkControlBackColor : LightControlBackColor,
                ForeColor = isDarkMode ? DarkTextColor : LightTextColor,
                Font = new Font("Segoe UI Emoji", 12),
                Cursor = Cursors.Hand,
                Tag = "themeButton" // 添加标记用于样式更新
            };
            btnToggleTheme.FlatAppearance.BorderColor = isDarkMode ? Color.DimGray : Color.Silver;
            btnToggleTheme.Click += ToggleThemeMode;
            buttonGroup.Controls.Add(btnToggleTheme);

            // 2. 上一周按钮（位置调整）
            var btnPrevWeek = new Button
            {
                Text = "◀ 上周",
                Size = new Size(80, 30),
                Location = new Point(60, 5), // 向右移动50px
                FlatStyle = FlatStyle.Flat,
                BackColor = isDarkMode ? DarkControlBackColor : LightControlBackColor,
                ForeColor = isDarkMode ? DarkTextColor : LightTextColor,
                Font = new Font("Microsoft YaHei", 9),
                Cursor = Cursors.Hand
            };
            btnPrevWeek.FlatAppearance.BorderColor = isDarkMode ? Color.DimGray : Color.SteelBlue;
            btnPrevWeek.FlatAppearance.MouseOverBackColor = isDarkMode ?
                Color.FromArgb(60, 60, 70) : Color.FromArgb(240, 240, 255);
            btnPrevWeek.Click += BtnPrevWeek_Click;
            buttonGroup.Controls.Add(btnPrevWeek);

            // 3. 当前周标签（位置调整）
            lblWeek = new Label
            {
                Text = GetCurrentWeekText(),
                Size = new Size(200, 30),
                Location = new Point(140, 5), // 向右移动60px
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft YaHei", 10, FontStyle.Bold),
                ForeColor = isDarkMode ? DarkTextColor : Color.DimGray,
                BackColor = Color.Transparent
            };
            buttonGroup.Controls.Add(lblWeek);

            // 4. 下一周按钮
            var btnNextWeek = new Button
            {
                Text = "下周 ▶",
                Size = new Size(80, 30),
                Location = new Point(340, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = isDarkMode ? DarkControlBackColor : LightControlBackColor,
                ForeColor = isDarkMode ? DarkTextColor : LightTextColor,
                Font = new Font("Microsoft YaHei", 9),
                Cursor = Cursors.Hand
            };
            btnNextWeek.FlatAppearance.BorderColor = isDarkMode ? Color.DimGray : Color.SteelBlue;
            btnNextWeek.FlatAppearance.MouseOverBackColor = isDarkMode ?
                Color.FromArgb(60, 60, 70) : Color.FromArgb(240, 240, 255);
            btnNextWeek.Click += BtnNextWeek_Click;
            buttonGroup.Controls.Add(btnNextWeek);

            // 5. 分隔线1
            buttonGroup.Controls.Add(CreateSeparator(430, 5));


            // 6.数据源下拉框
            cmbDataSource = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = new Size(100, 30),
                Location = new Point(450, 5),
                Font = new Font("Microsoft YaHei", 9),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.DimGray
            };
            cmbDataSource.Items.AddRange(new object[] { "任务完成量", "任务总量", "双轴对比" });
            cmbDataSource.SelectedIndex = (int)currentDataSource;
            cmbDataSource.SelectedIndexChanged += CmbDataSource_SelectedIndexChanged;
            buttonGroup.Controls.Add(cmbDataSource);

            // 7. 分隔线2
            buttonGroup.Controls.Add(CreateSeparator(560, 5));

            // 8. 切换图表按钮
            var btnToggleChart = new Button
            {
                Text = isColumnChart ? "切换为折线图" : "切换为柱状图",
                Size = new Size(120, 30),
                Location = new Point(580, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = isDarkMode ? DarkControlBackColor : LightControlBackColor,
                ForeColor = isDarkMode ? DarkTextColor : LightTextColor,
                Font = new Font("Microsoft YaHei", 9),
                Cursor = Cursors.Hand
            };
            btnToggleChart.FlatAppearance.BorderColor = isDarkMode ? Color.DimGray : Color.SteelBlue;
            btnToggleChart.FlatAppearance.MouseOverBackColor = isDarkMode ?
                Color.FromArgb(60, 60, 70) : Color.FromArgb(240, 240, 255);
            btnToggleChart.Click += BtnToggleChart_Click;
            buttonGroup.Controls.Add(btnToggleChart);
        }

        private Label CreateSeparator(int x, int y)
        {
            return new Label
            {
                Text = "|",
                Size = new Size(20, 30),
                Location = new Point(x, y),
                Font = new Font("Microsoft YaHei", 10),
                ForeColor = isDarkMode ? Color.DimGray : Color.LightGray,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private void ToggleThemeMode(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
            LoadTaskCompletionChart();
        }

        private void InitializeChartBase()
        {
            taskCompletionChart.ChartAreas.Clear();
            taskCompletionChart.Series.Clear();

            var chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            taskCompletionChart.ChartAreas.Add(chartArea);
        }

        private void UpdateChartData(int[] completionData, int[] totalData, string[] weekDays)
        {
            switch (currentDataSource)
            {
                case DataSourceType.CompletionData:
                    UpdateSingleSeries(completionData, SeriesNameCompletion, "完成任务数", ColorCompletion);
                    break;
                case DataSourceType.TotalData:
                    UpdateSingleSeries(totalData, SeriesNameTotal, "任务总数", ColorTotal);
                    break;
                case DataSourceType.CompareBoth:
                    UpdateDualAxisComparison(completionData, totalData);
                    break;
            }

            SetXAxisLabels(weekDays);
        }

        private void UpdateSingleSeries(int[] data, string seriesName, string yAxisTitle, Color color)
        {
            var chartArea = taskCompletionChart.ChartAreas[0];
            chartArea.AxisY.Title = yAxisTitle;
            chartArea.AxisY2.Enabled = AxisEnabled.False;

            var series = new Series(seriesName)
            {
                ChartType = isColumnChart ? SeriesChartType.Column : SeriesChartType.Line,
                Color = color,
                IsValueShownAsLabel = true,
                Font = new Font("Microsoft YaHei", 8),
                ["PointWidth"] = "0.6"
            };

            // 确保应用当前主题色
            series.Color = color;
            if (!isColumnChart)
            {
                series.MarkerColor = color;
            }

            if (!isColumnChart)
            {
                series.BorderWidth = 3;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 8;
            }

            for (int i = 0; i < data.Length; i++)
            {
                var point = new DataPoint(i, data[i]);
                if (isColumnChart) point.Color = GetProgressColor(data[i]);
                series.Points.Add(point);
            }

            taskCompletionChart.Series.Add(series);
        }

        private void UpdateDualAxisComparison(int[] completionData, int[] totalData)
        {
            var chartArea = taskCompletionChart.ChartAreas[0];
            chartArea.AxisY.Title = "完成任务数";
            chartArea.AxisY2.Title = "任务总数";
            chartArea.AxisY2.Enabled = AxisEnabled.True;
            chartArea.AxisY2.MajorGrid.Enabled = false;

            var completionSeries = new Series(SeriesNameCompletion)
            {
                ChartType = SeriesChartType.Line,
                Color = ColorCompletion,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                IsValueShownAsLabel = true
            };

            var totalSeries = new Series(SeriesNameTotal)
            {
                ChartType = SeriesChartType.Line,
                YAxisType = AxisType.Secondary,
                Color = ColorTotal,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Square,
                MarkerSize = 6,
                IsValueShownAsLabel = true
            };

            // 应用动态主题色
            completionSeries.Color = ColorCompletion;
            completionSeries.MarkerColor = ColorCompletion;

            totalSeries.Color = ColorTotal;
            totalSeries.MarkerColor = ColorTotal;

            for (int i = 0; i < completionData.Length; i++)
            {
                completionSeries.Points.AddXY(i, completionData[i]);
                totalSeries.Points.AddXY(i, totalData[i]);
            }

            taskCompletionChart.Series.Add(completionSeries);
            taskCompletionChart.Series.Add(totalSeries);
        }

        private void SetXAxisLabels(string[] weekDays)
        {
            var chartArea = taskCompletionChart.ChartAreas[0];
            chartArea.AxisX.CustomLabels.Clear();

            for (int i = 0; i < weekDays.Length; i++)
            {
                chartArea.AxisX.CustomLabels.Add(new CustomLabel(
                    i - 0.5, i + 0.5, weekDays[i], 0, LabelMarkStyle.None));
            }
        }

        //... [保持其他辅助方法不变] ...
        private void BtnToggleChart_Click(object sender, EventArgs e)
        {
            //if (taskCompletionChart?.Series.Count == 0) return;

            //var series = taskCompletionChart.Series[0];
            //var button = (System.Windows.Forms.Button)sender; // 明确类型转换

            //if (isColumnChart)
            //{
            //    series.ChartType = SeriesChartType.Line;
            //    series.BorderWidth = 3;
            //    series.MarkerStyle = MarkerStyle.Circle;
            //    button.Text = "切换为柱状图";
            //}
            //else
            //{
            //    series.ChartType = SeriesChartType.Column;
            //    series["PointWidth"] = "0.6";
            //    button.Text = "切换为折线图";
            //}
            //isColumnChart = !isColumnChart;
            if (taskCompletionChart?.Series.Count == 0) return;

            var button = (Button)sender;

            // 双轴对比模式下的特殊处理
            if (currentDataSource == DataSourceType.CompareBoth)
            {
                isColumnChart = false; // 强制使用折线图对比
                button.Text = "柱状图不可用";
                button.Enabled = false;

                foreach (var series in taskCompletionChart.Series)
                {
                    series.ChartType = SeriesChartType.Line;
                    if (series.Name == "任务完成量")
                    {
                        series.BorderWidth = 3;
                        series.MarkerStyle = MarkerStyle.Circle;
                        series.MarkerSize = 8;
                    }
                }
            }
            else
            {
                button.Enabled = true;
                var mainSeries = taskCompletionChart.Series[0];

                if (isColumnChart)
                {
                    mainSeries.ChartType = SeriesChartType.Line;
                    mainSeries.BorderWidth = 3;
                    mainSeries.MarkerStyle = MarkerStyle.Circle;
                    button.Text = "切换为柱状图";
                }
                else
                {
                    mainSeries.ChartType = SeriesChartType.Column;
                    mainSeries["PointWidth"] = "0.6";
                    button.Text = "切换为折线图";
                }
                isColumnChart = !isColumnChart;
            }
        }

        private void BtnPrevWeek_Click(object sender, EventArgs e)
        {
            currentWeekOffset--;
            LoadTaskCompletionChart(); // 这会重新加载整个图表和更新标签
        }

        private void BtnNextWeek_Click(object sender, EventArgs e)
        {
            currentWeekOffset++;
            LoadTaskCompletionChart(); // 这会重新加载整个图表和更新标签
        }

        private string GetCurrentWeekText()
        {
            DateTime baseDate = DateTime.Now.AddDays(currentWeekOffset * 7);
            DateTime startOfWeek = baseDate.AddDays(-(int)baseDate.DayOfWeek + 1); // 周一
            DateTime endOfWeek = startOfWeek.AddDays(6); // 周日

            // 如果是当前周，显示"本周"
            if (currentWeekOffset == 0)
            {
                return $"本周 ({startOfWeek:M月d日} - {endOfWeek:M月d日})";
            }
            // 如果是上周，显示"上周"
            else if (currentWeekOffset == -1)
            {
                return $"上周 ({startOfWeek:M月d日} - {endOfWeek:M月d日})";
            }
            // 如果是下周，显示"下周"
            else if (currentWeekOffset == 1)
            {
                return $"下周 ({startOfWeek:M月d日} - {endOfWeek:M月d日})";
            }
            // 其他情况显示具体日期范围
            else
            {
                return $"{startOfWeek:yyyy年M月d日} - {endOfWeek:M月d日}";
            }
        }

        private Color GetProgressColor(int value)
        {
            if (isDarkMode)
            {
                return value switch
                {
                    >= 15 => Color.LightSkyBlue,
                    >= 10 => Color.MediumAquamarine,
                    >= 5 => Color.Goldenrod,
                    _ => Color.IndianRed
                };
            }
            else
            {
                return value switch
                {
                    >= 15 => Color.DodgerBlue,
                    >= 10 => Color.MediumSeaGreen,
                    >= 5 => Color.Goldenrod,
                    _ => Color.IndianRed
                };
            }
        }
        private void CmbDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentDataSource = (DataSourceType)cmbDataSource.SelectedIndex;
            LoadTaskCompletionChart(); // 重新加载图表
        }
    }
}

