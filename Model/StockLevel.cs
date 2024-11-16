namespace TakoTea.Model
{
    public class StockLevel
    {

        public int IngredientID { get; set; }

        public string IngredientName { get; set; }
        public decimal QuantityInStock { get; set; }
        public string MeasuringUnit { get; set; }
        public decimal ReorderLevel { get; set; }
    }

}
