using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using TakoTea.Helpers;
using TakoTea.Models;

namespace TakoTea.Views.Batches
{
    public partial class EditBatchModal2 : MaterialForm
    {
        private readonly int _ingredientId;

        public EditBatchModal2(int ingredientId)
        {
            InitializeComponent();
            _ingredientId = ingredientId;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadBatchData();
        }

        private void LoadBatchData()
        {
            using (var context = new Entities()) // Replace with your actual DbContext class
            {
                // Remove invalid Include("Ingredient") and just load the ingredient
                var ingredient = context.Ingredients
                    .FirstOrDefault(b => b.IngredientID == _ingredientId);

                if (ingredient == null)
                {
                    DialogHelper.ShowError("Batch not found.");
                    Close();
                    return;
                }

                txtBoxName.Text = ingredient.IngredientName;
                txtBoxItemDescription.Text = ingredient.Description;
                txtBoxBrandName.Text = ingredient.BrandName;
/*                cmbboxStorageCondition.SelectedItem = ingredient.StorageConditions.ToString();
*/                pictureBoxImg.ImageLocation = ingredient.IngredientImage;

                if (ingredient.IsAddOn == false)
                {
                    rdButtonIsAddOnNo.Checked = true; rdButtonIsAddOnYes.Checked = false;
                }
                else
                {
                    rdButtonIsAddOnYes.Checked = true; rdButtonIsAddOnNo.Checked = false;
                }


                // Ingredient-specific data
                cmbTypeOfIngredient.SelectedItem = ingredient.TypeOfIngredient.ToString();
                // Uncomment and modify according to your allergens data
                // CheckedListBoxHelper.SetCheckedItems(materialCheckedListBoxAllergens, ingredient.Allergens);
            }
        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            if (!DialogHelper.ShowConfirmation("Are you sure you want to save the ingredient?"))
                return;

            try
            {
                using (var context = new Entities())
                {
                    // Retrieve the ingredient and update fields
                    var ingredient = context.Ingredients
                        .FirstOrDefault(b => b.IngredientID == _ingredientId);

                    if (ingredient == null)
                    {
                        DialogHelper.ShowError("Batch not found.");
                        return;
                    }

                    // Update ingredient details
                    ingredient.IngredientName = txtBoxName.Text;
                    ingredient.Description = txtBoxItemDescription.Text;
                    ingredient.BrandName = txtBoxBrandName.Text;
                    ingredient.StorageConditions = cmbboxStorageCondition.SelectedItem.ToString();
                    ingredient.IngredientImage = pictureBoxImg.ImageLocation;

                    // Update ingredient details
                    ingredient.TypeOfIngredient = cmbTypeOfIngredient.SelectedItem.ToString();
                    // ingredient.AllergyInformation = CheckedListBoxHelper.GetCheckedItemsAsString(materialCheckedListBoxAllergens);

                    // Save changes
                    context.SaveChanges();

                    DialogHelper.ShowSuccess("Batch saved successfully!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to save the ingredient. Error: {ex.Message}");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadBatchData();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            // Confirm cancel action
            DialogResult dialogResult = MessageBox.Show(
                  "Are you sure you want to cancel? Any unsaved changes will be lost.",
                  "Confirm Cancel",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning
              );

            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void pbMUnitReset_Click(object sender, EventArgs e)
        {
            // Add logic for resetting unit if needed
        }
    }
}
