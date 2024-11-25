using Xunit;
using Moq;
using System.Windows.Forms;
namespace TakoTea.Tests
{
    public class MenuOrderFormServiceTests
    {
        [Fact]
        public void UpdateStockLevels_ShouldUpdateStockForAllIngredients()
        {
            // Arrange
            var mockDataGridView = new Mock<DataGridView>();
            mockDataGridView.Setup(d => d.Rows).Returns(new DataGridViewRowCollection(new DataGridView()));

            // Add test rows to DataGridView
            var row1 = new DataGridViewRow();
            row1.Cells.Add(new DataGridViewTextBoxCell { Value = "Product1" });
            row1.Cells.Add(new DataGridViewTextBoxCell { Value = "Small" });
            row1.Cells.Add(new DataGridViewTextBoxCell { Value = 5 });
            mockDataGridView.Object.Rows.Add(row1);

            // Mock method for GetIngredientsForProductVariant
            var mockService = new Mock<IService>(); // Replace IService with actual service interface
            mockService.Setup(s => s.GetIngredientsForProductVariant("Product1", "Small"))
                       .Returns(new List<Ingredient>
                       {
                   new Ingredient { IngredientID = 1, QuantityPerVariant = 2 }
                       });

            var target = new YourClass(mockService.Object); // Replace with your class name

            // Act
            target.UpdateStockLevels(mockDataGridView.Object);

            // Assert
            mockService.Verify(s => s.UpdateBatchStockLevel(1, 10), Times.Once());
        }

    }
}
