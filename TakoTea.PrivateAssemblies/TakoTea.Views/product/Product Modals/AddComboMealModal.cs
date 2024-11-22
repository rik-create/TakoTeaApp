using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;

namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddComboMealModal : MaterialForm
    {
        public AddComboMealModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
        }

        private void AddComboMealModal_Load(object sender, EventArgs e)
        {
            // Set all columns as read-only except for Quantity column
            foreach (DataGridViewColumn column in dgViewAddComboMeal.Columns)
            {
                column.ReadOnly = true; // Make all columns read-only
            }
            dgViewAddComboMeal.Columns["Quantity"].ReadOnly = false; // Make Quantity column editable
        }

        // Button click to open SelectVariantModal and add selected variants
        private void btnAddNewVariant_Click(object sender, EventArgs e)
        {
            using (SelectVariantModal selectVariantModal = new SelectVariantModal())
            {
                // Open the SelectVariantModal as a dialog and check if variants were selected
                if (selectVariantModal.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected variants from the modal
                    var selectedVariants = selectVariantModal.SelectedVariants;

                    // Add each selected variant to the DataGridView
                    foreach (var variant in selectedVariants)
                    {
                        int rowIndex = dgViewAddComboMeal.Rows.Add();
                        var row = dgViewAddComboMeal.Rows[rowIndex];

                        // Populate the row with the variant's details
                        row.Cells["ColumnVarName"].Value = variant.VariantName;
                        row.Cells["ColumnSize"].Value = variant.Size;
                        row.Cells["ColumnPrice"].Value = variant.Price;
                        row.Cells["ColumnImage"].Value = variant.Image;
                        row.Cells["Quantity"].Value = 1; // Default Quantity is 1
                    }
                }
            }
        }

        // Event to handle the Duplicate Row functionality
        private void btnDuplicateRow_Click(object sender, EventArgs e)
        {
            if (dgViewAddComboMeal.SelectedRows.Count > 0)
            {
                var selectedRow = dgViewAddComboMeal.SelectedRows[0];
                var newRow = (DataGridViewRow)selectedRow.Clone();

                // Copy all cell values from the selected row to the new row
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Add the new row to the DataGridView
                dgViewAddComboMeal.Rows.Add(newRow);
            }
        }

        // Event to handle the Delete Row functionality
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgViewAddComboMeal.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dgViewAddComboMeal.SelectedRows)
                {
                    // Ensure the row isn't the last row (so we don't delete all rows)
                    if (!selectedRow.IsNewRow)
                    {
                        dgViewAddComboMeal.Rows.RemoveAt(selectedRow.Index);
                    }
                }
            }
        }
    }
}
