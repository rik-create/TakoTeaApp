﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TakoTea.Models;
namespace TakoTea.Repository
{
    public class IngredientRepository
    {
        private readonly Entities _context;

        public IngredientRepository(Entities context)
        {
            _context = context;
        }

        public List<Batch> GetAllBatch()
        {
            try
            {
                // Simply retrieve all product variants without any projection
                List<Batch> batchList = _context.Batches.ToList();

                return batchList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading Batches: " + ex.Message);
            }
        }



        public class IngredientDto
        {
            public int IngredientID { get; set; }
            public string IngredientName { get; set; }
            public string BrandName { get; set; }
            public decimal StockLevel { get; set; }
            public decimal LowLevel { get; set; }
            public string AddOn { get; set; }
        }
        // Method to load ingredient data
        public List<IngredientDto> GetAllIngredient()
        {
            try
            {
                List<IngredientDto> ingredientList = _context.Ingredients
                    .Select(i => new IngredientDto
                    {
                        IngredientID = i.IngredientID,
                        IngredientName = i.IngredientName,
                        BrandName = i.BrandName,
                        StockLevel = i.StockLevel.Value,
                        LowLevel = i.LowLevel.Value,
                        AddOn = i.IsAddOn.HasValue && i.IsAddOn.Value ? "Yes" : "No"
                    })
                    .ToList();

                return ingredientList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading ingredients: " + ex.Message);
            }
        }

        public List<Ingredient> GetAllIngredients()
        {
            try
            {
                // Simply retrieve all product variants without any projection
                List<Ingredient> ingredient = _context.Ingredients.ToList();

                return ingredient;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading ingredient: " + ex.Message);
            }

        }


        public void UpdateStockLevel(int ingredientID, decimal newQuantity)
        {
            const string query = @"
                    UPDATE Batch
                    SET QuantityInStock = @NewQuantity
                    WHERE IngredientID = @IngredientID";
            _ = _context.Database.ExecuteSqlCommand(query, new SqlParameter("@IngredientID", ingredientID), new SqlParameter("@NewQuantity", newQuantity));
        }



        public string GetIngredientNameById(int ingredientId)
        {
            return _context.Ingredients
                .Where(i => i.IngredientID == ingredientId)
                .Select(i => i.IngredientName)
                .FirstOrDefault();
        }

        public decimal GetPreviousQuantity(int ingredientId)
        {
            return _context.Batches
                .Where(b => b.IngredientID == ingredientId && b.IsActive == true)
                .Select(b => b.StockLevel)
                .FirstOrDefault();
        }

        public int GetIngredientIdUsingBatch(int batchId)
        {
            return (int)_context.Batches
                .Where(b => b.BatchID == batchId)
                .Select(b => b.IngredientID)
                .FirstOrDefault();
        }

        public string GetIngredientName(int ingredientId)
        {
            return _context.Ingredients
                .Where(i => i.IngredientID == ingredientId)
                .Select(i => i.IngredientName)
                .FirstOrDefault();
        }

        public IngredientModel GetIngredientById(int ingredientId)
        {
            throw new NotImplementedException();
        }
        public List<object> GetLowStockIngredients()
        {
            try
            {
                List<object> lowStockIngredients = _context.Ingredients
                    .Where(i => i.StockLevel <= i.LowLevel)
                    .Select(i => new
                    {
                        i.IngredientName,
                        i.StockLevel,
                        i.LowLevel
                    })
                    .ToList<object>();

                return lowStockIngredients;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading low stock ingredients: " + ex.Message);
            }
        }
        public void UpdateNullStockLevels()
        {
            try
            {
                var ingredientsWithNullStock = _context.Ingredients.Where(i => !i.StockLevel.HasValue).ToList();
                foreach (var ingredient in ingredientsWithNullStock)
                {
                    ingredient.StockLevel = 0;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating null stock levels: " + ex.Message);
            }
        }


    }
}
