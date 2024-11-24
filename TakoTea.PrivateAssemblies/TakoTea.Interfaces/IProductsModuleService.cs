using System;
using System.Collections.Generic;
using TakoTea.Models;

namespace TakoTea.Interfaces
{
    public interface IProductsService
    {
        // Product List Features
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        List<ProductVariant> GetLinkedProductVariants(int productId);
        void ImportProducts(string filePath);
        void TrackProductAuditHistory(int productId);

        // Product Variant List Features
        List<ProductVariant> GetAllProductVariants();

        ProductVariant GetProductVariantById(int variantId);
        void AddProductVariant(ProductVariant productVariant);
        void AddMultipleProductVariants(List<ProductVariant> productVariants);
        void UpdateProductVariant(ProductVariant productVariant);
        void DeleteProductVariant(int variantId);
        void ImportProductVariants(string filePath);
        void ExportProductVariants(string filePath, Dictionary<string, object> filters = null);

        // Filtering Features
        List<Product> FilterProducts(Dictionary<string, object> filters);
        List<ProductVariant> FilterProductVariants(Dictionary<string, object> filters);
        List<string> GetProductNames();
        void AddProductVariantIngredient(ProductVariantIngredient ingredient);
        int GetProductIdByName(string selectedProductName);
    }
}
