using System;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Helpers.Validators;
using TakoTea.Interfaces;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.Views.DataLoaders.Modals;

namespace TakoTea.Views.Stock.Stock_Modal
{
    public partial class EditStockModal : Form
    {
        private readonly int _batchId;  // Changed from _ingredientId to _batchId
        private readonly BatchRepository _batchRepository;
        private readonly StockAdjustmentRepository _stockAdjustmentRepository;
        private readonly StockService _stockManagementService;

        private readonly DataAccessObject _dao;

        public EditStockModal(int batchId, DataAccessObject dao)
        {
            InitializeComponent();
            _dao = dao;

            _batchRepository = new BatchRepository(_dao);  // Using BatchRepository now
            _stockAdjustmentRepository = new StockAdjustmentRepository(_batchRepository);  // Adjusted for BatchRepository
            _stockManagementService = new StockService(_batchRepository, _stockAdjustmentRepository);  // Adjusted for BatchRepository
            _batchId = batchId;
        }

        private void EditStockModal_Load(object sender, EventArgs e)
        {
            // Create the data loader for batches and load the data
            IModalDataLoader dataLoader = ModalDataLoaderFactory.GetDataLoader(this, _batchId);  // Adjusted for Batch
            dataLoader.LoadData(this);
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

            // Get the current quantity of the batch to calculate the adjusted quantity
            decimal currentQuantity = _batchRepository.GetPreviousQuantity(_batchId);
            decimal adjustedQuantity = adjustmentType == "Addition" ? newQuantity - currentQuantity : currentQuantity - newQuantity;

            // Confirm the action
            if (!DialogHelper.ShowConfirmation("Are you sure you want to apply this stock adjustment?"))
            {
                return;
            }

            try
            {
                // Adjust the batch stock
                _stockManagementService.AdjustBatchStock(_batchId, adjustedQuantity, reason, 1);// ex user id
                DialogHelper.ShowSuccess("Batch stock adjustment successful!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to adjust batch stock. Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset the data using the data loader for batch
            IModalDataLoader dataLoader = ModalDataLoaderFactory.GetDataLoader(this, _batchId);  // Adjusted for Batch
            dataLoader.ResetData(this);
        }
    }
}
