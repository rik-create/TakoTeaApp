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

        public int GetNewComboMealID(string comboMealName)
        {
            using (var context = new Entities())
            {
                var comboMeal = context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == comboMealName);
                return comboMeal?.ComboMealID ?? 0; // Return the ComboMealID of the newly inserted combo meal
            }
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

        public List<ProductVariant> GetLinkedProductVariants(int productId)
        {
            return _context.ProductVariants.Where(v => v.ProductID == productId).ToList();
        }

        public void ImportProducts(string filePath)
        {
            // Add logic for importing products from a file
        }
        // TODO: Refactor this method

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
    }
}
