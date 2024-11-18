using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using TakoTea.Repository;
using TakoTea.Models;  // Assuming BatchModel is in this namespace

namespace TakoTea.Tests
{
    public class BatchRepositoryTests
    {
        /*        private readonly Mock<DataAccessObject> _mockDao;
                private readonly BatchRepository _batchRepository;

                public BatchRepositoryTests()
                {
                    // Arrange - Initialize the mock DAO and BatchRepository
                    _mockDao = new Mock<DataAccessObject>();
                    _batchRepository = new BatchRepository(_mockDao.Object);
                }

                [Fact]
                public void SaveBatch_ShouldReturnTrue_WhenBatchIsSavedSuccessfully()
                {
                    // Arrange - Create a sample BatchModel with all required arguments
                    var batch = new BatchModel(
                        1, // batchID
                        1, // ingredientID
                        "BATCH123", // batchNumber
                        100, // quantity
                        "kg", // measuringUnit
                        10, // reorderLevel
                        50.0m, // cost
                        DateTime.Now.AddMonths(1), // expiration
                        "Test Item Description", // itemDescription
                        "Test Brand", // brandName
                        "Test Vendor", // vendor
                        "Cool", // storageCondition
                        "image.jpg", // ingredientImage
                        "Spice", // ingredientType
                        new List<string> { "Function1", "Function2" }, // ingredientFunctions
                        new List<string> { "Allergen1", "Allergen2" } // ingredientAllergens
                    );

                    // Mock the behavior of the DAO's UpdateRecord method to return true
                    _mockDao.Setup(dao => dao.UpdateRecord(It.IsAny<string>(), It.IsAny<SqlParameter[]>())).Returns(true);

                    // Act - Call the SaveBatch method
                    var result = _batchRepository.SaveBatch(batch);

                    // Assert - Verify that SaveBatch returns true indicating success
                    Assert.True(result);
                    // Ensure that the UpdateRecord method was called once
                    _mockDao.Verify(dao => dao.UpdateRecord(It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Once);
                }

                [Fact]
                public void SaveBatch_ShouldReturnFalse_WhenBatchUpdateFails()
                {
                    // Arrange - Create a sample BatchModel with all required arguments
                    var batch = new BatchModel(
                        1, // batchID
                        1, // ingredientID
                        "BATCH123", // batchNumber
                        100, // quantity
                        "kg", // measuringUnit
                        10, // reorderLevel
                        50.0m, // cost
                        DateTime.Now.AddMonths(1), // expiration
                        "Test Item Description", // itemDescription
                        "Test Brand", // brandName
                        "Test Vendor", // vendor
                        "Cool", // storageCondition
                        "image.jpg", // ingredientImage
                        "Spice", // ingredientType
                        new List<string> { "Function1", "Function2" }, // ingredientFunctions
                        new List<string> { "Allergen1", "Allergen2" } // ingredientAllergens
                    );

                    // Mock the behavior of the DAO's UpdateRecord method to return false (simulate failure)
                    _mockDao.Setup(dao => dao.UpdateRecord(It.IsAny<string>(), It.IsAny<SqlParameter[]>())).Returns(false);

                    // Act - Call the SaveBatch method
                    var result = _batchRepository.SaveBatch(batch);

                    // Assert - Verify that SaveBatch returns false indicating failure
                    Assert.False(result);
                    // Ensure that the UpdateRecord method was called once
                    _mockDao.Verify(dao => dao.UpdateRecord(It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Once);
                }
            }*/
    }
}
