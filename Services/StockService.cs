using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TakoTea.Interfaces;
using TakoTea.Model;

namespace TakoTea.Services
{
    public class StockService : IStockService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;


        public StockService(IIngredientRepository ingredientRepository, IStockAdjustmentRepository stockAdjustmentRepository)
        {
            _ingredientRepository = ingredientRepository;
            _stockAdjustmentRepository = stockAdjustmentRepository;
        }


        public DataTable GetCurrentStockLevels()
        {
            return _ingredientRepository.GetCurrentStockLevels();
        }


        public void AdjustStock(int ingredientId, decimal newStockLevel, string reason, int userId)
        {
            if (ingredientId <= 0)
                throw new ArgumentException("Ingredient ID must be greater than zero.", nameof(ingredientId));

            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Reason cannot be null or empty.", nameof(reason));

            if (newStockLevel < 0)
                throw new ArgumentException("New stock level cannot be negative.", nameof(newStockLevel));

            // Retrieve the current stock level
            decimal currentStockLevel = _ingredientRepository.GetPreviousQuantity(ingredientId);

            if (currentStockLevel == default)
                throw new InvalidOperationException("Ingredient not found or has no stock data.");

            // Calculate the adjustment quantity
            decimal adjustmentQuantity = newStockLevel - currentStockLevel;

            // Prepare the adjustment date
            DateTime adjustmentDate = DateTime.UtcNow;

            // Record the adjustment
            bool success = _stockAdjustmentRepository.RecordAdjustment(
                ingredientId,
                adjustmentQuantity,
                reason,
                currentStockLevel,
                newStockLevel,
                userId,
                adjustmentDate
            );

            if (!success)
                throw new InvalidOperationException("Failed to record stock adjustment.");

            // Update stock level in the ingredient repository
            _ingredientRepository.UpdateStockLevel(ingredientId, newStockLevel);
        }





        public List<StockLevel> GetReorderStatus()
        {
            // Retrieve the stock levels as a DataTable
            DataTable stockLevelsTable = GetCurrentStockLevels();

            // Convert DataTable to a List of StockLevel objects
            var stockLevels = stockLevelsTable.AsEnumerable()
                .Select(row => new StockLevel
                {
                    IngredientID = row.Field<int>("IngredientID"),
                    IngredientName = row.Field<string>("IngredientName"),
                    QuantityInStock = row.Field<decimal>("QuantityInStock"),
                    ReorderLevel = row.Field<decimal>("ReorderLevel")
                })
                .ToList();

            // Filter the stock levels where QuantityInStock is less than or equal to ReorderLevel
            return stockLevels.Where(s => s.QuantityInStock <= s.ReorderLevel).ToList();
        }

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
