using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Services;

namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddProductModal : MaterialForm
    {

        private readonly IProductVariantService _productVariantService;
        public AddProductModal(IProductVariantService productVariantService)
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            _productVariantService = productVariantService;
        }

        private void AddProductModal_Load(object sender, EventArgs e)
        {
            // Set up initial settings for the DataGridView
            dgViewAddingMultipleProductVariants.RowsAdded += DgViewAddingMultipleProductVariants_RowsAdded;
            dgViewAddingMultipleProductVariants.AllowUserToAddRows = false; // Prevent adding rows manually
        }

        // Handle Add New Row button click
        private void btnAddNewRow_Click(object sender, EventArgs e)
        {
            // Add a new empty row
            dgViewAddingMultipleProductVariants.Rows.Add();
        }

        // Handle Duplicate Row button click
        private void btnDuplicateRow_Click(object sender, EventArgs e)
        {
            if (dgViewAddingMultipleProductVariants.SelectedRows.Count > 0)
            {
                var selectedRow = dgViewAddingMultipleProductVariants.SelectedRows[0];
                var newRow = (DataGridViewRow)selectedRow.Clone();

                // Copy all cell values from the selected row to the new row
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Add the new row to the grid
                dgViewAddingMultipleProductVariants.Rows.Add(newRow);
            }
        }

        // Handle Delete Row button click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgViewAddingMultipleProductVariants.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dgViewAddingMultipleProductVariants.SelectedRows)
                {
                    // Ensure the row isn't the last row (so we don't delete all rows)
                    if (!selectedRow.IsNewRow)
                    {
                        dgViewAddingMultipleProductVariants.Rows.RemoveAt(selectedRow.Index);
                    }
                }
            }
        }

        // Handle uploading an image to the selected row
        private void btnUploadImgToSelectedRow_Click(object sender, EventArgs e)
        {
            if (dgViewAddingMultipleProductVariants.SelectedRows.Count > 0)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected row
                        var selectedRow = dgViewAddingMultipleProductVariants.SelectedRows[0];

                        // Get the image file path and set it to the Image column
                        string imagePath = openFileDialog.FileName;
                        selectedRow.Cells["ColumnImage"].Value = Image.FromFile(imagePath);
                    }
                }
            }
        }

        // Event to handle Row Added event, to ensure consistent formatting or behavior
        private void DgViewAddingMultipleProductVariants_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Set default values or behavior when a new row is added
            foreach (DataGridViewRow row in dgViewAddingMultipleProductVariants.Rows)
            {
                if (row.Cells[ColumnVarName.Index].Value == null)
                {
                    row.Cells[ColumnVarName.Index].Value = "New Variant";
                }
                if (row.Cells[ColumnSize.Index].Value == null)
                {
                    row.Cells[ColumnSize.Index].Value = "Medium";
                }
                if (row.Cells[ColumnPrice.Index].Value == null)
                {
                    row.Cells[ColumnPrice.Index].Value = "0.00";
                }
                if (row.Cells[ColumnIngredients.Index].Value == null)
                {
                    row.Cells[ColumnIngredients.Index].Value = "None";
                }
                if (row.Cells[ColumnInstructions.Index].Value == null)
                {
                    row.Cells[ColumnInstructions.Index].Value = "Prepare as usual.";
                }
            }
        }

        // Cancel button to close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Save button to handle saving all variants
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgViewAddingMultipleProductVariants.Rows)
            {
                if (row.IsNewRow) continue;

                string variantName = row.Cells[ColumnVarName.Index].Value?.ToString();
                string size = row.Cells[ColumnSize.Index].Value?.ToString();
                decimal price = Convert.ToDecimal(row.Cells[ColumnPrice.Index].Value ?? 0);
                string ingredients = row.Cells[ColumnIngredients.Index].Value?.ToString();
                string instructions = row.Cells[ColumnInstructions.Index].Value?.ToString();
                Image image = row.Cells[ColumnImage.Index].Value as Image;

                var productVariant = new ProductVariant(variantName, size, price, ingredients, instructions, image);

                try
                {
                    _productVariantService.SaveProductVariant(productVariant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save variant '{variantName}'. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Product variants have been saved successfully.");
            Close();
        }
    }
}
