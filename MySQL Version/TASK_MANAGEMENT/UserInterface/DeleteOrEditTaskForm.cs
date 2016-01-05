using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using Entities;

namespace UserInterface
{
    public partial class DeleteOrEditTaskForm : Form
    {
        UserData userData = new UserData();
        TaskData taskData = new TaskData();
        TaskDataGridItem taskItem;
        List<TaskDataGridItem> gridItemList;
        DataGridView taskDataGridView;

        public DeleteOrEditTaskForm(TaskDataGridItem taskDataGridItem, DataGridView tdg)
        {
            InitializeComponent();

            var nameList = from users in userData.QueryAll()
                           select users.USER_NAME;

            foreach(string name in nameList)
            {
                AssignedToComboBox.Items.Add(name);
            }

            TaskIDLabel.Text = taskDataGridItem.TASK_ID.ToString();
            AssignedByLabel.Text = taskDataGridItem.ASSIGNED_BY;
            AssignedToComboBox.Text = taskDataGridItem.ASSIGNED_TO;
            TaskTitleTextBox.Text = taskDataGridItem.TASK_TITLE;
            DetailsTextBox.Text = taskDataGridItem.TASK_DETAILS;
            IssueDatePicker.Value = taskDataGridItem.ISSUE_DATE;
            DueDatePicker.Value = taskDataGridItem.DUE_DATE;
            SendEmailCheckBox.Checked = taskDataGridItem.SEND_EMAIL;

            taskItem = taskDataGridItem;

            taskDataGridView = tdg;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Task task = new Task();

            task.TASK_ID = taskItem.TASK_ID;
            task.TASK_TITLE = TaskTitleTextBox.Text;
            task.TASK_DETAILS = DetailsTextBox.Text;
            task.ISSUE_DATE = IssueDatePicker.Value;
            task.DUE_DATE = DueDatePicker.Value;
            task.SEND_EMAIL = SendEmailCheckBox.Checked;

            var userId = from user in userData.QueryAll()
                         where user.USER_NAME == taskItem.ASSIGNED_TO
                         select user.USER_ID;

            foreach(int uID in userId)
            {
                task.USER_ID = uID;
            }

            userId = from user in userData.QueryAll()
                     where user.USER_NAME == taskItem.ASSIGNED_BY
                     select user.USER_ID;

            foreach(int uID in userId)
            {
                task.ASSIGNED_BY = uID;
            }

            taskData.Update(task, task.TASK_ID);

            initTaskDataGridView(userData.QueryAll(), taskData.QueryAll());
            this.Close();
        }

        void initTaskDataGridView(List<UserDataGridItem> userList, List<Task> taskList)
        {
            var lst = from user in userList
                      from assigner in userList
                      from task in taskList
                      where user.USER_ID == task.USER_ID
                      where assigner.USER_ID == task.ASSIGNED_BY
                      select new TaskDataGridItem()
                      {
                          ASSIGNED_TO = user.USER_NAME,
                          ASSIGNED_BY = assigner.USER_NAME,
                          TASK_ID = task.TASK_ID,
                          TASK_TITLE = task.TASK_TITLE,
                          TASK_DETAILS = task.TASK_DETAILS,
                          DUE_DATE = task.DUE_DATE,
                          ISSUE_DATE = task.ISSUE_DATE,
                          SEND_EMAIL = task.SEND_EMAIL
                      };

            gridItemList = lst.ToList();

            taskDataGridView.DataSource = gridItemList;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            taskData.Delete(taskItem.TASK_ID);
            initTaskDataGridView(userData.QueryAll(), taskData.QueryAll());

            this.Close();
        }
    }
}
