using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using TakoTea.Database;
using TakoTea.Helpers;
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

        public string GetIngredientNameById(int ingredientId)
        {
            using (var context = new Entities())
            {
                var ingredient = context.Ingredients.FirstOrDefault(i => i.IngredientID == ingredientId);
                return ingredient?.IngredientName ?? "Unknown Ingredient";
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    // 1. Delete related records in StockLevelLogs
                    var stockLevelLogs = context.StockLevelLogs.Where(log => log.Batch.IngredientID == ingredientId).ToList();
                    context.StockLevelLogs.RemoveRange(stockLevelLogs);

                    // Log deletion of StockLevelLogs
                    foreach (var log in stockLevelLogs)
                    {
                        LoggingHelper.LogChange(
                            "StockLevelLogs",
                            log.LogID,
                            "Deleted StockLevelLog",
                            log.OldStockLevel.ToString(),
                            null,
                            "Deleted",
                            $"StockLevelLog with ID '{log.LogID}' deleted for batch '{log.BatchID}'"
                        );
                    }

                    // 2. Delete related records in Batches
                    var batches = context.Batches.Where(b => b.IngredientID == ingredientId).ToList();
                    context.Batches.RemoveRange(batches);

                    // Log deletion of Batches
                    foreach (var batch in batches)
                    {
                        LoggingHelper.LogChange(
                            "Batches",
                            batch.BatchID,
                            "Deleted Batch",
                            batch.UpdatedAt.ToString(),
                            null,
                            "Deleted",
                            $"Batch '{batch.BatchNumber}' deleted for ingredient '{batch.IngredientID}'"
                        );
                    }

                    // 3. Delete the ingredient
                    var ingredient = context.Ingredients.Find(ingredientId);
                    if (ingredient != null)
                    {
                        context.Ingredients.Remove(ingredient);

                        // Log deletion of Ingredient
                        LoggingHelper.LogChange(
                            "Ingredients",
                            ingredient.IngredientID,
                            "Deleted Ingredient",
                            ingredient.IngredientName,
                            null,
                            "Deleted",
                            $"Ingredient '{ingredient.IngredientName}' with ID '{ingredient.IngredientID}' deleted"
                        );
                    }

                    context.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    MessageBox.Show("Error deleting ingredient: " + ex.Message);
                }
            }
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

         
                try
                {



                    // Validate and parse each value
                    var ingredientName = values[0].Replace("?", ",");
                    var brandName = values[1].Replace("?", ",");
                    var description = values[2].Replace("?", ",");
                    var isAddOn = bool.TryParse(values[3], out bool parsedIsAddOn) ? parsedIsAddOn : throw new FormatException("Invalid boolean format for IsAddOn");
                    var typeOfIngredient = values[4].Replace("?", ",");
                    var isActive = bool.TryParse(values[5], out bool parsedIsActive) ? parsedIsActive : throw new FormatException("Invalid boolean format for IsActive");
                    var allergyInformation = values[6].Replace("?", ",");
                    var storageConditions = values[7].Replace("?", ",");
                    var stockLevel = decimal.TryParse(values[8], out decimal parsedStockLevel) ? parsedStockLevel : throw new FormatException("Invalid decimal format for StockLevel");
                    var lowLevel = decimal.TryParse(values[9], out decimal parsedLowLevel) ? parsedLowLevel : throw new FormatException("Invalid decimal format for LowLevel");
                    var ingredientCategory = values[10].Replace("?", ",");
                    var measuringUnit = values[11];




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
                        IngredientImage = new byte[0],
                        LowLevel = lowLevel,
                        IngredientCategory = ingredientCategory,
                        MeasuringUnit = measuringUnit
                    };

                    if (isAddOn)
                    {
                        var additionalPrice = decimal.Parse(values[12]); // Parse AdditionalPrice from CSV
                        var useForProductId = int.Parse(values[13]); // Parse UseForProductID from CSV
                        var quantityUsedPerProduct = decimal.Parse(values[14]); // Parse QuantityUsedPerProduct from CSV


                        var addOn = new AddOn
                        {
                            AddOnName = ingredientName,
                            AdditionalPrice = additionalPrice,
                            UseForProductID = useForProductId,
                            QuantityUsedPerProduct = quantityUsedPerProduct,
                            IngredientID = GetNextIngredientId()
                        };

                        AddAddon(addOn);
                    }

                    context.Ingredients.Add(ingredient);
                }
                catch (FormatException ex)
                {
                    // Log or handle the error
                    MessageBox.Show($"Error parsing line: {line}. Error: {ex.Message}");
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

                // Log addition of Ingredient
                LoggingHelper.LogChange(
                    "Ingredients",
                    ingredient.IngredientID,
                    "Added Ingredient",
                    null,
                    ingredient.IngredientName,
                    "Added",
                    $"Ingredient '{ingredient.IngredientName}' with ID '{ingredient.IngredientID}' added"
                );
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
                        var stockLevel = Math.Floor(stockData.AvailableStock / stockData.QuantityPerVariant); // Apply Math.Floor here

                        var productVariant = context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantID == stockData.ProductVariantID);
                        if (productVariant != null)
                        {
                            var oldStockLevel = productVariant.StockLevel;
                            productVariant.StockLevel = stockLevel;

                            // Log update of ProductVariant stock level
                            LoggingHelper.LogChange(
                                "ProductVariants",
                                productVariant.ProductVariantID,
                                "Updated StockLevel",
                                oldStockLevel.ToString(),
                                stockLevel.ToString(),
                                "Updated",
                                $"ProductVariant '{productVariant.VariantName}' stock level updated from '{oldStockLevel}' to '{stockLevel}'"
                            );
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stock levels for all product variants: " + ex.Message);
            }
        }
        public void AddBatch(Batch batch)
        {
            using (var context = new Entities())
            {
                context.Batches.Add(batch);
                context.SaveChanges();

                // Log addition of Batch
                LoggingHelper.LogChange(
                    "Batches",                // Table name
                    batch.BatchID,            // Record ID (assuming BatchID is auto-generated)
                    "New Batch",              // Column name (or any descriptive text)
                    null,                     // Old value (null for new batch)
                    batch.ToString(),         // New value (you might need to override ToString() in your Batch class for a more descriptive log)
                    "Added",                  // Action
                    $"Batch '{batch.BatchNumber}' added for ingredient '{batch.IngredientID}'" // Description
                );
            }
        }


    }
}
