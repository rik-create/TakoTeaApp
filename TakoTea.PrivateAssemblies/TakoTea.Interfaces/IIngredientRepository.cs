using System.Data;
using TakoTea.Models;
namespace TakoTea.Interfaces
{
    public interface IIngredientRepository
    {
        DataTable GetCurrentStockLevels();
        void UpdateStockLevel(int ingredientID, decimal newQuantity);
        IngredientModel GetIngredientById(int ingredientId);
        string GetIngredientNameById(int ingredientId);
        decimal GetPreviousQuantity(int ingredientId);
    }
}
