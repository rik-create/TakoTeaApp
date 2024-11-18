using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TakoTea.Database;
using TakoTea.Exceptions;
namespace TakoTea.Repository
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
            DataTable dataTable = new DataTable();
            int retryCount = 3;  // Set the number of retries
            int delay = 1000;  // Milliseconds between retries (1 second)
            for (int attempt = 0; attempt < retryCount; attempt++)
            {
                try
                {
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }

                    using (SqlCommand command = new SqlCommand(query, _connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                    break;  // If successful, exit the retry loop
                }
                catch (SqlException sqlEx) when (attempt < retryCount - 1)
                {
                    // Log the exception and retry
                    Console.WriteLine($"Attempt {attempt + 1} failed: {sqlEx.Message}");
                    System.Threading.Thread.Sleep(delay);
                }
                catch (Exception ex)
                {
                    throw new DataAccessException("An error occurred while executing the query.", ex);
                }
                finally
                {
                    _connection.Close();
                }
            }
            return dataTable;
        }

        // Executes a non-query (e.g., UPDATE, DELETE, INSERT) and returns the number of rows affected
        public int ExecuteNonQueryWithTransaction(string[] queries, SqlParameter[][] parametersArray)
        {
            int rowsAffected = 0;
            SqlTransaction transaction = null;
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                transaction = _connection.BeginTransaction();

                for (int i = 0; i < queries.Length; i++)
                {
                    using (SqlCommand command = new SqlCommand(queries[i], _connection, transaction))
                    {
                        if (parametersArray[i] != null)
                        {
                            command.Parameters.AddRange(parametersArray[i]);
                        }
                        rowsAffected += command.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new DataAccessException("An error occurred while executing the query within a transaction.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return rowsAffected;
        }

        // Executes a non-query (e.g., UPDATE, DELETE, INSERT) and returns the number of rows affected
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlCommand command = new SqlCommand(query, _connection))
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
    

        public List<T> MapToList<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
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

        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    result = command.ExecuteScalar();  // Executes query and returns the first column of the first row
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while executing the scalar query.", ex);
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public virtual bool UpdateRecord(string query, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                try
                {
                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Returns true if any rows were updated
                }
                catch (Exception ex)
                {
                    throw new DataAccessException("An error occurred while updating the record.", ex);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }




    }
}
