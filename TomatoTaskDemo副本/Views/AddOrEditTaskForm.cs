using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using TomatoClockApp.Controllers;
using TomatoClockApp.Models;
using Task = TomatoClockApp.Models.Task;

namespace TomatoClockApp.Views
{
    public partial class AddOrEditTaskForm : Form
    {
        private TaskController _taskController;
        private Task _task;

        public AddOrEditTaskForm(TaskController taskController)
        {
            InitializeComponent();
            _taskController = taskController;
        }

        public AddOrEditTaskForm(TaskController taskController, Task task) : this(taskController)
        {
            _task = task;
            if (_task != null)
            {
                txtTaskName.Text = _task.Name;
                dtpDeadline.Value = _task.Deadline;
                txtCategory.Text = _task.Category;
                chkIsCompleted.Checked = _task.IsCompleted;
            }
        }

        private void btnAddOrEditTask_Click(object sender, EventArgs e)
        {
            try
            {
                // 核心逻辑：统一操作已跟踪的实体
                if (_task == null) // 新增模式
                {
                    var newTask = new Task
                    {
                        Name = txtTaskName.Text.Trim(),
                        Deadline = dtpDeadline.Value,
                        Category = txtCategory.Text.Trim(),
                        IsCompleted = chkIsCompleted.Checked
                    };

                    _taskController.AddTask(newTask);
                    MessageBox.Show("任务创建成功！", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // 编辑模式
                {
                    // 直接修改原始实体的属性（确保此对象已被上下文跟踪）
                    _task.Name = txtTaskName.Text.Trim();
                    _task.Deadline = dtpDeadline.Value;
                    _task.Category = txtCategory.Text.Trim();
                    _task.IsCompleted = chkIsCompleted.Checked;

                    _taskController.UpdateTask(_task);
                    MessageBox.Show("任务更新成功！", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 明确对话框结果以触发主窗体刷新
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show($"数据库保存失败：{dbEx.InnerException?.Message}", "严重错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"系统错误：{ex.Message}", "意外错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}