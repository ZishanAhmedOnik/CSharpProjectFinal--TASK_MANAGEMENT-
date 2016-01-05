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

        public AddTaskForm(User loggedInUserParam, DataGridView gridView)
        {
            InitializeComponent();

            this.loggedInUser = loggedInUserParam;
            this.taskDataGridView = gridView;
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

            taskDataGridView.DataSource = taskData.QueryAll();

            this.Close();
        }
    }
}
