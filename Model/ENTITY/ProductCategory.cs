using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.Model.ENTITY
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }

        // Navigation property for related Products
        public ICollection<Product> Products { get; set; }
    }

}
