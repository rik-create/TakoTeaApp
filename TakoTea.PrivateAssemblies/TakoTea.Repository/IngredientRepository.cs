using Dapper;
using System.Data;
using System.Data.SqlClient;
using TakoTea.Database;
using TakoTea.Interfaces;
using TakoTea.Models;
namespace TakoTea.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly SqlConnection _connection;
        private readonly DataAccessObject _dao;
        public IngredientRepository()
        {
            _connection = DatabaseConnection.GetConnection();
            _dao = new DataAccessObject();
        }
        public DataTable GetCurrentStockLevels()
        {
            string query = @"
    SELECT 
        i.IngredientID, 
        i.IngredientName,
        b.QuantityInStock,
        i.MeasuringUnit,
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
        public Ingredient GetIngredientById(int ingredientId)
        {
            string query = "SELECT * FROM Ingredient WHERE IngredientID = @IngredientID";
            return _connection.QuerySingleOrDefault<Ingredient>(query, new { IngredientID = ingredientId });
        }
        public string GetIngredientNameById(int ingredientId)
        {
            string query = "SELECT IngredientName FROM Ingredient WHERE IngredientID = @IngredientID";
            return _connection.QueryFirstOrDefault<string>(query, new { IngredientID = ingredientId });
        }
        public decimal GetPreviousQuantity(int ingredientId)
        {
            string query = "SELECT QuantityInStock FROM Batch WHERE IngredientID = @IngredientID AND IsActive = 1";
            return _connection.QueryFirstOrDefault<decimal>(query, new { IngredientID = ingredientId });
        }
    }
}
