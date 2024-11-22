using System.Collections.Generic;
namespace TakoTea.Models
{
    public class IngredientModel
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }

        public string BrandName { get; set; }
        public int? ProductID { get; set; }  // Foreign key
        public string Description { get; set; }
        public decimal StockQuantity { get; set; }

        public string StorageConditions { get; set; }
        public string IngredientImage { get; set; }
        public bool IsAddOn { get; set; }  // Flag for add-on
        public string TypeOfIngredient { get; set; }
        public bool IsActive { get; set; }  // Flag for active/inactive ingredient
        public string AllergyInformation { get; set; }
        // Navigation property to the related Product
        // Navigation property for related Batches
        public ICollection<BatchIngredient> Batches { get; set; }
    }
}
