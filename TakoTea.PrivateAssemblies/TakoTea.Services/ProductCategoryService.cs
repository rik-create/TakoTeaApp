using System;
using System.Data.SqlClient;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;

namespace TakoTea.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly DataAccessObject _dataAccessObject;

        public ProductCategoryService(DataAccessObject dataAccessObject)
        {
            _dataAccessObject = dataAccessObject;
        }

        public void Save(ProductCategoryModel productCategory)
        {
            if (productCategory == null)
            {
                throw new ArgumentNullException(nameof(productCategory));
            }

            string query = @"
                INSERT INTO ProductCategories (Name, Category, Image)
                VALUES (@Name, @Category, @Image)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", productCategory.Name),
                new SqlParameter("@Category", productCategory.Category),
                new SqlParameter("@Image", productCategory.Image)
            };

            _dataAccessObject.ExecuteNonQuery(query, parameters);
        }
    }
}
