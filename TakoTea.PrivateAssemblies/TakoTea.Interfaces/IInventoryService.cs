using System.Collections.Generic;
using TakoTea.Models;
namespace TakoTea.Interfaces
{
    public interface IInventoryService
    {
        void AddAddon(AddOn addOn);
        void AddIngredient(Ingredient ingredient);
        List<Ingredient> GetAllIngredients();
        int GetIngredientIdByName(string ingredientName);
        void UpdateAllProductVariantsStockLevel();

    }
}
