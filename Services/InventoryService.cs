using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using TakoTea.Controller.DATABASE;
using TakoTea.Interfaces;
using TakoTea.Model.ENTITY;  // Ensure this namespace is correct

namespace TakoTea.Services
{
    public class InventoryService : IInventoryService
    {
        // Use DatabaseConnection.Instance for accessing the connection
        private readonly SqlConnection _dbConn = DatabaseConnection.GetConnection();




        public void AddIngredient(Ingredient ingredient, BatchIngredient batch, List<int> linkedProductIds)
        {
            using (var connection = _dbConn)
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Insert Ingredient
                        var ingredientID = connection.QuerySingle<int>(
                            "INSERT INTO Ingredient (IngredientName, BrandName, Description, MeasuringUnit, " +
                            "IngredientImage, IsAddOn, TypeOfIngredient, IsActive, AllergyInformation) " +
                            "VALUES (@IngredientName, @BrandName, @Description, @MeasuringUnit, @IngredientImage, " +
                            "@IsAddOn, @TypeOfIngredient, @IsActive, @AllergyInformation); " +
                            "SELECT CAST(SCOPE_IDENTITY() as int);",
                            ingredient, transaction);

                        // Step 2: Insert Batch
                        batch.IngredientID = ingredientID;
                        connection.Execute(
                            "INSERT INTO Batch (BatchNumber, IngredientID, QuantityInStock, ReorderLevel, ExpirationDate, " +
                            "Supplier, StorageConditions, IsActive, BatchCost) " +
                            "VALUES (@BatchNumber, @IngredientID, @QuantityInStock, @ReorderLevel, @ExpirationDate, @Supplier, " +
                            "@StorageConditions, @IsActive, @BatchCost);",
                            batch, transaction);

                        // Step 3: Insert Ingredient-Product Links
                        foreach (var linkedProductId in linkedProductIds)
                        {
                            connection.Execute(
                                "INSERT INTO IngredientProductLink (IngredientID, ProductID) VALUES (@IngredientID, @ProductID);",
                                new { IngredientID = ingredientID, ProductID = linkedProductId }, transaction);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
