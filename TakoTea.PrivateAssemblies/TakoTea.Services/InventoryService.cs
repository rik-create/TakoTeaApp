using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TakoTea.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Entities context;
        public InventoryService()
        {
            context = new Entities();
        }

        public string GetIngredientNameById(int ingredientId)
        {
            using (Entities context = new Entities())
            {
                Ingredient ingredient = context.Ingredients.FirstOrDefault(i => i.IngredientID == ingredientId);
                return ingredient?.IngredientName ?? "Unknown Ingredient";
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    string deletionDescription = DialogHelper.ShowInputDialog(
                                 formTitle: "Enter Deletion Description",
                                 labelText: "Deletion Description:",
                                 validationMessage: "Description cannot be empty.",
                                 validateInput: input => !string.IsNullOrWhiteSpace(input)
                             );


                    if (deletionDescription == null)
                    {
                        return;
                    }
                   
                    // 1. Delete related records in StockLevelLogs
                    List<StockLevelLog> stockLevelLogs = context.StockLevelLogs.Where(log => log.IngredientID == ingredientId).ToList();
                    _ = context.StockLevelLogs.RemoveRange(stockLevelLogs);

                    // Log deletion of StockLevelLogs
                    foreach (StockLevelLog log in stockLevelLogs)
                    {
                        LoggingHelper.LogChange(
                            "StockLevelLogs",
                            log.LogID,
                            "Deleted StockLevelLog",
                            log.OldStockLevel.ToString(),
                            null,
                            "Deleted",
                            $"StockLevelLog with ID '{log.LogID}' deleted for batch '{log.BatchID}'", deletionDescription
                        );
                    }

                    // 2. Delete related records in Batches
                    List<Batch> batches = context.Batches.Where(b => b.IngredientID == ingredientId).ToList();
                    _ = context.Batches.RemoveRange(batches);

                    // Log deletion of Batches
                    foreach (Batch batch in batches)
                    {
                        LoggingHelper.LogChange(
                            "Batch",
                            batch.BatchID,
                            "Deleted Batch",
                            batch.UpdatedAt.ToString(),
                            null,
                            "Deleted",
                            $"Batch '{batch.BatchNumber}' deleted for ingredient '{batch.IngredientID}'", deletionDescription
                        );
                    }

                    // 3. Delete the ingredient
                    Ingredient ingredient = context.Ingredients.Find(ingredientId);
                    if (ingredient != null)
                    {
                        _ = context.Ingredients.Remove(ingredient);

                        // Log deletion of Ingredient
                        LoggingHelper.LogChange(
                            "Ingredients",
                            ingredient.IngredientID,
                            "Deleted Ingredient",
                            ingredient.IngredientName,
                            null,
                            "Deleted",
                            $"Ingredient '{ingredient.IngredientName}' with ID '{ingredient.IngredientID}' deleted", deletionDescription
                        );
                    }

                    _ = context.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    _ = MessageBox.Show("Error deleting ingredient: " + ex.Message);
                }
            }
        }


        public void ImportIngredientsFromCsv(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);

            // Skip the header row if it exists
            _ = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');


                try
                {



                    // Validate and parse each value
                    string ingredientName = values[0].Replace("?", ",");
                    string brandName = values[1].Replace("?", ",");
                    string description = values[2].Replace("?", ",");
                    bool isAddOn = bool.TryParse(values[3], out bool parsedIsAddOn) ? parsedIsAddOn : throw new FormatException("Invalid boolean format for IsAddOn");
                    string typeOfIngredient = values[4].Replace("?", ",");
                    bool isActive = bool.TryParse(values[5], out bool parsedIsActive) ? parsedIsActive : throw new FormatException("Invalid boolean format for IsActive");
                    string allergyInformation = values[6].Replace("?", ",");
                    string storageConditions = values[7].Replace("?", ",");
                    decimal lowLevel = decimal.TryParse(values[9], out decimal parsedLowLevel) ? parsedLowLevel : throw new FormatException("Invalid decimal format for LowLevel");
                    string ingredientCategory = values[10].Replace("?", ",");
                    string measuringUnit = values[11];




                    Ingredient ingredient = new Ingredient
                    {
                        IngredientName = ingredientName,
                        BrandName = brandName,
                        Description = description,
                        IsAddOn = isAddOn,
                        TypeOfIngredient = typeOfIngredient,
                        IsActive = isActive,
                        AllergyInformation = allergyInformation,
                        StorageConditions = storageConditions,
                        StockLevel = 0,
                        IngredientImage = new byte[0],
                        LowLevel = lowLevel,
                        IngredientCategory = ingredientCategory,
                        MeasuringUnit = measuringUnit
                    };

                    if (isAddOn)
                    {
                        decimal additionalPrice = decimal.Parse(values[12]); // Parse AdditionalPrice from CSV
                        int useForProductId = int.Parse(values[13]); // Parse UseForProductID from CSV
                        decimal quantityUsedPerProduct = decimal.Parse(values[14]); // Parse QuantityUsedPerProduct from CSV


                        AddOn addOn = new AddOn
                        {
                            AddOnName = ingredientName,
                            AdditionalPrice = additionalPrice,
                            UseForProductID = useForProductId,
                            QuantityUsedPerProduct = quantityUsedPerProduct,
                            IngredientID = GetNextIngredientId()
                        };

                        AddAddon(addOn);
                    }

                    _ = context.Ingredients.Add(ingredient);
                }
                catch (FormatException ex)
                {
                    // Log or handle the error
                    _ = MessageBox.Show($"Error parsing line: {line}. Error: {ex.Message}");
                }
            }

            _ = context.SaveChanges();
        }


        public void AddIngredient(Ingredient ingredient)
        {
            using (Entities context = new Entities())
            {
                _ = context.Ingredients.Add(ingredient);
                _ = context.SaveChanges();

                // Log addition of Ingredient
                LoggingHelper.LogChange(
                    "Ingredients",
                    ingredient.IngredientID,
                    "Added Ingredient",
                    null,
                    ingredient.IngredientName,
                    "Added",
                    $"Ingredient '{ingredient.IngredientName}' with ID '{ingredient.IngredientID}' added", ""
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
            _ = context.AddOns.Add(addOn);

            // Save changes to the database
            _ = context.SaveChanges();
        }

        public int GetIngredientIdByName(string ingredientName)
        {
            Ingredient ingredient = context.Ingredients
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
                using (Entities context = new Entities())
                {
                    var productVariantStockData = from pvi in context.ProductVariantIngredients
                                                  join bi in context.Batches on pvi.IngredientID equals bi.IngredientID
                                                  group bi by new { pvi.ProductVariantID, pvi.QuantityPerVariant } into g
                                                  select new
                                                  {
                                                      g.Key.ProductVariantID,
                                                      g.Key.QuantityPerVariant,
                                                      AvailableStock = g.Sum(x => (decimal?)x.StockLevel) ?? 0
                                                  };

                    foreach (var stockData in productVariantStockData)
                    {
                        decimal stockLevel = Math.Floor(stockData.AvailableStock / stockData.QuantityPerVariant); // Apply Math.Floor here

                        ProductVariant productVariant = context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantID == stockData.ProductVariantID);
                        if (productVariant != null)
                        {
                            decimal? oldStockLevel = productVariant.StockLevel;
                            productVariant.StockLevel = stockLevel;

                            // Log update of ProductVariant stock level




                        }
                    }

                    _ = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error updating stock levels for all product variants: " + ex.Message);
            }
        }


    }
}
