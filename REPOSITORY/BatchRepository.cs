using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.REPOSITORY
{
    public class BatchRepository
    {
        private readonly DataAccessObject _dao;

        public BatchRepository(DataAccessObject dao)
        {
            _dao = dao;
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




    }
}
