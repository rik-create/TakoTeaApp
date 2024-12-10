using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace TakoTea.Database
{
    public static class DatabaseConnection
    {
        private static SqlConnection _connection;
        private static readonly string _connectionString = "data source=192.168.100.12,1433;initial catalog=TakoTea;user id=erick;password=1234;encrypt=False;MultipleActiveResultSets=True;Integrated Security=True;";


        public static string GetConnectionString()
        {
            return _connectionString;
        }

        public static SqlConnection GetConnection()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }
        public static void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        public static void DisposeConnection()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
        public static void ExecuteCommand(string query)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        _ = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
