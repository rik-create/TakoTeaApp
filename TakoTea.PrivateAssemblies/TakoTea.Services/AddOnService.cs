using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Models;
using TakoTea.Repository;

namespace TakoTea.Services
{
    public class AddOnService
    {
        private readonly AddOnRepository _addOnRepository;

        public AddOnService()
        {
            _addOnRepository = new AddOnRepository();
        }

        public void UpdateAddOn(AddOn addOn)
        {
            if (addOn == null)
            {
                throw new ArgumentNullException(nameof(addOn));
            }

            var existingAddOn = _addOnRepository.GetAddOnById(addOn.Id);
            if (existingAddOn == null)
            {
                throw new KeyNotFoundException($"AddOn with Id {addOn.Id} not found.");
            }

            existingAddOn.AddOnName = addOn.AddOnName;
            existingAddOn.AdditionalPrice = addOn.AdditionalPrice;
            existingAddOn.UseForProductID = addOn.UseForProductID;
            existingAddOn.QuantityUsedPerProduct = addOn.QuantityUsedPerProduct;
            existingAddOn.IngredientID = addOn.IngredientID;
            existingAddOn.UpdatedBy = addOn.UpdatedBy;
            existingAddOn.UpdatedAt = DateTime.Now;

            // Assuming the repository has an update method
            _addOnRepository.Update(existingAddOn);
        }
    }
}
