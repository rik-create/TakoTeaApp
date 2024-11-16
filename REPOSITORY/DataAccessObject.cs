using System;
using System.Data;
using System.Data.SqlClient;
using TakoTea.Controller.DATABASE;
using TakoTea.Exceptions;

namespace TakoTea.REPOSITORY
{
    public class DataAccessObject
    {
        private readonly SqlConnection _connection;

        public DataAccessObject()
        {
            _connection = DatabaseConnection.GetConnection();
        }

        // Generic method to execute a query and return data as DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            var dataTable = new DataTable();
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                using (var command = new SqlCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while executing the query.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return dataTable;
        }

        // Executes a non-query (e.g., UPDATE, DELETE, INSERT) and returns the number of rows affected
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (var command = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                _connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Executes the query and returns rows affected
                _connection.Close();

                return rowsAffected;
            }
        }
    }

}
