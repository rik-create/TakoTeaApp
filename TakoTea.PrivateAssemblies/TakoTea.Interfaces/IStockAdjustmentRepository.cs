using System;
namespace TakoTea.Interfaces
{
    public interface IStockAdjustmentRepository
    {
        bool RecordAdjustment(
     int ingredientId,
     decimal adjustmentQuantity,
     string reason,
     decimal previousQuantity,
     decimal newStockLevel,
     int userId,
     DateTime adjustmentDate
 );
    }
}
