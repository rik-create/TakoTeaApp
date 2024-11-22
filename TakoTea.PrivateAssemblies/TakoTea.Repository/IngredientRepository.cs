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
namespace TakoTea.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly SqlConnection _connection;
        private readonly DataAccessObject _dao;
        private readonly Entities _context;
        public IngredientRepository(DataAccessObject _dao)
        {
            _connection = DatabaseConnection.GetConnection();
            this._dao = _dao;
            _context = new Entities();
        }

        // Method to load ingredient data
        // Method to load ingredient data
        public List<object> GetAllIngredients()
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




        public DataTable GetCurrentStockLevels()
        {
            string query = @"
    SELECT 
        b.BatchID,
        i.IngredientID, 
        i.IngredientName,
        b.QuantityInStock,
        b.ReorderLevel
    FROM 
        Ingredient i
    JOIN 
        Batch b ON i.IngredientID = b.IngredientID
    WHERE 
        b.IsActive = 1";
            return _dao.ExecuteQuery(query);
        }
        public void UpdateStockLevel(int ingredientID, decimal newQuantity)
        {
            const string query = @"
        UPDATE Batch
        SET QuantityInStock = @NewQuantity
        WHERE IngredientID = @IngredientID;
    ";
            // Use a using statement to handle the connection lifecycle
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                _ = connection.Execute(query, new { IngredientID = ingredientID, NewQuantity = newQuantity });
            }
        }
        public IngredientModel GetIngredientById(int ingredientId)
        {
            string query = "SELECT * FROM IngredientModel WHERE IngredientID = @IngredientID";
            return _connection.QuerySingleOrDefault<IngredientModel>(query, new { IngredientID = ingredientId });
        }
        public string GetIngredientNameById(int ingredientId)
        {
            string query = "SELECT IngredientName FROM IngredientModel WHERE IngredientID = @IngredientID";
            return _connection.QueryFirstOrDefault<string>(query, new { IngredientID = ingredientId });
        }
        public decimal GetPreviousQuantity(int ingredientId)
        {
            string query = "SELECT QuantityInStock FROM Batch WHERE IngredientID = @IngredientID AND IsActive = 1";
            return _connection.QueryFirstOrDefault<decimal>(query, new { IngredientID = ingredientId });
        }

        public int GetIngredientIdUsingBatch(int batchId)
        {
            string query = "SELECT IngredientID FROM Batches WHERE BatchID = @BatchID";
            var parameters = new SqlParameter[]
            {
            new SqlParameter("@BatchID", batchId)
            };

            var result = _dao.ExecuteQuery<int>(query, parameters);
            return result.FirstOrDefault();
        }


        public string GetIngredientName(int ingredientId)
        {
            string query = "SELECT Name FROM Ingredients WHERE IngredientID = @IngredientID";
            var parameters = new SqlParameter[]
            {
            new SqlParameter("@IngredientID", ingredientId)
            };

            var result = _dao.ExecuteQuery<string>(query, parameters);
            return result.FirstOrDefault();
        }

    }
}
