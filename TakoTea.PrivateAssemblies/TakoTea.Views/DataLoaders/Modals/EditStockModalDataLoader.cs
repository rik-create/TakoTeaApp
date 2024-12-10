using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Views.Stock.Stock_Modal;

namespace TakoTea.Views.DataLoaders.Modals
{
    public class EditStockModalDataLoader : IModalDataLoader
    {
        private readonly int _batchId;  // Changed from _ingredientId to _batchId
        private readonly BatchRepository _batchRepository;
        private readonly DataAccessObject _dao;

        private BatchModel _originalBatch;  // Changed from IngredientModel to BatchModel

        public EditStockModalDataLoader(int batchId)
        {
            _dao = new DataAccessObject();
            _batchId = batchId;
            _batchRepository = new BatchRepository(_dao);
        }

        public void LoadData(Form modalForm)
        {
            if (modalForm is EditStockModal editStockModal)
            {
                // Get the batch details using the batchId
                BatchModel batch = _batchRepository.GetBatchById(_batchId);
                _originalBatch = batch;  // Store original data for resetting

                // Populate the form fields with the batch data
                editStockModal.txtBoxBatchNumber.Text = batch.BatchNumber;
                editStockModal.txtCurrentQuantity.Text = batch.QuantityInStock.ToString();
                editStockModal.txtBoxIngredientName.Text = _batchRepository.GetIngredientNameById(batch.IngredientID);
                editStockModal.cmbAdjustmentType.SelectedIndex = 0;  // Default adjustment type
                editStockModal.txtReason.Clear();
            }
        }

        public void ResetData(Form modalForm)
        {
            if (modalForm is EditStockModal editStockModal)
            {
                // Reset the form fields to the original batch data
                editStockModal.txtBoxBatchNumber.Text = _originalBatch.BatchNumber;
                editStockModal.txtCurrentQuantity.Text = _originalBatch.QuantityInStock.ToString();
                editStockModal.numNewQuantity.Value = _originalBatch.QuantityInStock;
                editStockModal.cmbAdjustmentType.SelectedIndex = 0;
                editStockModal.txtReason.Clear();
            }
        }
    }
}
