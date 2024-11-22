using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;

namespace TakoTea.Services
{
    public class ProductVariantService : IProductVariantService
    {
        private readonly DataAccessObject _dataAccessObject;

        public ProductVariantService(DataAccessObject dataAccessObject)
        {
            _dataAccessObject = dataAccessObject;
        }

        public void SaveProductVariant(ProductVariant productVariant)
        {
            if (productVariant == null)
            {
                throw new ArgumentNullException(nameof(productVariant));
            }

            string query = @"
                INSERT INTO ProductVariants (VariantName, Size, Price, Ingredients, Instructions, Image)
                VALUES (@VariantName, @Size, @Price, @Ingredients, @Instructions, @Image)";

            byte[] imageBytes = null;

            if (productVariant.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    productVariant.Image.Save(ms, productVariant.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
            }

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@VariantName", productVariant.VariantName),
                new SqlParameter("@Size", productVariant.Size),
                new SqlParameter("@Price", productVariant.Price),
                new SqlParameter("@Ingredients", productVariant.Ingredients),
                new SqlParameter("@Instructions", productVariant.Instructions),
                new SqlParameter("@Image", imageBytes ?? (object)DBNull.Value)
            };

            _dataAccessObject.ExecuteNonQuery(query, parameters);
        }
    }
}
