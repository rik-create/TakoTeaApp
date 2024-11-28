using Dapper;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using TakoTea.Database;
using TakoTea.Interfaces;
using TakoTea.Models;
using System.Windows.Forms;
namespace TakoTea.Repository
{
    public class IngredientRepository : IIngredientRepository
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
                var batchList = _context.Batches.ToList();

                return batchList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading Batches: " + ex.Message);
            }
        }


        // Method to load ingredient data
        public List<object> GetAllIngredient()
        {
            try
            {
                // Query to fetch the ingredient data
                var ingredientList = _context.Ingredients
                    .Select(i => new
                    {
                        i.IngredientID,
                        i.IngredientName,
                        i.BrandName,
                        i.StockLevel,
                        i.LowLevel,
                        AddOn = i.IsAddOn.HasValue && i.IsAddOn.Value ? "Yes" : "No"
                    })
                    .ToList<object>(); // Cast to List<object> to match the return type

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
                var ingredient = _context.Ingredients.ToList();

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
            _context.Database.ExecuteSqlCommand(query, new SqlParameter("@IngredientID", ingredientID), new SqlParameter("@NewQuantity", newQuantity));
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

        public DataTable GetCurrentStockLevels()
        {
            throw new NotImplementedException();
        }
    }
}
