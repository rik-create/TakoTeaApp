using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using TakoTea.Database;
using TakoTea.Interfaces;
using TakoTea.Models;


namespace TakoTea.Services
{
    public class InventoryService : IInventoryService
    {
        // Use DatabaseConnection.Instance for accessing the connection
        public void AddIngredient(Ingredient ingredient)
        {
            using (var context = new Entities())
            {
                context.Ingredients.Add(ingredient);

                context.SaveChanges();
            }
        }

    }
}
