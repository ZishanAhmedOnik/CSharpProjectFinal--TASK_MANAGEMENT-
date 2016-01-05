using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Framework;
using Entities;

namespace DataLayer
{
    public class UserData
    {
        DataAccess dataAccess = new DataAccess();

        public bool Insert(User userObj)
        {
            string insertQuery = "INSERT INTO [USER](USER_NAME, USER_EMAIL, PASSWORD, USER_ROLE)"
                                + "VALUES(@USER_NAME, @USER_EMAIL, @PASSWORD, @USER_ROLE)";

            SqlCommand insertCommand = new SqlCommand(insertQuery);

            SqlParameter userNameParam = new SqlParameter("@USER_NAME", SqlDbType.VarChar, 50);
            userNameParam.Value = userObj.USER_NAME;

            SqlParameter userEmailParam = new SqlParameter("@USER_EMAIL", SqlDbType.VarChar, 50);
            userEmailParam.Value = userObj.USER_EMAIL;

            SqlParameter userPasswordParam = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50);
            userPasswordParam.Value = userObj.PASSWORD;

            SqlParameter userRoleParam = new SqlParameter("@USER_ROLE", SqlDbType.VarChar, 10);
            userRoleParam.Value = userObj.USER_ROLE;

            insertCommand.Parameters.Add(userNameParam);
            insertCommand.Parameters.Add(userEmailParam);
            insertCommand.Parameters.Add(userPasswordParam);
            insertCommand.Parameters.Add(userRoleParam);

            try
            {
                dataAccess.Execute(insertCommand);
            }
            catch(SqlException)
            {
                return false;
            }
            
            return true;
        }

        public void Delete(int id)
        {
            string deleteQuery = "DELETE FROM [USER] WHERE USER_ID = @ID";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery);

            SqlParameter userIDParam = new SqlParameter("@ID", SqlDbType.Int);
            userIDParam.Value = id;

            deleteCommand.Parameters.Add(userIDParam);

            dataAccess.Execute(deleteCommand);
        }

        public void Update(User userObj, int ID)
        {
            string updateQuery = "UPDATE [USER] SET USER_NAME = @USER_NAME," + 
                                   "USER_EMAIL = @USER_EMAIL, PASSWORD = @PASSWORD, "+ 
                                   "USER_ROLE = @USER_ROLE WHERE USER_ID = @USER_ID";

            SqlCommand updateCommand = new SqlCommand(updateQuery);

            SqlParameter userNameParam = new SqlParameter("@USER_NAME", SqlDbType.VarChar, 50);
            userNameParam.Value = userObj.USER_NAME;

            SqlParameter userEmailParam = new SqlParameter("@USER_EMAIL", SqlDbType.VarChar, 50);
            userEmailParam.Value = userObj.USER_EMAIL;

            SqlParameter userPasswordParam = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50);
            userPasswordParam.Value = userObj.PASSWORD;

            SqlParameter userRoleParam = new SqlParameter("@USER_ROLE", SqlDbType.VarChar, 50);
            userRoleParam.Value = userObj.USER_ROLE;

            SqlParameter idParam = new SqlParameter("@USER_ID", SqlDbType.Int);
            idParam.Value = ID;

            updateCommand.Parameters.Add(userNameParam);
            updateCommand.Parameters.Add(userEmailParam);
            updateCommand.Parameters.Add(userPasswordParam);
            updateCommand.Parameters.Add(userRoleParam);
            updateCommand.Parameters.Add(idParam);

            dataAccess.Execute(updateCommand);
        }

        public User UserLogin(string userName, string password)
        {
            User loggedInUserInfo = new User();
            DataTable loggedInUser = new DataTable();

            string loginQuery = "SELECT * FROM [USER] WHERE USER_NAME = @USER_NAME AND PASSWORD = @USER_PASSWORD";

            SqlCommand loginCommand = new SqlCommand(loginQuery);

            SqlParameter userNameParam = new SqlParameter("@USER_NAME", SqlDbType.VarChar, 50);
            userNameParam.Value = userName;

            SqlParameter passwordParam = new SqlParameter("@USER_PASSWORD", SqlDbType.VarChar, 50);
            passwordParam.Value = password;

            loginCommand.Parameters.Add(userNameParam);
            loginCommand.Parameters.Add(passwordParam);

            loggedInUser = dataAccess.Query(loginCommand);

            if (loggedInUser.Rows.Count > 0)
            {
                loggedInUserInfo.USER_ID = (int)loggedInUser.Rows[0][0];
                loggedInUserInfo.USER_NAME = (string)loggedInUser.Rows[0][1];
                loggedInUserInfo.USER_EMAIL = (loggedInUser.Rows[0][2] == DBNull.Value) ? string.Empty : loggedInUser.Rows[0][2].ToString();
                loggedInUserInfo.PASSWORD = (string)loggedInUser.Rows[0][3];
                loggedInUserInfo.USER_ROLE = (string)loggedInUser.Rows[0][4];

                return loggedInUserInfo;
            }

            return null;
        }

        public List<UserDataGridItem> QueryAll()
        {
            DataTable dataTable = new DataTable();
            List<UserDataGridItem> userList = new List<UserDataGridItem>();

            SqlCommand query = new SqlCommand("SELECT * FROM [USER]");

            dataTable = dataAccess.Query(query);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                UserDataGridItem userObject = new UserDataGridItem();

                userObject.USER_ID = (int)dataTable.Rows[i][0];
                userObject.USER_NAME = (string)dataTable.Rows[i][1];
                userObject.USER_EMAIL = (dataTable.Rows[i][2] == DBNull.Value) ? string.Empty : dataTable.Rows[i][2].ToString();
                userObject.USER_ROLE = (string)dataTable.Rows[i][4];

                userList.Add(userObject);
            }

            return userList;
        }

        public List<UserDataGridItem> QueryByItem(string item)
        {
            DataTable dataTable = new DataTable();
            List<UserDataGridItem> userList = new List<UserDataGridItem>();

            string query = "SELECT * FROM [USER] WHERE USER_ID = @USER_ID"
                            +" OR USER_NAME LIKE @USER_NAME OR USER_EMAIL LIKE @USER_EMAIL"
                            + " OR USER_ROLE LIKE @USER_ROLE";

            SqlCommand queryCommand = new SqlCommand(query);

            SqlParameter userIDParam = new SqlParameter("@USER_ID", SqlDbType.Int);
            int intValOfitem = 0;
            int.TryParse(item, out intValOfitem);
            userIDParam.Value = intValOfitem;

            SqlParameter userNameParam = new SqlParameter("@USER_NAME", SqlDbType.VarChar, 50);
            userNameParam.Value = "%" + item + "%";

            SqlParameter userEmailParam = new SqlParameter("@USER_EMAIL", SqlDbType.VarChar, 50);
            userEmailParam.Value = "%" + item + "%";

            SqlParameter userRoleParam = new SqlParameter("@USER_ROLE", SqlDbType.VarChar, 50);
            userRoleParam.Value = "%" + item + "%";

            queryCommand.Parameters.Add(userIDParam);
            queryCommand.Parameters.Add(userNameParam);
            queryCommand.Parameters.Add(userEmailParam);
            queryCommand.Parameters.Add(userRoleParam);

            dataTable = dataAccess.Query(queryCommand);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                UserDataGridItem userObj = new UserDataGridItem();

                userObj.USER_ID = (int)dataTable.Rows[i][0];
                userObj.USER_NAME = (string)dataTable.Rows[i][1];
                userObj.USER_EMAIL = (dataTable.Rows[i][2] == DBNull.Value) ? string.Empty : dataTable.Rows[i][2].ToString();
                userObj.USER_ROLE = (string)dataTable.Rows[i][4];

                userList.Add(userObj);
            }

            return userList;
        }

        public User QueryByID(int userID)
        {
            DataTable userDataTable = new DataTable();

            string queryByID = "SELECT * FROM [USER] WHERE USER_ID = @USER_ID";
            SqlCommand queryByIDCommand = new SqlCommand(queryByID);

            SqlParameter userIDParam = new SqlParameter("@USER_ID", SqlDbType.Int);
            userIDParam.Value = userID;

            queryByIDCommand.Parameters.Add(userIDParam);

            userDataTable = dataAccess.Query(queryByIDCommand);

            User userInfo = new User();

            userInfo.USER_ID = (int)userDataTable.Rows[0][0];
            userInfo.USER_NAME = (string)userDataTable.Rows[0][1];
            userInfo.USER_EMAIL = (string)userDataTable.Rows[0][2];
            userInfo.PASSWORD = (string)userDataTable.Rows[0][3];
            userInfo.USER_ROLE = (string)userDataTable.Rows[0][4];

            return userInfo;
        }
    }
}
