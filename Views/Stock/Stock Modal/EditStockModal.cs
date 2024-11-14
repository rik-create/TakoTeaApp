using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;

namespace TakoTea.View.Stock.Stock_Modal
{
    public partial class EditStockModal : Form
    {
        public string IngredientName { get; }
        public decimal CurrentQuantity { get; }
        public string MeasuringUnit { get; }
        public decimal ReorderLevel { get; }

        public EditStockModal(string ingredientName, decimal currentQuantity, string measuringUnit, decimal reorderLevel)
        {
            InitializeComponent();
            IngredientName = ingredientName;
            CurrentQuantity = currentQuantity;
            MeasuringUnit = measuringUnit;
            ReorderLevel = reorderLevel;
        }

        private void EditStockModal_Load(object sender, EventArgs e)
        {
            txtBoxIngredientName.Text = IngredientName;
            txtCurrentQuantity.Text = CurrentQuantity.ToString();
            numNewQuantity.Value = CurrentQuantity;
            cmbAdjustmentType.SelectedIndex = 0;  // Default selection
            txtReason.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal newQuantity = numNewQuantity.Value;
            string adjustmentType = cmbAdjustmentType.SelectedItem?.ToString();
            string reason = txtReason.Text;

            if (ValidateInputs(newQuantity, adjustmentType, reason))
            {
                SaveStockAdjustment(newQuantity, adjustmentType, reason);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateInputs(decimal newQuantity, string adjustmentType, string reason)
        {
            if (string.IsNullOrEmpty(adjustmentType))
            {
                MessageBox.Show("Adjustment type is required.");
                return false;
            }
            if (string.IsNullOrEmpty(reason))
            {
                MessageBox.Show("Reason for adjustment is required.");
                return false;
            }
            return true;
        }

        private void SaveStockAdjustment(decimal newQuantity, string adjustmentType, string reason)
        {
            // Save logic here
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}