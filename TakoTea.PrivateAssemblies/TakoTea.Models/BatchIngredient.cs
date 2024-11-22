using System;
namespace TakoTea.Models
{
    public class BatchIngredient
    {
        public int BatchID { get; set; }
        public string BatchNumber { get; set; }
        public int? IngredientID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal QuantityInStock { get; set; }
        public decimal ReorderLevel { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Supplier { get; set; }
        public string StorageConditions { get; set; }
        public bool IsActive { get; set; }
        public decimal BatchCost { get; set; }
        public IngredientModel Ingredient { get; set; }
    }
}
