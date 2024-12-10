using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TakoTea.Models;

namespace TakoTea.View.Product.Product_Modals
{
    public partial class SelectVariantModal : MaterialForm
    {
        public List<ProductVariant> SelectedVariants { get; private set; }

        // Example list of product variants for demonstration
        private readonly List<ProductVariant> allVariants = new List<ProductVariant>
        {

        };

        public SelectVariantModal()
        {
            InitializeComponent();
            SelectedVariants = new List<ProductVariant>();
        }

        private void SelectVariantModal_Load(object sender, EventArgs e)
        {
            // Set up the DataGridView to display product variants
            dataGridViewVariants.DataSource = allVariants;

            // Allow multi-selection in the DataGridView
            dataGridViewVariants.MultiSelect = true;
            dataGridViewVariants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Optionally, hide or adjust columns (e.g., Image column)
            dataGridViewVariants.Columns["Image"].Visible = false; // Hide the image column if necessary
        }

        private void btnSelectVariants_Click(object sender, EventArgs e)
        {
            // Loop through the selected rows and add them to the SelectedVariants list
            foreach (DataGridViewRow row in dataGridViewVariants.SelectedRows)
            {
                if (row.DataBoundItem is ProductVariant variant)
                {
                    SelectedVariants.Add(variant);
                }
            }

            // Close the modal and return the selected variants
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


