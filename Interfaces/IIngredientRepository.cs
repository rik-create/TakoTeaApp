using System.Data;
using TakoTea.Model.ENTITY;

namespace TakoTea.Interfaces
{
    public interface IIngredientRepository
    {
        DataTable GetCurrentStockLevels();
        void UpdateStockLevel(int ingredientID, decimal newQuantity);
        Ingredient GetIngredientById(int ingredientId);

        string GetIngredientNameById(int ingredientId);
        decimal GetPreviousQuantity(int ingredientId);

    }

}
