using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Models;

namespace TakoTea.Repository
{
    public class AddOnRepository
    {
        public List<AddOn> GetAllAddOns()
        {
            using (var context = new Entities())
            {
                return context.AddOns.ToList();
            }
        }
        public AddOn GetAddOnById(int addOnId)
        {
            using (var context = new Entities())
            {
                return context.AddOns.FirstOrDefault(addOn => addOn.Id == addOnId);
            }
        }

        public void Update(AddOn addOn)
        {
            var existingAddOn = GetAddOnById(addOn.Id);
            if (existingAddOn != null)
            {
                existingAddOn.AddOnName = addOn.AddOnName;
                existingAddOn.AdditionalPrice = addOn.AdditionalPrice;
                existingAddOn.UseForProductID = addOn.UseForProductID;
                existingAddOn.QuantityUsedPerProduct = addOn.QuantityUsedPerProduct;
                existingAddOn.IngredientID = addOn.IngredientID;
                existingAddOn.UpdatedBy = addOn.UpdatedBy;
                existingAddOn.UpdatedAt = addOn.UpdatedAt;
            }
        }

    }
}
