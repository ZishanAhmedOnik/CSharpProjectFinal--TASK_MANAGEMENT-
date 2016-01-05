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
    public partial class LoginForm : Form
    {
        UserData userData = new UserData();
        TaskData taskData = new TaskData();
        User loggedInUser;
        List<TaskDataGridItem> gridItemList;

        public LoginForm()
        {
            InitializeComponent();
            UserPanel.Visible = false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            userDataGridView.DataSource = userData.QueryAll();
            initTaskDataGridView(userData.QueryAll(), taskData.QueryAll());

            string UserName = UserNameTextBox.Text;
            string Password = passwordTextBox.Text;

            loggedInUser = userData.UserLogin(UserName, Password);

            if(loggedInUser != null)
            {
                LoginPanel.Visible = false;
                UserPanel.Visible = true;
            }
            else
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.BalloonTipTitle = "Task Management";
                notifyIcon1.BalloonTipText = "Login Failed!";
                notifyIcon1.ShowBalloonTip(3000);
            }

            if(loggedInUser.USER_ROLE == "Regular")
            {
                AddUserButton.Visible = false;
                searchTextBox.Visible = false;
                searchButton.Visible = false;
                userDataGridView.Visible = false;
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            UserNameTextBox.Text = "";
            passwordTextBox.Text = "";

            UserPanel.Visible = false;
            LoginPanel.Visible = true;
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(userDataGridView);
            addUserForm.Visible = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string item = searchTextBox.Text;
            if(item.Length == 0)
            {
                userDataGridView.DataSource = userData.QueryAll();
                return;
            }

            userDataGridView.DataSource = userData.QueryByItem(item);
        }

        private void userDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow userDataGridViewRow = userDataGridView.Rows[e.RowIndex];

            DeleteOrEditUserForm deleteOrEditForm = new DeleteOrEditUserForm((int)userDataGridViewRow.Cells[0].Value, userDataGridView);

            deleteOrEditForm.userIDLabel.Text = (string)userDataGridViewRow.Cells[0].Value.ToString();
            deleteOrEditForm.userNameTextBox.Text = (string)userDataGridViewRow.Cells[1].Value;
            deleteOrEditForm.userEMailTextBox.Text = (string)userDataGridViewRow.Cells[2].Value;

            deleteOrEditForm.Show();
        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            AddTaskForm addTask = new AddTaskForm(loggedInUser, taskDataGridView);
            addTask.Show();
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

        private void TaskSearchButton_Click(object sender, EventArgs e)
        {
            string queryItem = TaskSearch.Text;
            
            int querInt = 0;
            int.TryParse(queryItem, out querInt);

            if(queryItem.Length > 0)
            {
                var searchRes = from item in gridItemList
                                where item.TASK_ID == querInt ||
                                Contains(item.ASSIGNED_TO, queryItem) ||
                                Contains(item.ASSIGNED_BY, queryItem) ||
                                Contains(item.TASK_TITLE, queryItem) ||
                                Contains(item.TASK_DETAILS, queryItem)
                                select item;

                taskDataGridView.DataSource = searchRes.ToList();
            }
            else
            {
                initTaskDataGridView(userData.QueryAll(), taskData.QueryAll());
            }
        }

        private void taskDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TaskDataGridItem taskDataGridItem = new TaskDataGridItem();
            DataGridViewRow taskGridRow = taskDataGridView.Rows[e.RowIndex];

            taskDataGridItem.TASK_ID = (int)taskGridRow.Cells["TASK_ID"].Value;
            taskDataGridItem.ASSIGNED_TO = (string)taskGridRow.Cells["ASSIGNED_TO"].Value;
            taskDataGridItem.ASSIGNED_BY = (string)taskGridRow.Cells["ASSIGNED_BY"].Value;
            taskDataGridItem.TASK_TITLE = (string)taskGridRow.Cells["TASK_TITLE"].Value;
            taskDataGridItem.TASK_DETAILS = (string)taskGridRow.Cells["TASK_DETAILS"].Value;
            taskDataGridItem.ISSUE_DATE = (DateTime)taskGridRow.Cells["ISSUE_DATE"].Value;
            taskDataGridItem.DUE_DATE = (DateTime)taskGridRow.Cells["DUE_DATE"].Value;
            taskDataGridItem.SEND_EMAIL = (bool)taskGridRow.Cells["SEND_EMAIL"].Value;

            DeleteOrEditTaskForm taskDeleteOrEdit = new DeleteOrEditTaskForm(taskDataGridItem, taskDataGridView);
            taskDeleteOrEdit.Show();
        }

        private void SearchByDateButton_Click(object sender, EventArgs e)
        {
            var dateSearchResult = from task in taskData.QueryAll()
                                   where task.ISSUE_DATE >= DateFrom.Value.Date && task.ISSUE_DATE <= DateTo.Value.Date
                                   || task.DUE_DATE >= DateFrom.Value.Date && task.DUE_DATE <= DateTo.Value.Date
                                   select task;

            taskDataGridView.DataSource = dateSearchResult.ToList();
        }

        private bool Contains(string str1, string str2)
        {
            return str1.IndexOf(str2, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
