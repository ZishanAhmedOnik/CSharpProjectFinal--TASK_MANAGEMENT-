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
    public partial class AddTaskForm : Form
    {
        User loggedInUser;
        UserData userData = new UserData();
        TaskData taskData = new TaskData();
        DataGridView taskDataGridView;
        List<TaskDataGridItem> gridItemList;

        public AddTaskForm(User loggedInUserParam, DataGridView gridView, List<TaskDataGridItem> gridli)
        {
            InitializeComponent();

            this.loggedInUser = loggedInUserParam;
            this.taskDataGridView = gridView;

            gridItemList = gridli;
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            AssignedByLabel.Text = loggedInUser.USER_NAME;

            var query = from u in userData.QueryAll() select u.USER_NAME;

            if (loggedInUser.USER_ROLE == "Admin")
            {
                foreach (string uName in query)
                {
                    AssignedToComboBox.Items.Add(uName);
                }
            }
            else
            {
                AssignedToComboBox.Items.Add(loggedInUser.USER_NAME);
                AssignedToComboBox.Text = loggedInUser.USER_NAME;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Task inserTask = new Task();

            var userId = from u in userData.QueryAll() where u.USER_NAME == AssignedToComboBox.Text select u.USER_ID;

            int selectedUser = 0;

            foreach(int sU in userId)
            {
                selectedUser = sU;
            }

            inserTask.USER_ID = selectedUser;
            inserTask.ASSIGNED_BY = loggedInUser.USER_ID;
            inserTask.TASK_TITLE = TaskTitleTextBox.Text;
            inserTask.TASK_DETAILS = DetailsTextBox.Text;
            inserTask.ISSUE_DATE = IssueDatePicker.Value.Date;
            inserTask.DUE_DATE = DueDatePicker.Value.Date;

            if(SendEmailCheckBox.Checked)
            {
                inserTask.SEND_EMAIL = true;
            }
            else
            {
                inserTask.SEND_EMAIL = false;
            }

            taskData.Insert(inserTask);

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
    }
}
