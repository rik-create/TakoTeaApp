using Dapper;
using System;
using System.Data;
using TakoTea.Database;
using TakoTea.Interfaces;

namespace TakoTea.Repository
{
    public class StockAdjustmentRepository : IStockAdjustmentRepository
    {
        private readonly BatchRepository _batchRepository;  // Changed from IngredientRepository to BatchRepository

        public StockAdjustmentRepository(BatchRepository batchRepository)  // Constructor now takes BatchRepository
        {
            _batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));
        }

        public bool RecordAdjustment(
            int batchId,  // Changed ingredientId to batchId
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

            // SQL query to record the batch stock adjustment
            const string sql = @"
                INSERT INTO StockAdjustmentLog 
                (BatchID, AdjustmentQuantity, Reason, UserID, AdjustmentDate, PreviousQuantity, NewQuantity)
                VALUES 
                (@BatchID, @AdjustmentQuantity, @Reason, @UserID, @AdjustmentDate, @PreviousQuantity, @NewQuantity);";

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    // Execute the query using Dapper
                    connection.Execute(sql, new
                    {
                        BatchID = batchId,  // Using batchId instead of ingredientId
                        AdjustmentQuantity = adjustmentQuantity,
                        Reason = reason.Trim(),
                        UserID = userId,
                        AdjustmentDate = adjustmentDate,
                        PreviousQuantity = previousQuantity,
                        NewQuantity = newStockLevel
                    });
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (replace with your logging mechanism)
                Console.Error.WriteLine($"Error recording batch adjustment: {ex.Message}");
                return false;
            }
        }


    }
}
