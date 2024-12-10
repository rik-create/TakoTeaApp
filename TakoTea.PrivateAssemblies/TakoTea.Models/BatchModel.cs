using System;

namespace TakoTea.Models
{
    public class BatchModel
    {
        public int BatchID { get; set; }

        public int IngredientID { get; set; }
        public string BatchNumber { get; set; }
        public decimal QuantityInStock { get; set; }
        public string MeasuringUnit { get; set; }

        public decimal BatchCost { get; set; }

        public bool IsActive { get; set; }

        public decimal ReorderLevel { get; set; }

        public DateTime ExpirationDate { get; set; }



        public BatchModel() { }

        public BatchModel(int batchID, int ingredientID, string batchNumber, decimal quantity, string measuringUnit, decimal cost, decimal lowLevel, DateTime expiration, bool isActive)
        {
            BatchID = batchID;
            IngredientID = ingredientID;
            BatchNumber = batchNumber;
            QuantityInStock = quantity;
            MeasuringUnit = measuringUnit;
            BatchCost = cost;
            ReorderLevel = lowLevel;
            ExpirationDate = expiration;
            IsActive = isActive;

        }

    }
}
