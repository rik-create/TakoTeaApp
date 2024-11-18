using System.Collections.Generic;
using TakoTea.Models;
namespace TakoTea.Interfaces
{
    public interface IInventoryService
    {
        void AddIngredient(Ingredient ingredient, BatchIngredient batch, List<int> linkedProductIds);
    }
}
