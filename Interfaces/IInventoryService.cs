using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Model.ENTITY;

namespace TakoTea.Interfaces
{
    public interface IInventoryService
    {
        void AddIngredient(Ingredient ingredient, BatchIngredient batch, List<int> linkedProductIds);
    }

}
