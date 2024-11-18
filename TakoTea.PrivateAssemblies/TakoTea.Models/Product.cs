using System.Collections.Generic;
namespace TakoTea.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? ProductCategoryID { get; set; }  // Foreign key
        // Navigation property to the related ProductCategory
        public ProductCategory ProductCategory { get; set; }
        // Navigation property for related Ingredients
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
