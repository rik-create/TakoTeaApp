using System;
using System.Data;
using System.Data.SqlClient;
namespace TakoTea.Database
{
    public static class DatabaseConnection
    {
        private static SqlConnection _connection;
        private static readonly string _connectionString = "Data Source=DESKTOP-BJ889Q2\\SQLEXPRESS;Initial Catalog=TakoTea;Integrated Security=True;";
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
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
