using Dapper;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using TakoTea.Database;
using TakoTea.Models;
namespace TakoTea.Repository
{
    public class BatchRepository
    {
        private readonly DataAccessObject _dao;
        private readonly Entities _context;

        public BatchRepository(DataAccessObject dao)
        {
            _dao = dao;
            _context = new Entities();
        }

        public List<object> GetAllBatches()
        {
            try
            {
                // Query to fetch the batch data and join with Ingredients
                var batchList = _context.Batches
                    .Join(
                        _context.Ingredients, // Join Batches with Ingredients
                        batch => batch.IngredientID, // Foreign key in Batches
                        ingredient => ingredient.IngredientID, // Primary key in Ingredients
                        (batch, ingredient) => new
                        {
                            batch.BatchNumber,
                            IngredientName = ingredient.IngredientName, // Get IngredientName from Ingredients table
                            batch.StockLevel,
                            batch.ExpirationDate,
                            batch.BatchCost,
                            Active = batch.IsActive.HasValue && batch.IsActive.Value ? "Yes" : "No"
                        })
                    .ToList<object>(); // Cast to List<object> to match the return type

                return batchList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading batches: " + ex.Message);
            }
        }

        public void UpdateBatchStockLevel(int ingredientID, decimal newQuantity)
        {
            const string query = @"
        UPDATE Batch
        SET QuantityInStock = @NewQuantity
        WHERE IngredientID = @IngredientID;
    ";
            // Use a using statement to handle the connection lifecycle
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                _ = connection.Execute(query, new { IngredientID = ingredientID, NewQuantity = newQuantity });
            }
        }

        public IngredientModel GetIngredientById(int ingredientId)
        {
            string query = "SELECT * FROM Ingredient WHERE IngredientID = @IngredientID";
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@IngredientID", ingredientId)
            };

            // Execute the query to retrieve the ingredient data
            var result = _dao.ExecuteQuery<IngredientModel>(query, parameters);
            return result.FirstOrDefault();
        }

        public string GetIngredientNameById(int ingredientId)
        {
            string query = "SELECT IngredientName FROM Ingredient WHERE IngredientID = @IngredientID";
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@IngredientID", ingredientId)
            };

            // Execute the query to retrieve the ingredient name
            var result = _dao.ExecuteQuery<string>(query, parameters);
            return result.FirstOrDefault();
        }

        public decimal GetPreviousQuantity(int ingredientId)
        {
            string query = "SELECT QuantityInStock FROM Batch WHERE IngredientID = @IngredientID AND IsActive = 1";
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@IngredientID", ingredientId)
            };

            // Execute the query to retrieve the previous quantity in stock
            var result = _dao.ExecuteQuery<decimal>(query, parameters);
            return result.FirstOrDefault();
        }


        public DataTable GetCurrentStockLevels()
        {
            string query = @"
    SELECT 
        i.IngredientID, 
        i.IngredientName,
        b.QuantityInStock,
        b.ReorderLevel
    FROM 
        Ingredient i
    JOIN 
        Batch b ON i.IngredientID = b.IngredientID
    WHERE 
        b.IsActive = 1";
            return _dao.ExecuteQuery(query);
        }

        // Method to get a batch by its ID
        public BatchModel GetBatchById(int batchId)
        {
            string query = "SELECT * FROM Batch WHERE BatchID = @BatchID";  // Adjust the query to your database schema
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@BatchID", batchId)
            };

            // Execute the query to retrieve the batch data
            var result = _dao.ExecuteQuery<BatchModel>(query, parameters);
            return result.FirstOrDefault();
        }

        // Get all active batches with their stock levels
        public DataTable GetAllActiveBatches()
        {
            string query = @"
                SELECT 
                    b.BatchID, 
                    b.IngredientID, 
                    i.IngredientName, 
                    b.QuantityInStock, 
                    b.ReorderLevel, 
                    b.ExpirationDate,   -- Include ExpirationDate
                    b.IsActive   
                FROM 
                    Batch b
                JOIN 
                    Ingredient i ON b.IngredientID = i.IngredientID
                WHERE 
                    b.IsActive = 1";
            // Using _dao.ExecuteQuery to return the DataTable
            return _dao.ExecuteQuery(query);
        }
        public DataTable GetBatchByIngredientId(int ingredientId)
        {
            string query = "SELECT BatchID, IngredientID, QuantityInStock FROM Batch WHERE IngredientID = @IngredientID";
            // Create the SqlParameter for the query
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@IngredientID", SqlDbType.Int) { Value = ingredientId }
            };
            return _dao.ExecuteQuery(query, parameters);
        }
        public bool UpdateBatchStock(int batchId, decimal newStockLevel)
        {
            string query = "UPDATE Batch SET QuantityInStock = @NewStockLevel WHERE BatchID = @BatchID";
            // Create the SqlParameters for the query
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@NewStockLevel", SqlDbType.Decimal) { Value = newStockLevel },
            new SqlParameter("@BatchID", SqlDbType.Int) { Value = batchId }
            };
            // Execute the update query
            int rowsAffected = _dao.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        // Save new batch to the database using Dapper
        public bool SaveBatch(BatchModel batch)
        {
            string updateQuery = @"
        UPDATE Batch
        SET 
            QuantityInStock = @QuantityInStock, 
            BatchCost = @Cost, 
            ReorderLevel = @ReorderLevel, 
            ExpirationDate = @ExpirationDate, 
            IsActive = @IsActive
        WHERE BatchNumber = @BatchNumber";

            SqlParameter[] updateParameters = new SqlParameter[]
            {
        new SqlParameter("@BatchNumber", SqlDbType.NVarChar) { Value = batch.BatchNumber },
        new SqlParameter("@QuantityInStock", SqlDbType.Decimal) { Value = batch.QuantityInStock },
        new SqlParameter("@IngredientID", SqlDbType.Int) { Value = batch.IngredientID },
        new SqlParameter("@IsActive", SqlDbType.Int) { Value = 1 }
            };

            // Use the UpdateRecord method from the DataAccessObject class
            return _dao.UpdateRecord(updateQuery, updateParameters);
        }

    }

}
