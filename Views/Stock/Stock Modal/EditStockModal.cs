using System;
using System.Windows.Forms;
using TakoTea.HELPERS;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.Validator;

namespace TakoTea.View.Stock.Stock_Modal
{
    public partial class EditStockModal : Form
    {
        private readonly IngredientRepository _ingredientRepository;
        private readonly StockAdjustmentRepository _stockAdjustmentRepository;
        private readonly StockService _stockManagementService;

        public int IngredientID { get; }
        public string IngredientName { get; }
        public decimal CurrentQuantity { get; }
        public string MeasuringUnit { get; }
        public decimal ReorderLevel { get; }

        public EditStockModal(int ingredientId, string ingredientName, decimal currentQuantity, string measuringUnit, decimal reorderLevel)
        {
            InitializeComponent();
            _ingredientRepository = new IngredientRepository();
            _stockAdjustmentRepository = new StockAdjustmentRepository(_ingredientRepository);
            _stockManagementService = new StockService(_ingredientRepository, _stockAdjustmentRepository);

            IngredientID = ingredientId;
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
            cmbAdjustmentType.SelectedIndex = 0;
            txtReason.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal newQuantity = numNewQuantity.Value;
            string adjustmentType = cmbAdjustmentType.SelectedItem.ToString();
            string reason = txtReason.Text;

            // Validate the adjustment before proceeding
            if (!StockAdjustmentValidator.ValidateStockAdjustment(newQuantity, adjustmentType, reason))
            {
                return;
            }

            decimal currentQuantity = _ingredientRepository.GetPreviousQuantity(IngredientID);

            if (currentQuantity == null)
            {
                DialogHelper.ShowError("Failed to retrieve the current stock quantity.");
                return;
            }

            decimal adjustmentQuantity = adjustmentType == "Addition" ? newQuantity - currentQuantity : currentQuantity - newQuantity;

            if (!DialogHelper.ShowConfirmation("Are you sure you want to apply this stock adjustment?"))
            {
                return;
            }

            try
            {
                _stockManagementService.AdjustStock(IngredientID, newQuantity, reason, 1);
                DialogHelper.ShowSuccess("Stock adjustment successful!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to adjust stock. Error: {ex.Message}");
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to cancel? Any unsaved changes will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
