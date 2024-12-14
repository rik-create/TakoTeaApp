using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Helpers; // Replace with your context, e.g., if you're using Entity Framework
using TakoTea.Models;

namespace TakoTea.Services
{
    public class ProductsService
    {
        private readonly Entities _context; // Your DB context

        public ProductsService(Entities context)
        {
            _context = context;
        }

        public decimal GetProductVariantStockLevel(int productVariantId)
        {
            using (var context = new Entities())
            {
                // Get the quantities of each ingredient used in the product variant
                var ingredientQuantities = context.ProductVariantIngredients
                    .Where(pvi => pvi.ProductVariantID == productVariantId)
                    .Select(pvi => new { pvi.IngredientID, pvi.QuantityPerVariant })
                    .ToList();

                decimal stockLevel = decimal.MaxValue; // Initialize with a very high value

                foreach (var item in ingredientQuantities)
                {
                    // Calculate the total stock level of the ingredient across all batches
                    decimal ingredientStockLevel = context.Batches
    .Where(b => b.IngredientID == item.IngredientID && b.IsActive == true)
    .Select(b => (decimal?)b.StockLevel)
    .DefaultIfEmpty(0)
    .Sum() ?? 0;

                    // Calculate the maximum number of product variants that can be made 
                    // with the available ingredient stock
                    decimal maxVariantsFromIngredient = ingredientStockLevel / item.QuantityPerVariant;

                    // Update the overall stock level to the minimum value encountered so far
                    stockLevel = Math.Min(stockLevel, maxVariantsFromIngredient);
                }

                return stockLevel;
            }
        }
        public void UpdateAllProductVariantStockLevels()
        {
            using (var context = new Entities())
            {
                // Get all product variants
                var productVariants = context.ProductVariants.ToList();

                foreach (var variant in productVariants)
                {
                    // Calculate the stock level for the current variant
                    decimal stockLevel = GetProductVariantStockLevel(variant.ProductVariantID);

                    // Update the StockLevel property of the variant
                    variant.StockLevel = stockLevel;
                }

                // Save changes to the database
                context.SaveChanges();
            }
        }

        public List<ProductVariant> GetProductVariantsByProductId(int productId)
        {
            try
            {
                return _context.ProductVariants
                    .Where(pv => pv.ProductID == productId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving product variants for product ID {productId}: {ex.Message}");
            }
        }

        public List<ComboMeal> GetAllComboMeals()
        {

            return _context.ComboMeals.ToList();

        }
        public bool DeleteComboMeal(int comboMealId)
        {

            ComboMeal comboMeal = _context.ComboMeals.FirstOrDefault(cm => cm.ComboMealID == comboMealId);
            if (comboMeal == null)
            {
                return false; // Combo meal not found
            }

            _ = _context.ComboMeals.Remove(comboMeal);
            _ = _context.SaveChanges();
            return true; // Combo meal deleted successfully

        }
        public void UpdateBatchStockLevel(int ingredientId, decimal quantityUsed, string action)
        {
            List<Batch> batches = _context.Batches
                .Where(b => b.IngredientID == ingredientId && b.StockLevel > 0)
                .OrderBy(b => b.ExpirationDate)
                .ToList();

            decimal remainingQuantity = quantityUsed;

            foreach (Batch batch in batches)
            {
                decimal originalStockLevel = batch.StockLevel; // Store the original stock level

                if (batch.StockLevel >= remainingQuantity)
                {
                    batch.StockLevel -= remainingQuantity;
                    _ = _context.SaveChanges();

                    // Log the stock level update
                    LogStockLevelUpdate(batch.BatchID, ingredientId, originalStockLevel, batch.StockLevel, remainingQuantity, action);

                    LoggingHelper.LogChange(
                        "Batch",                // Table name
                        batch.BatchID,            // Record ID (assuming BatchID is auto-generated)
                        "Stock Level Update",     // Column name (or any descriptive text)
                        originalStockLevel.ToString(), // Old value
                        batch.StockLevel.ToString(),   // New value
                        "Updated",                // Action
                        $"Batch '{batch.BatchNumber}' stock level updated for ingredient '{batch.IngredientID}'", "" // Description
                    );

                    break;
                }
                else
                {
                    remainingQuantity -= batch.StockLevel;
                    batch.StockLevel = 0;
                    _ = _context.SaveChanges();

                    // Log the stock level update
                    LogStockLevelUpdate(batch.BatchID, ingredientId, originalStockLevel, batch.StockLevel, batch.StockLevel, action);

                    LoggingHelper.LogChange(
                        "Batch",                // Table name
                        batch.BatchID,            // Record ID (assuming BatchID is auto-generated)
                        "Stock Level Update",     // Column name (or any descriptive text)
                        originalStockLevel.ToString(), // Old value
                        batch.StockLevel.ToString(),   // New value
                        "Updated",                // Action
                        $"Batch '{batch.BatchNumber}' stock level updated for ingredient '{batch.IngredientID}'", ""// Description
                    );
                }
            }
        }
        public List<ProductVariantWithProductName> GetProductVariantWithProductName()
        {
            try
            {
                List<ProductVariantWithProductName> productVariantsWithProductName = GetAllProductVariants()
                    .Join(GetAllProducts(),
                          pv => pv.ProductID,
                          p => p.ProductID,
                          (pv, p) => new ProductVariantWithProductName
                          {
                              ProductVariantID = pv.ProductVariantID,
                              ProductName = p.ProductName,
                              VariantName = pv.VariantName,
                              Size = pv.Size,
                              Price = pv.Price,
                              StockLevel = pv.StockLevel ?? 0, // Provide a default value
                              ImagePath = pv.ImagePath
                          })
                    .ToList();

                return productVariantsWithProductName;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading ingredients: " + ex.Message);
            }
        }

        public string GetSizeByVariantId(int variantId)
        {
            string size = _context.ProductVariants
                .Where(pv => pv.ProductVariantID == variantId)
                .Select(pv => pv.Size)
                .FirstOrDefault();

            return size; // Or handle the case where no size is found
        }
        private void LogStockLevelUpdate(int batchId, int ingredientId, decimal oldStockLevel, decimal newStockLevel, decimal quantityChanged, string action)
        {

            StockLevelLog stockLog = new StockLevelLog
            {
                BatchID = batchId,
                IngredientID = ingredientId,
                OldStockLevel = oldStockLevel,
                NewStockLevel = newStockLevel,
                QuantityChanged = quantityChanged,
                Action = action,
                Timestamp = DateTime.Now
            };

            _ = _context.StockLevelLogs.Add(stockLog);
            _ = _context.SaveChanges();
        }
        // Method to get IngredientID and QuantityPerVariant by ProductVariantIngredientID
        public (int IngredientID, decimal QuantityPerVariant) GetIngredientAndQuantity(int productVariantIngredientId)
        {
            var ingredient = _context.ProductVariantIngredients
                .Where(pvi => pvi.ProductVariantIngredientID == productVariantIngredientId)
                .Select(pvi => new { pvi.IngredientID, pvi.QuantityPerVariant })
                .FirstOrDefault();

            if (ingredient != null)
            {
                return (ingredient.IngredientID, ingredient.QuantityPerVariant);
            }
            else
            {
                return (0, 0); // Or handle the case where no ingredient is found
            }
        }

        public List<int> GetProductVariantIngredientIds(int productVariantId)
        {
            return _context.ProductVariantIngredients
                .Where(pvi => pvi.ProductVariantID == productVariantId)
                .Select(pvi => pvi.ProductVariantIngredientID)
                .ToList();
        }


        public int GetNewComboMealID(string comboMealName)
        {
            using (Entities context = new Entities())
            {
                ComboMeal comboMeal = context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == comboMealName);
                return comboMeal?.ComboMealID ?? 0; // Return the ComboMealID of the newly inserted combo meal
            }
        }
        public int GetProductVariantId(string productName, string sizeId)
        {

            // Assuming 'Size' is actually the 'Name' of the Ingredient
            int variantId = _context.ProductVariants
                .Where(pv => pv.VariantName == productName)
                .Where(pv => pv.Size == sizeId)
                .Select(pv => pv.ProductVariantID)
                .FirstOrDefault();

            return variantId == 0
                ? throw new Exception($"Product variant not found for product '{productName}' and size '{sizeId}'.")
                : variantId;
        }


        public void AddComboMeal(ComboMeal comboMeal)
        {
            using (Entities context = new Entities())
            {
                _ = context.ComboMeals.Add(comboMeal);

                _ = context.SaveChanges();
            }
        }

        public void AddComboMealVariant(int comboMealID, int variantID)
        {
            using (Entities context = new Entities())
            {
                ComboMealVariant comboMealVariant = new ComboMealVariant
                {
                    ComboMealID = comboMealID,
                    ProductVariantID = variantID
                };
                _ = context.ComboMealVariants.Add(comboMealVariant);
                _ = context.SaveChanges();
            }
        }

        public void AddComboMealVariant(ComboMealVariant mealVariant)
        {
            using (Entities context = new Entities())
            {
                _ = context.ComboMealVariants.Add(mealVariant);

                _ = context.SaveChanges();
            }
        }

        public int GetProductIdByName(string productName)
        {
            using (Entities context = new Entities())
            {
                Product product = context.Products.FirstOrDefault(p => p.ProductName == productName);
                return product == null ? throw new Exception($"Product '{productName}' not found.") : product.ProductID;
            }
        }
        public string GetProductNameById(int productId)
        {
            using (Entities context = new Entities())
            {
                Product product = context.Products.FirstOrDefault(p => p.ProductID == productId);
                return product == null ? throw new Exception($"Product with ID '{productId}' not found.") : product.ProductName;
            }
        }
        public string GetProductVariantNameById(int productVariantId)
        {
            using (Entities context = new Entities())
            {
                ProductVariant product = context.ProductVariants.FirstOrDefault(p => p.ProductVariantID == productVariantId);
                return product == null ? throw new Exception($"Product with ID '{productVariantId}' not found.") : product.VariantName;
            }
        }


        public void AddProductVariantIngredient(ProductVariantIngredient productVariantIngredient)
        {
            try
            {
                using (Entities dbContext = new Entities())  // Use your actual DbContext class
                {
                    _ = dbContext.ProductVariantIngredients.Add(productVariantIngredient);
                    _ = dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product variant ingredient: {ex.Message}", ex);
            }
        }


        public List<string> GetProductNames()
        {
            return _context.Products.Select(p => p.ProductName).ToList();
        }
        // Product List Features
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();

        }



        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public void AddProduct(Product product)
        {
            _ = _context.Products.Add(product);
            _ = _context.SaveChanges();
            DialogHelper.ShowSuccess("Product Category added successfully!");
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _ = _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            Product product = _context.Products.Find(productId);
            if (product != null)
            {
                _ = _context.Products.Remove(product);
                _ = _context.SaveChanges();
            }
        }

        public int GetNextProductVariantId()
        {

            // Find the maximum existing ProductVariantID
            int maxId = _context.ProductVariants.Any() ? _context.ProductVariants.Max(pv => pv.ProductVariantID) : 0;

            return maxId; // Increment the max ID to get the next ID
        }
        public List<ProductVariant> GetLinkedProductVariants(int productId)
        {
            return _context.ProductVariants.Where(v => v.ProductID == productId).ToList();
        }

        public void ImportProducts(string filePath)
        {
            // Add logic for importing products from a file
        }

        public void TrackProductAuditHistory(int productId)
        {
            // Implement tracking product audit history
        }

        public List<ProductVariant> GetAllProductVariants()
        {
            try
            {
                // Simply retrieve all product variants without any projection
                List<ProductVariant> productVariantList = _context.ProductVariants.ToList();

                return productVariantList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading product variants: " + ex.Message);
            }
        }



        public ProductVariant GetProductVariantById(int variantId)
        {
            return _context.ProductVariants.Find(variantId);
        }

        public void AddProductVariant(ProductVariant productVariant)
        {
            _context.ProductVariants.Add(productVariant);
            _context.SaveChanges();
            LoggingHelper.LogChange(
                "ProductVariants",                // Table name
                productVariant.ProductVariantID,  // Record ID
                "New ProductVariant",             // Column name (or any descriptive text)
                null,                             // Old value (null for new product variant)
                productVariant.ToString(),        // New value (you might need to override ToString() in your ProductVariant class for a more descriptive log)
                "Added",                          // Action
                $"ProductVariant '{productVariant.VariantName}' added for product '{productVariant.ProductID}'", "" // Description
            );
        }

        public void AddMultipleProductVariants(List<ProductVariant> productVariants)
        {
            _ = _context.ProductVariants.AddRange(productVariants);
            _ = _context.SaveChanges();

            foreach (ProductVariant variant in productVariants)
            {
                LoggingHelper.LogChange(
                    "ProductVariants",                // Table name
                    variant.ProductVariantID,         // Record ID
                    "New ProductVariant",             // Column name (or any descriptive text)
                    null,                             // Old value (null for new product variant)
                    variant.ToString(),               // New value (you might need to override ToString() in your ProductVariant class for a more descriptive log)
                    "Added",                          // Action
                    $"ProductVariant '{variant.VariantName}' added for product '{variant.ProductID}'", "" // Description
                );
            }
        }

        /*    public void UpdateProductVariant(ProductVariant productVariant)
            {
                var existingVariant = _context.ProductVariants.Find(productVariant.ProductVariantID);
                if (existingVariant != null)
                {
                    var oldValue = existingVariant.VariantName;
                    existingVariant.VariantName = productVariant.VariantName;
                    _context.SaveChanges();
                    LoggingHelper.LogChange(
                        "ProductVariants",                // Table name
                        productVariant.ProductVariantID,  // Record ID
                        "Updated ProductVariant",         // Column name (or any descriptive text)
                        oldValue,                         // Old value
                        productVariant.VariantName,       // New value
                        "Updated",                        // Action
                        $"ProductVariant '{productVariant.VariantName}' updated for product '{productVariant.ProductID}'" // Description
                    );
                }
            }
      */

        /*    public void DeleteProductVariant(int variantId)
                {
                    var variant = _context.ProductVariants.Find(variantId);
                    if (variant != null)
                    {
                        var oldValue = variant.VariantName;
                        _context.ProductVariants.Remove(variant);
                        _context.SaveChanges();
                        LoggingHelper.LogChange(
                            "ProductVariants",                // Table name
                            variant.ProductVariantID,         // Record ID
                            "Deleted ProductVariant",         // Column name (or any descriptive text)
                            oldValue,                         // Old value
                            null,                             // New value (null for deleted product variant)
                            "Deleted",                        // Action
                            $"ProductVariant '{variant.VariantName}' deleted for product '{variant.ProductID}'" // Description
                        );
                    }
                }*/

        public void ImportProductVariants(string filePath)
        {
            // Add logic for importing product variants from a file
        }

        public void ExportProductVariants(string filePath, Dictionary<string, object> filters = null)
        {
            IQueryable<ProductVariant> query = _context.ProductVariants.AsQueryable();

            // Apply filters if any
            if (filters != null && filters.Count > 0)
            {
                foreach (KeyValuePair<string, object> filter in filters)
                {
                    // Implement dynamic filtering logic based on filter keys
                }
            }

            _ = query.ToList();

            // Implement exporting logic to the file
        }

        // Filtering Features
        public List<Product> FilterProducts(Dictionary<string, object> filters)
        {
            IQueryable<Product> query = _context.Products.AsQueryable();

            // Apply filters
            if (filters != null && filters.Count > 0)
            {
                foreach (KeyValuePair<string, object> filter in filters)
                {
                    // Implement dynamic filtering logic based on filter keys
                }
            }

            return query.ToList();
        }

        public List<ProductVariant> FilterProductVariants(Dictionary<string, object> filters)
        {
            IQueryable<ProductVariant> query = _context.ProductVariants.AsQueryable();

            // Apply filters
            if (filters != null && filters.Count > 0)
            {
                foreach (KeyValuePair<string, object> filter in filters)
                {
                    // Implement dynamic filtering logic based on filter keys
                }
            }

            return query.ToList();
        }
        public List<(int IngredientID, decimal QuantityPerVariant)> GetIngredientIdsAndQuantityPerVariantByProductVariantId(int productVariantId)
        {
            return _context.ProductVariantIngredients
                .Where(pvi => pvi.ProductVariantID == productVariantId)
                .Select(pvi => new { pvi.IngredientID, pvi.QuantityPerVariant })
                .ToList()
                .Select(pvi => (pvi.IngredientID, pvi.QuantityPerVariant))
                .ToList();
        }


        public List<int> GetIngredientIdsByProductVariantId(int productVariantId)
        {
            return _context.ProductVariantIngredients
                .Where(pvi => pvi.ProductVariantID == productVariantId)
                .Select(pvi => pvi.IngredientID)
                .ToList();
        }


    }

    public class ProductVariantWithProductName
    {
        public int ProductVariantID { get; set; }
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal StockLevel { get; set; }
        public byte[] ImagePath { get; set; }
    }
}
