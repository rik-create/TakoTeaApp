using System.Collections.Generic;
namespace TakoTea.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        // Navigation property for related Products
        public ICollection<Product> Products { get; set; }
    }
}
