using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TakoTea.Model.ENTITY;
using TakoTea.Services;
using TakoTea.View.Items.Item_Modals;
using TakoTea.Interfaces;


namespace TakoTea.TESTS
{

    public class AddItemModalTests
    {
        private readonly Mock<IInventoryService> _mockInventoryService;
        private readonly AddItemModal _addItemModal;

        public AddItemModalTests()
        {
            _mockInventoryService = new Mock<IInventoryService>();
            _addItemModal = new AddItemModal(_mockInventoryService.Object);

            // Set up mock for form controls if needed
            // _addItemModal.txtBoxName.Text = "Ingredient Name";
            // _addItemModal.txtBoxBrandName.Text = "Brand Name";
            // etc.
        }

      
        [Fact]
        public void BtnConfirm_Click_ShouldInvokeAddIngredient()
        {
            // Arrange
            // Create a mock of IInventoryService
            var mockInventoryService = new Mock<IInventoryService>();

            // Create the AddItemModal with the mocked IInventoryService
            var addItemModal = new AddItemModal(mockInventoryService.Object);

            // Set up the form controls to simulate user input
            addItemModal.txtBoxName.Text = "Test Ingredient";
            addItemModal.txtBoxBrandName.Text = "Test Brand";
            addItemModal.txtBoxItemDescription.Text = "Test Description";
            addItemModal.cmbBoxMeasuringUnit.SelectedItem = "kg";
            addItemModal.pictureBoxImg.ImageLocation = "path/to/image";
            addItemModal.rdButtonIsAddOnYes.Checked = true;
            addItemModal.cmbTypeOfIngredient.SelectedItem = "Spices";
            addItemModal.materialCheckedListBoxAllergens.Items.Add("Gluten");
            addItemModal.materialCheckedListBoxAllergens.Items[0].Checked = true; // Assume allergen is checked
            addItemModal.txtBoxBatchNumber.Text = "BATCH123";
            addItemModal.numericUpDownCost.Value = 100;
            addItemModal.numericUpDownLowLevel.Value = 10;
            addItemModal.dateTimePickerExpiration.Value = DateTime.Now.AddMonths(6);
            addItemModal.txtBoxVendor.Text = "Supplier Inc.";
            addItemModal.cmbboxStorageCondition.SelectedItem = "Cool, Dry Place";
            addItemModal.chkListBoxIngredientFunction.Items.Add("Function 1");
            addItemModal.chkListBoxIngredientFunction.Items[0].Checked = true;

            // Act: Trigger the button click event
            addItemModal.btnConfirm.PerformClick();

            // Assert: Verify that AddIngredient was called once with the correct parameters
            mockInventoryService.Verify(service => service.AddIngredient(
                It.Is<Ingredient>(i => i.IngredientName == "Test Ingredient" &&
                                       i.BrandName == "Test Brand" &&
                                       i.Description == "Test Description" &&
                                       i.MeasuringUnit == "kg" &&
                                       i.IngredientImage == "path/to/image" &&
                                       i.IsAddOn == true &&
                                       i.TypeOfIngredient == "Spices" &&
                                       i.AllergyInformation == "Gluten"), // Ensuring the allergen is set correctly
                It.Is<BatchIngredient>(b => b.BatchNumber == "BATCH123" &&
                                            b.QuantityInStock == 100 &&
                                            b.ReorderLevel == 10 &&
                                            b.ExpirationDate == addItemModal.dateTimePickerExpiration.Value &&
                                            b.Supplier == "Supplier Inc." &&
                                            b.StorageConditions == "Cool, Dry Place" &&
                                            b.BatchCost == 100),
                It.Is<List<int>>(ids => ids.Contains(1) && ids.Count == 1) // Checking the linked product ID
            ), Times.Once);
        }


        [Fact]
        public void BtnConfirm_Click_ShouldHandleException()
        {
            // Arrange: Set up the mock to throw an exception
            _mockInventoryService.Setup(service => service.AddIngredient(It.IsAny<Ingredient>(), It.IsAny<BatchIngredient>(), It.IsAny<List<int>>()))
                                 .Throws(new Exception("Test exception"));

            // Act: Trigger button click event
            _addItemModal.btnConfirm.PerformClick();


            // Assert: Verify that an error message is shown to the user (you can mock MessageBox if necessary)
            // You would need to check that the MessageBox is called with the correct exception message
            // For simplicity, assume that `MessageBox.Show` is called with "Error adding item: Test exception"
            // You can use a mocking framework like Moq for MessageBox or verify the dialog manually.
        }
    }

}
