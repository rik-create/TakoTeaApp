using System;
using System.Drawing;
using System.IO;
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
             var context = new Entities();
            var ingredient = context.Ingredients.FirstOrDefault(b => b.IngredientID == _ingredientId);

            if (ingredient == null)
            {
                DialogHelper.ShowError("Batch not found.");
                Close();
                return;
            }

            txtBoxName.Text = ingredient.IngredientName;
            txtBoxItemDescription.Text = ingredient.Description;
            txtBoxBrandName.Text = ingredient.BrandName;

            // Load the image from the byte array
            if (ingredient.IngredientImage?.Length > 0)
            {
                try
                {
                     MemoryStream ms = new MemoryStream(ingredient.IngredientImage);
                    pictureBoxImg.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                }
            }

            if (ingredient.IsAddOn == false)
            {
                rdButtonIsAddOnNo.Checked = true;
                rdButtonIsAddOnYes.Checked = false;
            }
            else
            {
                rdButtonIsAddOnYes.Checked = true;
                rdButtonIsAddOnNo.Checked = false;
            }

            cmbTypeOfIngredient.SelectedItem = ingredient.TypeOfIngredient.ToString();
        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            if (!DialogHelper.ShowConfirmation("Are you sure you want to save the ingredient?"))
            {
                return;
            }

            try
            {
                var context = new Entities();
                var ingredient = context.Ingredients.FirstOrDefault(b => b.IngredientID == _ingredientId);

                if (ingredient == null)
                {
                    DialogHelper.ShowError("Batch not found.");
                    return;
                }

                ingredient.IngredientName = txtBoxName.Text;
                ingredient.Description = txtBoxItemDescription.Text;
                ingredient.BrandName = txtBoxBrandName.Text;
                ingredient.StorageConditions = cmbboxStorageCondition.SelectedItem.ToString();

                // Convert the image to a byte array and store it
                using (var ms = new MemoryStream())
                {
                    pictureBoxImg.Image.Save(ms, pictureBoxImg.Image.RawFormat);
                    ingredient.IngredientImage = ms.ToArray();
                }

                ingredient.TypeOfIngredient = cmbTypeOfIngredient.SelectedItem.ToString();

                context.SaveChanges();

                DialogHelper.ShowSuccess("Batch saved successfully!");
                DialogResult = DialogResult.OK;
                Close();
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
