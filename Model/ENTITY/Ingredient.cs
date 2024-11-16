using System.Collections.Generic;

namespace TakoTea.Model.ENTITY
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public string BrandName { get; set; }
        public int? ProductID { get; set; }  // Foreign key
        public string Description { get; set; }
        public string MeasuringUnit { get; set; }
        public string IngredientImage { get; set; }
        public bool IsAddOn { get; set; }  // Flag for add-on
        public string TypeOfIngredient { get; set; }
        public bool IsActive { get; set; }  // Flag for active/inactive ingredient
        public string AllergyInformation { get; set; }

        // Navigation property to the related Product
        public Product Product { get; set; }

        // Navigation property for related Batches
        public ICollection<BatchIngredient> Batches { get; set; }
    }

}
