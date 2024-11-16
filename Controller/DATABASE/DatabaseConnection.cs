using System;
using System.Data;
using System.Data.SqlClient;

namespace TakoTea.Controller.DATABASE
{
    public class DatabaseConnection
    {
        private static SqlConnection _connection;
        private static readonly string _connectionString = "Data Source=DESKTOP-BJ889Q2\\SQLEXPRESS;Initial Catalog=TakoTea;Integrated Security=True;";

        // Method to get an open connection
        public static SqlConnection GetConnection()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();  // Open connection if it was not already open
            }
            return _connection;
        }

        // Method to automatically close connection after use
        public static void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        // Method to dispose the connection when done (free up resources)
        public static void DisposeConnection()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        // Method to ensure the connection is always closed after use, and prevent duplicates
        public static void ExecuteCommand(string query)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging or rethrow)
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Ensure connection is always closed
                CloseConnection();
            }
        }
    }
}
