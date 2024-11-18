using Dapper;
using System;
using System.Data;
using TakoTea.Database;
using TakoTea.Interfaces;
namespace TakoTea.Repository
{
    public class StockAdjustmentRepository : IStockAdjustmentRepository
    {
        private readonly IngredientRepository _ingredientRepository;
        public StockAdjustmentRepository(IngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        }
        public bool RecordAdjustment(
            int ingredientId,
            decimal adjustmentQuantity,
            string reason,
            decimal previousQuantity,
            decimal newStockLevel,
            int userId,
            DateTime adjustmentDate)
        {
            // Validate input parameters
            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException("Reason cannot be null or empty.", nameof(reason));
            }
            if (adjustmentQuantity == 0)
            {
                throw new ArgumentException("Adjustment quantity cannot be zero.", nameof(adjustmentQuantity));
            }
            if (newStockLevel < 0)
            {
                throw new ArgumentException("New stock level cannot be negative.", nameof(newStockLevel));
            }
            const string sql = @"
                INSERT INTO StockAdjustmentLog 
                (IngredientID, AdjustmentQuantity, Reason, UserID, AdjustmentDate, PreviousQuantity, NewQuantity)
                VALUES 
                (@IngredientID, @AdjustmentQuantity, @Reason, @UserID, @AdjustmentDate, @PreviousQuantity, @NewQuantity);";
            try
            {
                using (System.Data.SqlClient.SqlConnection connection = DatabaseConnection.GetConnection())
                using (IDataReader reader = connection.ExecuteReader(sql, new
                {
                    IngredientID = ingredientId,
                    AdjustmentQuantity = adjustmentQuantity,
                    Reason = reason.Trim(),
                    UserID = userId,
                    AdjustmentDate = adjustmentDate,
                    PreviousQuantity = previousQuantity,
                    NewQuantity = newStockLevel
                }))
                {
                    // Optional: Log or validate execution if needed
                }
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (replace with your logging mechanism)
                Console.Error.WriteLine($"Error recording adjustment: {ex.Message}");
                return false;
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            using (System.Data.SqlClient.SqlConnection connection = DatabaseConnection.GetConnection())
            {
                // Execute the query and load the result into a DataTable
                using (IDataReader reader = connection.ExecuteReader(query))
                using (DataTable dataTable = new DataTable())
                {
                    dataTable.Load(reader); // Load data from the SqlDataReader
                    return dataTable;
                }
            }
        }
    }
}
