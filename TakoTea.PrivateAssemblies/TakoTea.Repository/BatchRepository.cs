using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
        public class BatchDTO
        {
            public int BatchID { get; set; }
            public int IngredientID { get; set; }
            public string BatchNumber { get; set; }
            public string IngredientName { get; set; }
            public decimal StockLevel { get; set; }
            public DateTime ExpirationDate { get; set; }
            public decimal BatchCost { get; set; }
            public string Active { get; set; }
        }
        public List<BatchDTO> GetAllBatch()
        {
            try
            {
                List<Batch> batchList = _context.Batches.ToList();
                var batchDTOList = batchList.Select(batch => new BatchDTO
                {
                    BatchID = batch.BatchID,
                    IngredientID = batch.IngredientID ?? 0,
                    BatchNumber = batch.BatchNumber,
                    // Assuming you have a way to get IngredientName from IngredientID
                    IngredientName = GetIngredientName((int)batch.IngredientID),
                    StockLevel = batch.StockLevel,
                    ExpirationDate = batch.ExpirationDate ?? default,
                    BatchCost = batch.BatchCost
                }).ToList();

                return batchDTOList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading Batches: " + ex.Message);
            }
        }

        private string GetIngredientName(int ingredientID)
        {
            // Example using _context:
            return _context.Ingredients.FirstOrDefault(i => i.IngredientID == ingredientID)?.IngredientName;
        }

        public List<object> GetAllBatches()
        {
            try
            {
                // Query to fetch the batch data and join with Ingredients
                List<object> batchList = _context.Batches
                    .Join(
                        _context.Ingredients, // Join Batches with Ingredients
                        batch => batch.IngredientID, // Foreign key in Batches
                        ingredient => ingredient.IngredientID, // Primary key in Ingredients
                        (batch, ingredient) => new
                        {
                            batch.BatchID,
                            batch.IngredientID,
                            batch.BatchNumber,
                            ingredient.IngredientName, // Get IngredientName from Ingredients table
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
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IngredientID", ingredientId)
            };

            // Execute the query to retrieve the ingredient data
            IEnumerable<IngredientModel> result = _dao.ExecuteQuery<IngredientModel>(query, parameters);
            return result.FirstOrDefault();
        }

        public string GetIngredientNameById(int ingredientId)
        {
            string query = "SELECT IngredientName FROM Ingredient WHERE IngredientID = @IngredientID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IngredientID", ingredientId)
            };

            // Execute the query to retrieve the ingredient name
            IEnumerable<string> result = _dao.ExecuteQuery<string>(query, parameters);
            return result.FirstOrDefault();
        }

        public decimal GetPreviousQuantity(int ingredientId)
        {
            string query = "SELECT QuantityInStock FROM Batch WHERE IngredientID = @IngredientID AND IsActive = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IngredientID", ingredientId)
            };

            // Execute the query to retrieve the previous quantity in stock
            IEnumerable<decimal> result = _dao.ExecuteQuery<decimal>(query, parameters);
            return result.FirstOrDefault();
        }


        public DataTable GetCurrentStockLevels()
        {
            try
            {
                var query = from ingredient in _context.Ingredients
                            join batch in _context.Batches on ingredient.IngredientID equals batch.IngredientID
                            where batch.IsActive == true
                            select new
                            {
                                ingredient.IngredientID,
                                ingredient.IngredientName,
                                batch.StockLevel,
                                ingredient.LowLevel
                            };

                DataTable dataTable = new DataTable();
                _ = dataTable.Columns.Add("IngredientID", typeof(int));
                _ = dataTable.Columns.Add("IngredientName", typeof(string));
                _ = dataTable.Columns.Add("StockLevel", typeof(decimal));
                _ = dataTable.Columns.Add("ReorderLevel", typeof(decimal));

                foreach (var item in query)
                {
                    _ = dataTable.Rows.Add(item.IngredientID, item.IngredientName, item.StockLevel, item.LowLevel);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading current stock levels: " + ex.Message);
            }
        }


        public Batch GetBatchByBatchId(int batchID)
        {
            using (Entities context = new Entities()) // Replace YourDbContext
            {
                return context.Batches.Find(batchID);
            }
        }
        // Method to get a batch by its ID
        public BatchModel GetBatchById(int batchId)
        {
            string query = "SELECT * FROM Batch WHERE BatchID = @BatchID";  // Adjust the query to your database schema
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BatchID", batchId)
            };

            // Execute the query to retrieve the batch data
            IEnumerable<BatchModel> result = _dao.ExecuteQuery<BatchModel>(query, parameters);
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
