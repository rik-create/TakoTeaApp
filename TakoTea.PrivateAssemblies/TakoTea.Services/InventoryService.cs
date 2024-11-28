using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using TakoTea.Database;
using TakoTea.Interfaces;
using TakoTea.Models;


namespace TakoTea.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Entities context;
        public InventoryService() { 
            context = new Entities();
        }


        public void DeleteIngredient(int ingredientId)
        {

            // 1. Delete related records in StockLevelLogs
            context.StockLevelLogs.RemoveRange(context.StockLevelLogs.Where(log => log.Batch.IngredientID == ingredientId));

            // 2. Delete related records in Batches
            context.Batches.RemoveRange(context.Batches.Where(b => b.IngredientID == ingredientId));

            // 3. Delete the ingredient
            var ingredient = context.Ingredients.Find(ingredientId);
            if (ingredient != null)
            {
                context.Ingredients.Remove(ingredient);
            }

            context.SaveChanges(); 
        }


        public void ImportIngredientsFromCsv(string filePath)
        {
            var reader = new StreamReader(filePath);

            // Skip the header row if it exists
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                // Validate the number of columns
                if (values.Length != 13)
                {
                    Console.WriteLine($"Invalid number of columns in line: {line}");
                    continue;
                }

                try
                {
                    // Validate and parse each value
                    var ingredientName = values[0].Replace("?", ",");
                    var brandName = values[1].Replace("?", ",");
                    var description = values[2].Replace("?", ",");
                    var isAddOn = bool.TryParse(values[4], out bool parsedIsAddOn) ? parsedIsAddOn : throw new FormatException("Invalid boolean format for IsAddOn");
                    var typeOfIngredient = values[5].Replace("?", ",");
                    var isActive = bool.TryParse(values[6], out bool parsedIsActive) ? parsedIsActive : throw new FormatException("Invalid boolean format for IsActive");
                    var allergyInformation = values[7].Replace("?", ",");
                    var storageConditions = values[8].Replace("?", ",");
                    var stockLevel = decimal.TryParse(values[9], out decimal parsedStockLevel) ? parsedStockLevel : throw new FormatException("Invalid decimal format for StockLevel");
                    var lowLevel = decimal.TryParse(values[10], out decimal parsedLowLevel) ? parsedLowLevel : throw new FormatException("Invalid decimal format for LowLevel");
                    var ingredientCategory = values[11].Replace("?", ",");
                    var measuringUnit = values[12];

                    var ingredient = new Ingredient
                    {
                        IngredientName = ingredientName,
                        BrandName = brandName,
                        Description = description,
                        IsAddOn = isAddOn,
                        TypeOfIngredient = typeOfIngredient,
                        IsActive = isActive,
                        AllergyInformation = allergyInformation,
                        StorageConditions = storageConditions,
                        StockLevel = stockLevel,
                        LowLevel = lowLevel,
                        IngredientCategory = ingredientCategory,
                        MeasuringUnit = measuringUnit
                    };

                    context.Ingredients.Add(ingredient);
                }
                catch (FormatException ex)
                {
                    // Log or handle the error
                    Console.WriteLine($"Error parsing line: {line}. Error: {ex.Message}");
                }
            }

            context.SaveChanges();
        }


        public void AddIngredient(Ingredient ingredient)
        {
            using (var context = new Entities())
            {
                context.Ingredients.Add(ingredient);

                context.SaveChanges();
            }
        }
        public int GetNextIngredientId()
        {

            // Find the maximum existing IngredientID
            int maxId = context.Ingredients.Any() ? context.Ingredients.Max(i => i.IngredientID) : 0;

            return maxId + 1; // Increment the max ID to get the next ID
        }
        public void AddAddon(AddOn addOn)
        {
            // Add the AddOn to the DbSet
            context.AddOns.Add(addOn);

            // Save changes to the database
            context.SaveChanges();
        }

        public int GetIngredientIdByName(string ingredientName)
        {
            var ingredient = context.Ingredients
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
            return context.Ingredients.ToList();
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
