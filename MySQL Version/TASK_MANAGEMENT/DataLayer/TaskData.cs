using System;
using System.Collections.Generic;
using System.Data;
using Entities;
using Framework;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class TaskData
    {
        DataAccess dataAccess = new DataAccess();

        public void Insert(Task taskObj)
        {
            string insertQuery = "INSERT INTO TASK(USER_ID, ASSIGNED_BY, TASK_TITLE, TASK_DETAILS, ISSUE_DATE, DUE_DATE, SEND_EMAIL)" + 
                  "VALUES(@USER_ID, @ASSIGNED_BY, @TASK_TITLE, @TASK_DETAILS, @ISSUE_DATE, @DUE_DATE, @SEND_EMAIL)";

            MySqlCommand insertCommand = new MySqlCommand(insertQuery);

            MySqlParameter userIDParam = new MySqlParameter("@USER_ID", MySqlDbType.Int16);
            userIDParam.Value = taskObj.USER_ID;

            MySqlParameter assignedByParam = new MySqlParameter("@ASSIGNED_BY", MySqlDbType.Int16);
            assignedByParam.Value = taskObj.ASSIGNED_BY;

            MySqlParameter taskTitleParam = new MySqlParameter("@TASK_TITLE", MySqlDbType.VarChar, 50);
            taskTitleParam.Value = taskObj.TASK_TITLE;

            MySqlParameter taskDetailsParam = new MySqlParameter("@TASK_DETAILS", MySqlDbType.VarChar, 200);
            taskDetailsParam.Value = taskObj.TASK_DETAILS;

            MySqlParameter issueDateParam = new MySqlParameter("@ISSUE_DATE", MySqlDbType.DateTime);
            issueDateParam.Value = taskObj.ISSUE_DATE;

            MySqlParameter dueDateParam = new MySqlParameter("@DUE_DATE", MySqlDbType.DateTime);
            dueDateParam.Value = taskObj.DUE_DATE;

            MySqlParameter taskSendEmailParam = new MySqlParameter("@SEND_EMAIL", MySqlDbType.Byte);
            taskSendEmailParam.Value = taskObj.SEND_EMAIL;

            insertCommand.Parameters.Add(userIDParam);
            insertCommand.Parameters.Add(assignedByParam);
            insertCommand.Parameters.Add(taskTitleParam);
            insertCommand.Parameters.Add(taskDetailsParam);
            insertCommand.Parameters.Add(issueDateParam);
            insertCommand.Parameters.Add(dueDateParam);
            insertCommand.Parameters.Add(taskSendEmailParam);

            dataAccess.Execute(insertCommand);
        }

        public void Update(Task taskObj, int taskID)
        {
            string updateQuery = "UPDATE TASK SET USER_ID = @USER_ID, ASSIGNED_BY = @ASSIGNED_BY, " +
                                "TASK_TITLE = @TASK_TITLE, TASK_DETAILS = @TASK_DETAILS, " + 
                                "ISSUE_DATE = @ISSUE_DATE, DUE_DATE = @DUE_DATE, SEND_EMAIL = @SEND_EMAIL " +
                                "WHERE TASK_ID = @TASK_ID";

            MySqlCommand updateCommand = new MySqlCommand(updateQuery);

            MySqlParameter userIDParam = new MySqlParameter("@USER_ID", MySqlDbType.Int16);
            userIDParam.Value = taskObj.USER_ID;

            MySqlParameter assignedByParam = new MySqlParameter("@ASSIGNED_BY", MySqlDbType.Int16);
            assignedByParam.Value = taskObj.ASSIGNED_BY;

            MySqlParameter taskTitleParam = new MySqlParameter("@TASK_TITLE", MySqlDbType.VarChar, 50);
            taskTitleParam.Value = taskObj.TASK_TITLE;

            MySqlParameter taskDetailsParam = new MySqlParameter("@TASK_DETAILS", MySqlDbType.VarChar, 200);
            taskDetailsParam.Value = taskObj.TASK_DETAILS;

            MySqlParameter issueDateParam = new MySqlParameter("@ISSUE_DATE", MySqlDbType.DateTime);
            issueDateParam.Value = taskObj.ISSUE_DATE;

            MySqlParameter dueDateParam = new MySqlParameter("@DUE_DATE", MySqlDbType.DateTime);
            dueDateParam.Value = taskObj.DUE_DATE;

            MySqlParameter taskSendEmailParam = new MySqlParameter("@SEND_EMAIL", MySqlDbType.Byte);
            taskSendEmailParam.Value = taskObj.SEND_EMAIL;

            MySqlParameter taskIDParam = new MySqlParameter("@TASK_ID", MySqlDbType.Int64);
            taskIDParam.Value = taskID;

            updateCommand.Parameters.Add(userIDParam);
            updateCommand.Parameters.Add(assignedByParam);
            updateCommand.Parameters.Add(taskTitleParam);
            updateCommand.Parameters.Add(taskDetailsParam);
            updateCommand.Parameters.Add(issueDateParam);
            updateCommand.Parameters.Add(dueDateParam);
            updateCommand.Parameters.Add(taskSendEmailParam);
            updateCommand.Parameters.Add(taskIDParam);

            dataAccess.Execute(updateCommand);
        }

        public void Delete(int taskID)
        {
            string deleteQuery = "DELETE FROM TASK WHERE TASK_ID = @TASK_ID";
            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery);

            MySqlParameter taskIDParam = new MySqlParameter("@TASK_ID", MySqlDbType.Int16);
            taskIDParam.Value = taskID;

            deleteCommand.Parameters.Add(taskIDParam);

            dataAccess.Execute(deleteCommand);
        }

        public List<Task> QueryAll()
        {
            DataTable dataTable = new DataTable();
            List<Task> taskList = new List<Task>();

            string queryAll = "SELECT * FROM TASK";

            MySqlCommand queryAllCommand = new MySqlCommand(queryAll);

            dataTable = dataAccess.Query(queryAllCommand);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Task taskObject = new Task();

                taskObject.TASK_ID = (int)dataTable.Rows[i][0];
                taskObject.USER_ID = (int)dataTable.Rows[i][1];
                taskObject.ASSIGNED_BY = (int)dataTable.Rows[i][2];
                taskObject.TASK_TITLE = (string)dataTable.Rows[i][3];
                taskObject.TASK_DETAILS = (string)dataTable.Rows[i][4];
                taskObject.ISSUE_DATE = (DateTime)dataTable.Rows[i][5];
                taskObject.DUE_DATE = (DateTime)dataTable.Rows[i][6];
                taskObject.SEND_EMAIL = (bool)dataTable.Rows[i][7];

                taskList.Add(taskObject);
            }

            return taskList;
        }

        public List<Task> QueryByItem(string item)
        {
            DataTable dataTable = new DataTable();
            List<Task> taskList = new List<Task>();

            int intValueOfItem = 0;
            int.TryParse(item, out intValueOfItem);

            DateTime itemDatetime;
            DateTime.TryParse(item, out itemDatetime);

            string queryByItem = "SELECT * FROM TASK WHERE TASK_ID = @TASK_ID OR USER_ID = @USER_ID,"
                                + "ASSIGNED_BY = @ASSIGNED_BY OR TASK_TITLE = @TASK_TITLE OR TASK_DETAILS = @TASK_DETAILS OR " + 
                                "ISSUE_DATE = @ISSUE_DATE OR DUE_DATE = @DUE_DATE OR SEND_EMAIL = @SEND_EMAIL";

            MySqlCommand queryCommand = new MySqlCommand(queryByItem);



            MySqlParameter taskIDParam = new MySqlParameter("@TASK_ID", MySqlDbType.Int16);
            taskIDParam.Value = intValueOfItem;

            MySqlParameter userIDParam = new MySqlParameter("@USER_ID", MySqlDbType.Int16);
            userIDParam.Value = intValueOfItem;

            MySqlParameter assignedByParam = new MySqlParameter("@ASSIGNED_BY", MySqlDbType.Int16);
            assignedByParam.Value = intValueOfItem;

            MySqlParameter taskTitleParam = new MySqlParameter("@TASK_TITLE", MySqlDbType.VarChar, 50);
            taskTitleParam.Value = item;

            MySqlParameter taskDetailsParam = new MySqlParameter("@TASK_DETAILS", MySqlDbType.VarChar, 200);
            taskDetailsParam.Value = item;

            MySqlParameter issueDateParam = new MySqlParameter("@ISSUE_DATE", MySqlDbType.DateTime);
            issueDateParam.Value = itemDatetime;

            MySqlParameter dueDateParam = new MySqlParameter("@DUE_DATE", MySqlDbType.DateTime);
            dueDateParam.Value = itemDatetime;

            queryCommand.Parameters.Add(taskIDParam);
            queryCommand.Parameters.Add(userIDParam);
            queryCommand.Parameters.Add(assignedByParam);
            queryCommand.Parameters.Add(taskTitleParam);
            queryCommand.Parameters.Add(taskDetailsParam);
            queryCommand.Parameters.Add(issueDateParam);
            queryCommand.Parameters.Add(dueDateParam);

            dataTable = dataAccess.Query(queryCommand);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Task taskObject = new Task();

                taskObject.TASK_ID = (int)dataTable.Rows[i][0];
                taskObject.USER_ID = (int)dataTable.Rows[i][1];
                taskObject.ASSIGNED_BY = (int)dataTable.Rows[i][2];
                taskObject.TASK_TITLE = (string)dataTable.Rows[i][3];
                taskObject.TASK_DETAILS = (string)dataTable.Rows[i][4];
                taskObject.ISSUE_DATE = (DateTime)dataTable.Rows[i][5];
                taskObject.DUE_DATE = (DateTime)dataTable.Rows[i][6];
                taskObject.SEND_EMAIL = (bool)dataTable.Rows[i][7];
            }

            return taskList;
        }
    }
}
