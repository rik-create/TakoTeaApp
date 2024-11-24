using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using TakoTea.Database;
using TakoTea.Interfaces;
using TakoTea.Models;


namespace TakoTea.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Entities _context;
        public InventoryService() { 
            _context = new Entities();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            using (var context = new Entities())
            {
                context.Ingredients.Add(ingredient);

                context.SaveChanges();
            }
        }
        public void AddAddon(AddOn addOn)
        {
            // Add the AddOn to the DbSet
            _context.AddOns.Add(addOn);

            // Save changes to the database
            _context.SaveChanges();
        }

        public int GetIngredientIdByName(string ingredientName)
        {
            var ingredient = _context.Ingredients
                .FirstOrDefault(i => i.IngredientName.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));

            if (ingredient != null)
            {
                return ingredient.IngredientID; // Return the IngredientID if found
            }

            // Handle the case where the ingredient is not found
            throw new Exception($"Ingredient '{ingredientName}' not found in the database.");
        }


        public List<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        public void UpdateAllProductVariantsStockLevel()
        {
            try
            {
                using (var context = new Entities())
                {
                    var productVariantStockData = from pvi in context.ProductVariantIngredients
                                                  join bi in context.Batches on pvi.IngredientID equals bi.IngredientID
                                                  group bi by new { pvi.ProductVariantID, pvi.QuantityPerVariant } into g
                                                  select new
                                                  {
                                                      ProductVariantID = g.Key.ProductVariantID,
                                                      QuantityPerVariant = g.Key.QuantityPerVariant,
                                                      AvailableStock = g.Sum(x => (decimal?)x.StockLevel) ?? 0
                                                  };

                    foreach (var stockData in productVariantStockData)
                    {
                        var stockLevel = stockData.AvailableStock / stockData.QuantityPerVariant;

                        var productVariant = context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantID == stockData.ProductVariantID);
                        if (productVariant != null)
                        {
                            productVariant.StockLevel = stockLevel;
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating stock levels for all product variants: " + ex.Message);
            }
        }


    }
}
