using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakoTea.Views.Batch.Batch_Modals
{
    public partial class EditBatchForm : Form
    {
        private string _batchNumber; // Holds the batch number for editing

        public EditBatchForm(string batchNumber)
        {
            _batchNumber = batchNumber;

            InitializeComponent();
        LoadBatchData(_batchNumber); // Load the batch data when form initializes
            txtBatchNumber.Text = _batchNumber; // Display batch number


        }

        private void LoadBatchData(string batchNumber)
        {
            // Here you would load batch data from the database
            // For now, let's simulate some example data
            // Set manufacturing and expiration dates
            DateTime sampleManufactureDate = DateTime.Now.AddMonths(-1);
            DateTime sampleExpirationDate = DateTime.Now.AddMonths(5);

            // Set these dates in DateTimePicker controls
            foreach (Control control in this.Controls)
            {
                if (control is DateTimePicker dtp && control.Name.Contains("Manufacture"))
                    dtp.Value = sampleManufactureDate;

                if (control is DateTimePicker dtp2 && control.Name.Contains("Expiration"))
                    dtp2.Value = sampleExpirationDate;
            }

            // Load ingredients into DataGridView
            DataGridView dgvIngredients = (DataGridView)this.Controls.Find("dgvIngredients", true)[0];
            dgvIngredients.Rows.Add("Flour", "500");
            dgvIngredients.Rows.Add("Milk", "200");
        }

        private void SaveChanges(DateTimePicker dtpManufactureDate, DateTimePicker dtpExpirationDate, DataGridView dgvIngredients)
        {
            // Retrieve updated batch details
            DateTime manufactureDate = dtpManufactureDate.Value;
            DateTime expirationDate = dtpExpirationDate.Value;

            // Example: Loop through ingredients and updated quantities
            foreach (DataGridViewRow row in dgvIngredients.Rows)
            {
                if (row.Cells["Ingredient"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    string ingredient = row.Cells["Ingredient"].Value.ToString();
                    int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    // Save updated quantity for each ingredient in database
                }
            }

            MessageBox.Show($"Batch {_batchNumber} updated successfully!", "Batch Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Close form after saving changes
        }
    }
}
