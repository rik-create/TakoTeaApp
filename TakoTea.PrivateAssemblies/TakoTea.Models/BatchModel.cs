using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace TakoTea.Models
{
    public class BatchModel
    {
        public int BatchID { get; set; }

        public int IngredientID { get; set; }
        public string BatchNumber { get; set; }
        public decimal Quantity { get; set; }
        public string MeasuringUnit { get; set; }

        public string IngredientName { get; set; }
        public decimal Cost { get; set; }
        public decimal LowLevel { get; set; }
        public DateTime Expiration { get; set; }
        public string ItemDescription { get; set; }
        public string IngredientType { get; set; }
        public string BrandName { get; set; }
        public string Vendor { get; set; }
        public string StorageCondition { get; set; }
        public string IngredientImage { get; set; }
        public List<string> IngredientFunctions { get; set; }
        public List<string> Allergens { get; set; }

        // Constructor to initialize BatchModel
        public BatchModel(int batchID, int ingredientID, string batchNumber, decimal quantity, string measuringUnit,string ingredientName, decimal cost, decimal lowLevel, DateTime expiration, string itemDescription, string ingredientType, string brandName, string vendor, string storageCondition, string ingredientImage, List<string> ingredientFunctions, List<string> allergens)
        {
            BatchID = batchID;
            IngredientID = ingredientID;
            BatchNumber = batchNumber;
            Quantity = quantity;
            MeasuringUnit = measuringUnit;
            IngredientName = ingredientName;
            Cost = cost;
            LowLevel = lowLevel;
            Expiration = expiration;
            ItemDescription = itemDescription;
            IngredientType = ingredientType;
            BrandName = brandName;
            Vendor = vendor;
            StorageCondition = storageCondition;
            IngredientImage = ingredientImage;
            IngredientFunctions = ingredientFunctions;
            Allergens = allergens;
        }
    }
}
