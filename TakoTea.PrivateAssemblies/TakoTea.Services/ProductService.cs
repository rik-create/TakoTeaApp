using System;
using System.Collections.Generic;
using System.Linq;
using TakoTea.Interfaces;
using TakoTea.Models;
using System.Data.Entity; // Replace with your context, e.g., if you're using Entity Framework

namespace TakoTea.Services
{
    public class ProductsService : IProductsService
    {
        private readonly Entities _context; // Your DB context

        public ProductsService()
        {
            _context = new Entities();
        }


        public void UpdateBatchStockLevel(int ingredientId, decimal quantityUsed, string action)
        {

            var batches = _context.Batches
                .Where(b => b.IngredientID == ingredientId && b.StockLevel > 0)
                .OrderBy(b => b.ExpirationDate)
                .ToList();

            decimal remainingQuantity = quantityUsed;

            foreach (var batch in batches)
            {
                decimal originalStockLevel = batch.StockLevel; // Store the original stock level

                if (batch.StockLevel >= remainingQuantity)
                {
                    batch.StockLevel -= remainingQuantity;
                    _context.SaveChanges();

                    // Log the stock level update
                    LogStockLevelUpdate(batch.BatchID, ingredientId, originalStockLevel, batch.StockLevel, remainingQuantity, action);

                    break;
                }
                else
                {
                    remainingQuantity -= batch.StockLevel;
                    batch.StockLevel = 0;
                    _context.SaveChanges();

                    // Log the stock level update
                    LogStockLevelUpdate(batch.BatchID, ingredientId, originalStockLevel, batch.StockLevel, batch.StockLevel, action);
                }
            }
        }
        public List<ProductVariantWithProductName> GetProductVariantWithProductName()
        {
            try
            {
                var productVariantsWithProductName = GetAllProductVariants()
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
            var size = _context.ProductVariants
                .Where(pv => pv.ProductVariantID == variantId)
                .Select(pv => pv.Size)
                .FirstOrDefault();

            return size; // Or handle the case where no size is found
        }
        private void LogStockLevelUpdate(int batchId, int ingredientId, decimal oldStockLevel, decimal newStockLevel, decimal quantityChanged, string action)
        {

            var stockLog = new StockLevelLog
            {
                BatchID = batchId,
                IngredientID = ingredientId,
                OldStockLevel = oldStockLevel,
                NewStockLevel = newStockLevel,
                QuantityChanged = quantityChanged,
                Action = action,
                Timestamp = DateTime.Now
            };

            _context.StockLevelLogs.Add(stockLog);
            _context.SaveChanges();
        }
        // Method to get IngredientID and QuantityPerVariant by ProductVariantIngredientID
        public (int IngredientID, decimal QuantityPerVariant) GetIngredientAndQuantity(int productVariantIngredientId)
        {
            var ingredient = _context.ProductVariantIngredients
                .Where(pvi => pvi.ProductVariantIngredientID == productVariantIngredientId)
                .Select(pvi => new { pvi.IngredientID, pvi.QuantityPerVariant })
                .FirstOrDefault();

            if (ingredient != null)
                return (ingredient.IngredientID, ingredient.QuantityPerVariant);
            else
                return (0, 0); // Or handle the case where no ingredient is found
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
            using (var context = new Entities())
            {
                var comboMeal = context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == comboMealName);
                return comboMeal?.ComboMealID ?? 0; // Return the ComboMealID of the newly inserted combo meal
            }
        }
        public int GetProductVariantId(string productName, string sizeId)
        {

            // Assuming 'Size' is actually the 'Name' of the Ingredient
            var variantId = _context.ProductVariants
                .Where(pv => pv.VariantName == productName)
                .Where(pv => pv.Size == sizeId)
                .Select(pv => pv.ProductVariantID)
                .FirstOrDefault();

            if (variantId == 0) // Check if no matching variant was found
                throw new Exception($"Product variant not found for product '{productName}' and size '{sizeId}'.");

            return variantId;
        }


        public void AddComboMeal(ComboMeal comboMeal)
        {
            using (var context = new Entities())
            {
                context.ComboMeals.Add(comboMeal);

                context.SaveChanges();
            }
        }

        public void AddComboMealVariant(int comboMealID, int variantID)
        {
            using (var context = new Entities())
            {
                var comboMealVariant = new ComboMealVariant
                {
                    ComboMealID = comboMealID,
                    ProductVariantID = variantID
                };
                context.ComboMealVariants.Add(comboMealVariant);
                context.SaveChanges();
            }
        }

        public void AddComboMealVariant(ComboMealVariant mealVariant)
        {
            using (var context = new Entities())
            {
                context.ComboMealVariants.Add(mealVariant);

                context.SaveChanges();
            }
        }

        public int GetProductIdByName(string productName)
        {
            using (var context = new Entities())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product == null)
                    throw new Exception($"Product '{productName}' not found.");

                return product.ProductID;
            }
        }
        public string GetProductNameById(int productId)
        {
            using (var context = new Entities())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductID == productId);
                if (product == null)
                    throw new Exception($"Product with ID '{productId}' not found.");

                return product.ProductName;
            }
        }
        public string GetProductVariantNameById(int productVariantId)
        {
            using (var context = new Entities())
            {
                var product = context.ProductVariants.FirstOrDefault(p => p.ProductVariantID == productVariantId);
                if (product == null)
                    throw new Exception($"Product with ID '{productVariantId}' not found.");

                return product.VariantName;
            }
        }


        public void AddProductVariantIngredient(ProductVariantIngredient productVariantIngredient)
        {
            using (var dbContext = new Entities())  // Use your actual DbContext class
            {
                dbContext.ProductVariantIngredients.Add(productVariantIngredient);
                dbContext.SaveChanges();
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
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public int GetNextProductVariantId()
        {

            // Find the maximum existing ProductVariantID
            int maxId = _context.ProductVariants.Any() ? _context.ProductVariants.Max(pv => pv.ProductVariantID) : 0;

            return maxId + 1; // Increment the max ID to get the next ID
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
                var productVariantList = _context.ProductVariants.ToList();

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
        }

        public void AddMultipleProductVariants(List<ProductVariant> productVariants)
        {
            _context.ProductVariants.AddRange(productVariants);
            _context.SaveChanges();
        }

        public void UpdateProductVariant(ProductVariant productVariant)
        {
            _context.Entry(productVariant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProductVariant(int variantId)
        {
            var productVariant = _context.ProductVariants.Find(variantId);
            if (productVariant != null)
            {
                _context.ProductVariants.Remove(productVariant);
                _context.SaveChanges();
            }
        }

        public void ImportProductVariants(string filePath)
        {
            // Add logic for importing product variants from a file
        }

        public void ExportProductVariants(string filePath, Dictionary<string, object> filters = null)
        {
            var query = _context.ProductVariants.AsQueryable();

            // Apply filters if any
            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    // Implement dynamic filtering logic based on filter keys
                }
            }

            var productVariants = query.ToList();

            // Implement exporting logic to the file
        }

        // Filtering Features
        public List<Product> FilterProducts(Dictionary<string, object> filters)
        {
            var query = _context.Products.AsQueryable();

            // Apply filters
            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    // Implement dynamic filtering logic based on filter keys
                }
            }

            return query.ToList();
        }

        public List<ProductVariant> FilterProductVariants(Dictionary<string, object> filters)
        {
            var query = _context.ProductVariants.AsQueryable();

            // Apply filters
            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
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
