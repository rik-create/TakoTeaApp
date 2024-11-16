using System;

namespace TakoTea.Model.ENTITY
{
    public class BatchIngredient
    {
        public int BatchID { get; set; }
        public string BatchNumber { get; set; }
        public int? IngredientID { get; set; }  // Foreign key
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal QuantityInStock { get; set; }
        public decimal ReorderLevel { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Supplier { get; set; }
        public string StorageConditions { get; set; }
        public bool IsActive { get; set; }  // Flag for active/inactive batch
        public decimal BatchCost { get; set; }

        // Navigation property to the related Ingredient
        public Ingredient Ingredient { get; set; }
    }

}
