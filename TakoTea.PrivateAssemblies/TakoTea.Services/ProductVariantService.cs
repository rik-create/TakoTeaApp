﻿using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;

namespace TakoTea.Services
{
    public class ProductVariantService : IProductVariantService
    {
        private readonly DataAccessObject _dataAccessObject;

        public ProductVariantService(DataAccessObject dataAccessObject)
        {

        }

        public void SaveProductVariant(ProductVariant productVariant)
        {

        }
    }
}
