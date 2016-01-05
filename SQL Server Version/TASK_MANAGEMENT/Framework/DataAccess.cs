using System;
using System.Data;
using System.Data.SqlClient;

namespace Framework
{
    public class DataAccess
    {
        string connectionString = "Data Source=172.16.2.93;Initial Catalog=TASK_MANAGEMENT;Persist Security Info=True;User ID=13-25401-3;Password=25401321";

        public void Execute(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            command.Connection = connection;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable Query(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            connection.Open();
            dataAdapter.Fill(dt);
            connection.Close();

            return dt;
        }
    }
}
