using System.Collections.Generic;
using System.Linq;
using TakoTea.Models;

namespace TakoTea.Repository
{
    public class AddOnRepository
    {
        public List<AddOn> GetAllAddOns()
        {
            using (Entities context = new Entities())
            {
                return context.AddOns.ToList();
            }
        }
        public AddOn GetAddOnById(int addOnId)
        {
            using (Entities context = new Entities())
            {
                return context.AddOns.FirstOrDefault(addOn => addOn.Id == addOnId);
            }
        }

        public void Update(AddOn addOn)
        {
            AddOn existingAddOn = GetAddOnById(addOn.Id);
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
