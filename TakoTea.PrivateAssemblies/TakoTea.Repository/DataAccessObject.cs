using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TakoTea.Database;
using TakoTea.Exceptions;

namespace TakoTea.Repository
{
    public class DataAccessObject
    {
        public DataAccessObject()
        {
            // No need to initialize _connection here anymore
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection()) // Open a new connection in the 'using' block
                {
                    // Convert SqlParameter[] to a dictionary or anonymous object
                    Dictionary<string, object> paramObject = parameters.ToDictionary(p => p.ParameterName, p => p.Value);

                    // Execute query using Dapper and pass the parameters as an anonymous object
                    return connection.Query<T>(query, paramObject);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = BuildErrorMessage(ex, query);
                throw new DataAccessException(errorMessage, ex);
            }
        }


        // Generic method to execute a query and return data as DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {

                    using (SqlCommand command = new SqlCommand(query, connection)) // Using SqlCommand inside the connection scope
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader); // Load data from SqlDataReader into DataTable
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                string errorMessage = BuildErrorMessage(ex, query);

                throw new DataAccessException(errorMessage, ex);
            }
            return dataTable;
        }

        // Executes a non-query (e.g., UPDATE, DELETE, INSERT) and returns the number of rows affected
        public int ExecuteNonQueryWithTransaction(string[] queries, SqlParameter[][] parametersArray)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection()) // Open connection in using block
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction()) // Begin transaction inside connection scope
                    {
                        for (int i = 0; i < queries.Length; i++)
                        {
                            using (SqlCommand command = new SqlCommand(queries[i], connection, transaction))
                            {
                                if (parametersArray[i] != null)
                                {
                                    command.Parameters.AddRange(parametersArray[i]);
                                }
                                rowsAffected += command.ExecuteNonQuery(); // Execute each query
                            }
                        }

                        transaction.Commit(); // Commit transaction if no errors
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = BuildErrorMessage(ex, string.Join(";", queries));
                throw new DataAccessException(errorMessage, ex);
            }

            return rowsAffected;
        }

        // Executes a non-query (e.g., UPDATE, DELETE, INSERT) and returns the number of rows affected
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection()) // Open connection in using block
                using (SqlCommand command = new SqlCommand(query, connection)) // SqlCommand inside using block
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    return command.ExecuteNonQuery(); // Execute query and return rows affected
                }
            }
            catch (Exception ex)
            {
                string errorMessage = BuildErrorMessage(ex, query);
                throw new DataAccessException(errorMessage, ex);
            }
        }

        public List<T> MapToList<T>(DataTable dataTable) where T : new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (DataRow row in dataTable.Rows)
                {
                    T obj = new T();
                    foreach (System.Reflection.PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (dataTable.Columns.Contains(prop.Name))
                        {
                            prop.SetValue(obj, row[prop.Name] != DBNull.Value ? row[prop.Name] : null);
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                string errorMessage = BuildErrorMessage(ex, "Mapping DataTable to List");
                throw new DataAccessException(errorMessage, ex);
            }
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection()) // Open connection in using block
                using (SqlCommand command = new SqlCommand(query, connection)) // SqlCommand inside using block
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    return command.ExecuteScalar();  // Executes query and returns the first column of the first row
                }
            }
            catch (Exception ex)
            {
                string errorMessage = BuildErrorMessage(ex, query);
                throw new DataAccessException(errorMessage, ex);
            }
        }

        public virtual bool UpdateRecord(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection()) // Open connection in using block
                using (SqlCommand command = new SqlCommand(query, connection)) // SqlCommand inside using block
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Returns true if any rows were updated
                }
            }
            catch (Exception ex)
            {
                string errorMessage = BuildErrorMessage(ex, query);
                throw new DataAccessException(errorMessage, ex);
            }
        }

        // Centralized method for error message construction
        private string BuildErrorMessage(Exception ex, string query)
        {
            return $"Error Message: {ex.Message}\n" +
                   $"An error occurred while executing the query.\n" +
                   $"Query: {query}\n" + // Shows which query failed
                   $"Method: {System.Reflection.MethodBase.GetCurrentMethod().Name}\n" +
                   $"Class: {GetType().Name}\n" +
                   $"Caller Method: {new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name}"; // Indicates where the query originated from
        }
    }
}
