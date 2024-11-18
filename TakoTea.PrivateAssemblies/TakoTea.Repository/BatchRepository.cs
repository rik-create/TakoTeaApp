using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TakoTea.Models;
namespace TakoTea.Repository
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

        // Save new batch to the database using Dapper
        public bool SaveBatch(BatchModel batch)
        {
            string updateQuery = @"
        UPDATE Batch
        SET 
            QuantityInStock = @QuantityInStock, 
            Cost = @Cost, 
            ReorderLevel = @ReorderLevel, 
            ExpirationDate = @ExpirationDate, 
            ItemDescription = @ItemDescription, 
            BrandName = @BrandName, 
            Vendor = @Vendor, 
            StorageCondition = @StorageCondition, 
            IngredientImage = @IngredientImage, 
            IngredientID = @IngredientID, 
            IngredientType = @IngredientType, 
            IsActive = @IsActive
        WHERE BatchNumber = @BatchNumber";

            SqlParameter[] updateParameters = new SqlParameter[]
            {
        new SqlParameter("@BatchNumber", SqlDbType.NVarChar) { Value = batch.BatchNumber },
        new SqlParameter("@QuantityInStock", SqlDbType.Decimal) { Value = batch.Quantity },
        new SqlParameter("@Cost", SqlDbType.Decimal) { Value = batch.Cost },
        new SqlParameter("@ReorderLevel", SqlDbType.Decimal) { Value = batch.LowLevel },
        new SqlParameter("@ExpirationDate", SqlDbType.DateTime) { Value = batch.Expiration },
        new SqlParameter("@ItemDescription", SqlDbType.NVarChar) { Value = batch.ItemDescription },
        new SqlParameter("@BrandName", SqlDbType.NVarChar) { Value = batch.BrandName },
        new SqlParameter("@Vendor", SqlDbType.NVarChar) { Value = batch.Vendor },
        new SqlParameter("@StorageCondition", SqlDbType.NVarChar) { Value = batch.StorageCondition },
        new SqlParameter("@IngredientImage", SqlDbType.NVarChar) { Value = batch.IngredientImage },
        new SqlParameter("@IngredientID", SqlDbType.Int) { Value = batch.IngredientID },
        new SqlParameter("@IngredientType", SqlDbType.NVarChar) { Value = batch.IngredientType },
        new SqlParameter("@IsActive", SqlDbType.Int) { Value = 1 }
            };

            // Use the UpdateRecord method from the DataAccessObject class
            return _dao.UpdateRecord(updateQuery, updateParameters);
        }

    }

}
