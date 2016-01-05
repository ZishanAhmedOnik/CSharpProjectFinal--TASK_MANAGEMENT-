using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities;
using Framework;

namespace DataLayer
{
    public class TaskData
    {
        DataAccess dataAccess = new DataAccess();

        public void Insert(Task taskObj)
        {
            string insertQuery = "INSERT INTO [TASK](USER_ID, ASSIGNED_BY, TASK_TITLE, TASK_DETAILS, ISSUE_DATE, DUE_DATE, SEND_EMAIL)" + 
                  "VALUES(@USER_ID, @ASSIGNED_BY, @TASK_TITLE, @TASK_DETAILS, @ISSUE_DATE, @DUE_DATE, @SEND_EMAIL)";

            SqlCommand insertCommand = new SqlCommand(insertQuery);

            SqlParameter userIDParam = new SqlParameter("@USER_ID", SqlDbType.Int);
            userIDParam.Value = taskObj.USER_ID;

            SqlParameter assignedByParam = new SqlParameter("@ASSIGNED_BY", SqlDbType.Int);
            assignedByParam.Value = taskObj.ASSIGNED_BY;

            SqlParameter taskTitleParam = new SqlParameter("@TASK_TITLE", SqlDbType.VarChar, 50);
            taskTitleParam.Value = taskObj.TASK_TITLE;

            SqlParameter taskDetailsParam = new SqlParameter("@TASK_DETAILS", SqlDbType.VarChar, 200);
            taskDetailsParam.Value = taskObj.TASK_DETAILS;

            SqlParameter issueDateParam = new SqlParameter("@ISSUE_DATE", SqlDbType.DateTime);
            issueDateParam.Value = taskObj.ISSUE_DATE;

            SqlParameter dueDateParam = new SqlParameter("@DUE_DATE", SqlDbType.DateTime);
            dueDateParam.Value = taskObj.DUE_DATE;

            SqlParameter taskSendEmailParam = new SqlParameter("@SEND_EMAIL", SqlDbType.Bit);
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
            string updateQuery = "UPDATE [TASK] SET USER_ID = @USER_ID, ASSIGNED_BY = @ASSIGNED_BY, " +
                                "TASK_TITLE = @TASK_TITLE, TASK_DETAILS = @TASK_DETAILS, " + 
                                "ISSUE_DATE = @ISSUE_DATE, DUE_DATE = @DUE_DATE, SEND_EMAIL = @SEND_EMAIL, " +
                                "NOTIFIED = @NOTIFIED " +
                                "WHERE TASK_ID = @TASK_ID";

            SqlCommand updateCommand = new SqlCommand(updateQuery);

            SqlParameter userIDParam = new SqlParameter("@USER_ID", SqlDbType.Int);
            userIDParam.Value = taskObj.USER_ID;

            SqlParameter assignedByParam = new SqlParameter("@ASSIGNED_BY", SqlDbType.Int);
            assignedByParam.Value = taskObj.ASSIGNED_BY;

            SqlParameter taskTitleParam = new SqlParameter("@TASK_TITLE", SqlDbType.VarChar, 50);
            taskTitleParam.Value = taskObj.TASK_TITLE;

            SqlParameter taskDetailsParam = new SqlParameter("@TASK_DETAILS", SqlDbType.VarChar, 200);
            taskDetailsParam.Value = taskObj.TASK_DETAILS;

            SqlParameter issueDateParam = new SqlParameter("@ISSUE_DATE", SqlDbType.DateTime);
            issueDateParam.Value = taskObj.ISSUE_DATE;

            SqlParameter dueDateParam = new SqlParameter("@DUE_DATE", SqlDbType.DateTime);
            dueDateParam.Value = taskObj.DUE_DATE;

            SqlParameter taskSendEmailParam = new SqlParameter("@SEND_EMAIL", SqlDbType.Bit);
            taskSendEmailParam.Value = taskObj.SEND_EMAIL;

            SqlParameter notifiedParam = new SqlParameter("@NOTIFIED", SqlDbType.Bit);
            notifiedParam.Value = taskObj.NOTIFIED;

            SqlParameter taskIDParam = new SqlParameter("@TASK_ID", SqlDbType.Int);
            taskIDParam.Value = taskID;

            updateCommand.Parameters.Add(userIDParam);
            updateCommand.Parameters.Add(assignedByParam);
            updateCommand.Parameters.Add(taskTitleParam);
            updateCommand.Parameters.Add(taskDetailsParam);
            updateCommand.Parameters.Add(issueDateParam);
            updateCommand.Parameters.Add(dueDateParam);
            updateCommand.Parameters.Add(taskSendEmailParam);
            updateCommand.Parameters.Add(notifiedParam);
            updateCommand.Parameters.Add(taskIDParam);

            dataAccess.Execute(updateCommand);
        }

        public void Delete(int taskID)
        {
            string deleteQuery = "DELETE FROM [TASK] WHERE TASK_ID = @TASK_ID";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery);

            SqlParameter taskIDParam = new SqlParameter("@TASK_ID", SqlDbType.Int);
            taskIDParam.Value = taskID;

            deleteCommand.Parameters.Add(taskIDParam);

            dataAccess.Execute(deleteCommand);
        }

        public List<Task> QueryAll()
        {
            DataTable dataTable = new DataTable();
            List<Task> taskList = new List<Task>();

            string queryAll = "SELECT * FROM [TASK]";

            SqlCommand queryAllCommand = new SqlCommand(queryAll);

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
                taskObject.NOTIFIED = (bool)dataTable.Rows[i][8];

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

            string queryByItem = "SELECT * FROM [TASK] WHERE TASK_ID = @TASK_ID OR USER_ID = @USER_ID,"
                                + "ASSIGNED_BY = @ASSIGNED_BY OR TASK_TITLE = @TASK_TITLE OR TASK_DETAILS = @TASK_DETAILS OR " + 
                                "ISSUE_DATE = @ISSUE_DATE OR DUE_DATE = @DUE_DATE OR SEND_EMAIL = @SEND_EMAIL";

            SqlCommand queryCommand = new SqlCommand(queryByItem);



            SqlParameter taskIDParam = new SqlParameter("@TASK_ID", SqlDbType.Int);
            taskIDParam.Value = intValueOfItem;

            SqlParameter userIDParam = new SqlParameter("@USER_ID", SqlDbType.Int);
            userIDParam.Value = intValueOfItem;

            SqlParameter assignedByParam = new SqlParameter("@ASSIGNED_BY", SqlDbType.Int);
            assignedByParam.Value = intValueOfItem;

            SqlParameter taskTitleParam = new SqlParameter("@TASK_TITLE", SqlDbType.VarChar, 50);
            taskTitleParam.Value = item;

            SqlParameter taskDetailsParam = new SqlParameter("@TASK_DETAILS", SqlDbType.VarChar, 200);
            taskDetailsParam.Value = item;

            SqlParameter issueDateParam = new SqlParameter("@ISSUE_DATE", SqlDbType.DateTime);
            issueDateParam.Value = itemDatetime;

            SqlParameter dueDateParam = new SqlParameter("@DUE_DATE", SqlDbType.DateTime);
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
