using System;
using System.Data;
using TakoTea.Interfaces;
using TakoTea.Repository;

namespace TakoTea.Services
{
    public class StockService : IStockService
    {
        private readonly BatchRepository _batchRepository;  // Changed from IIngredientRepository to IBatchRepository
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;

        public StockService(BatchRepository batchRepository, IStockAdjustmentRepository stockAdjustmentRepository)  // Updated constructor
        {
            _batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));
            _stockAdjustmentRepository = stockAdjustmentRepository ?? throw new ArgumentNullException(nameof(stockAdjustmentRepository));
        }

        // Get current stock levels for batches
        public DataTable GetCurrentStockLevels()
        {
            return _batchRepository.GetCurrentStockLevels();  // Updated to use BatchRepository
        }

        // Adjust stock for a batch
        public void AdjustBatchStock(int batchId, decimal newStockLevel, string reason, int userId)
        {
            if (batchId <= 0)
            {
                throw new ArgumentException("Batch ID must be greater than zero.", nameof(batchId));
            }
            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException("Reason cannot be null or empty.", nameof(reason));
            }
            if (newStockLevel < 0)
            {
                throw new ArgumentException("New stock level cannot be negative.", nameof(newStockLevel));
            }

            // Retrieve the current stock level for the batch
            decimal currentStockLevel = _batchRepository.GetPreviousQuantity(batchId);
            if (currentStockLevel == default)
            {
                throw new InvalidOperationException("Batch not found or has no stock data.");
            }

            // Calculate the adjustment quantity
            decimal adjustmentQuantity = newStockLevel - currentStockLevel;

            // Prepare the adjustment date
            DateTime adjustmentDate = DateTime.UtcNow;

            // Record the batch stock adjustment
            bool success = _stockAdjustmentRepository.RecordAdjustment(
                batchId,  // Use batchId instead of ingredientId
                adjustmentQuantity,
                reason,
                currentStockLevel,
                newStockLevel,
                userId,
                adjustmentDate
            );

            if (!success)
            {
                throw new InvalidOperationException("Failed to record stock adjustment.");
            }

            // Update stock level in the batch repository
            _batchRepository.UpdateBatchStockLevel(batchId, newStockLevel);
        }

        // Validate adjustment data
        public void ValidateAdjustment(decimal adjustmentQuantity, string reason)
        {
            if (string.IsNullOrEmpty(reason))
            {
                throw new ArgumentException("Adjustment reason cannot be null or empty.");
            }
            if (adjustmentQuantity == 0)
            {
                throw new ArgumentException("Adjustment quantity cannot be zero.");
            }
        }
    }
}
