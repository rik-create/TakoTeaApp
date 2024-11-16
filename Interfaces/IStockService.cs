using System.Collections.Generic;
using System.Data;
using TakoTea.Model;

namespace TakoTea.Interfaces
{
    public interface IStockService
    {
        /// <summary>
        /// Retrieves the current stock levels for all active ingredients.
        /// </summary>
        /// <returns>A DataTable containing stock levels with ingredient details.</returns>
        DataTable GetCurrentStockLevels();

        /// <summary>
        /// Adjusts the stock quantity for a specific ingredient.
        /// </summary>
        /// <param name="ingredientId">ID of the ingredient to adjust.</param>
        /// <param name="adjustmentQuantity">Amount to adjust (positive or negative).</param>
        /// <param name="reason">Reason for the stock adjustment.</param>
        /// <param name="adjustmentType">Type of adjustment (e.g., addition or subtraction).</param>
        /// <returns>Indicates whether the adjustment was successful.</returns>
        void AdjustStock(int ingredientId, decimal adjustmentQuantity, string reason, int userId);

        /// <summary>
        /// Records stock adjustment activity for audit and tracking purposes.
        /// </summary>
        /// <param name="ingredientId">ID of the ingredient adjusted.</param>
        /// <param name="adjustmentQuantity">Amount adjusted (positive or negative).</param>
        /// <param name="reason">Reason for adjustment.</param>
        /// <param name="newStockLevel">The resulting stock level after adjustment.</param>
        void ValidateAdjustment(decimal adjustmentQuantity, string reason);
        List<StockLevel> GetReorderStatus();
    }

}
