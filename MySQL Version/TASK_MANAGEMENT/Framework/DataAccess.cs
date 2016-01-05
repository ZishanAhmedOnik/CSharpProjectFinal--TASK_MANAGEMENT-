using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Framework
{
    public class DataAccess
    {
        string connectionString = "server=127.0.0.1;user id=root; password=root; persistsecurityinfo=True;database=task_management;allowuservariables=True";

        public void Execute(MySqlCommand command)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            command.Connection = connection;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable Query(MySqlCommand command)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            command.Connection = connection;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();

            connection.Open();
            dataAdapter.Fill(dt);
            connection.Close();

            return dt;
        }
    }
}
