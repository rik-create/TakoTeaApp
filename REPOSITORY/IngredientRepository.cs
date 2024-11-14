using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TakoTea.Controller.DATABASE;
using TakoTea.HELPERS;
using TakoTea.View.Stock;

namespace TakoTea.Repository
{
    public class IngredientRepository
    {
        private readonly string _connectionString;

        public IngredientRepository()
        {
            _connectionString = DatabaseConnection.Instance.GetConnection().ConnectionString; // Retrieve connection string once
        }

        public DataTable GetCurrentStockLevels()
        {
            string query = @"
            SELECT 
                i.IngredientName,
                b.QuantityInStock,
                i.MeasuringUnit,
                b.ReorderLevel
            FROM 
                Ingredient i
            JOIN 
                Batch b ON i.IngredientID = b.IngredientID
            WHERE 
                b.IsActive = 1";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var dataTable = new DataTable();
                dataTable.Load(connection.ExecuteReader(query));  // Load data into DataTable
                return dataTable;
            }
        }



    }
}
