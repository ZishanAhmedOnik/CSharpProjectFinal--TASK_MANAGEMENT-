using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using Entities;

namespace UserInterface
{
    public partial class DeleteOrEditUserForm : Form
    {
        public int userID;
        DataGridView userDataGridView;

        UserData userData = new UserData();

        public DeleteOrEditUserForm(int userIDParam, DataGridView dataGridView)
        {
            InitializeComponent();

            userID = userIDParam;
            userDataGridView = dataGridView;
        }

        private void DeleteOrEditUserForm_Load(object sender, EventArgs e)
        {
            User user = userData.QueryByID(userID);

            userIDLabel.Text = user.USER_ID.ToString();
            userNameTextBox.Text = user.USER_NAME;
            userEMailTextBox.Text = user.USER_EMAIL;
            passwordTextBox.Text = user.PASSWORD;
            confirmPasswordTextBox.Text = user.PASSWORD;
            userRoleComboBox.Text = user.USER_ROLE;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                userData.Delete(userID);
                userDataGridView.DataSource = userData.QueryAll();
            }
            else
            {
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(passwordTextBox.Text == confirmPasswordTextBox.Text)
            {
                User userInfo = new User();

                userInfo.USER_NAME = userNameTextBox.Text;
                userInfo.USER_EMAIL = userEMailTextBox.Text;
                userInfo.PASSWORD = passwordTextBox.Text;
                userInfo.USER_ROLE = userRoleComboBox.Text;

                userData.Update(userInfo, userID);

                userDataGridView.DataSource = userData.QueryAll();
            }
        }
    }
}
