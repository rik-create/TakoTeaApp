using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.Model.ENTITY
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
