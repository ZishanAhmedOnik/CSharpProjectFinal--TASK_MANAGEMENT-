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
    public partial class AddUserForm : Form
    {
        UserData userData = new UserData();

        DataGridView userDataGridView;

        public AddUserForm(DataGridView gridView)
        {
            InitializeComponent();
            roleComboBox.SelectedIndex = 1;

            userDataGridView = gridView;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(userNameTextBox.Text.Length == 0 && passwordTextBox.Text.Length == 0 && confirmPasswordTextBox.Text.Length == 0)
            {
                MessageBox.Show("Plase fill the \'*\' marked fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            else if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Password text mismatch!, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Text = "";
                confirmPasswordTextBox.Text = "";
            }
            else
            {
                User user = new User();
                user.USER_NAME = userNameTextBox.Text;
                user.USER_ROLE = roleComboBox.SelectedItem.ToString();
                user.PASSWORD = passwordTextBox.Text;
                user.USER_EMAIL = emailTextBox.Text;

                if (userData.Insert(user)) 
                {
                    MessageBox.Show("Data Saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    userDataGridView.DataSource = userData.QueryAll();
                }
                else
                {
                    MessageBox.Show("Data saving failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
