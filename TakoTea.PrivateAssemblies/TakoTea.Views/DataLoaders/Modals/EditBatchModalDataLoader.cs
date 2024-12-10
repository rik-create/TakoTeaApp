using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Views.Batches;

namespace TakoTea.Views.DataLoaders.Modals
{
    public class EditBatchModalDataLoader : IModalDataLoader
    {
        private readonly int _batchId;
        private readonly BatchRepository _batchRepository;

        private BatchModel _originalBatch;

        public EditBatchModalDataLoader(int batchId)
        {
            _batchId = batchId;
            _batchRepository = new BatchRepository(new DataAccessObject());
        }

        public void LoadData(Form modalForm)
        {
            if (modalForm is AddBatchModal editBatchModal)
            {
                BatchModel batch = _batchRepository.GetBatchById(_batchId);
                _originalBatch = batch; // Store original data for resetting

                // Populate form fields
                editBatchModal.txtBoxBatchNumber.Text = batch.BatchNumber;
                editBatchModal.numericUpDownQuantity.Value = batch.QuantityInStock;
                editBatchModal.numericUpDownCost.Value = batch.BatchCost;
                editBatchModal.dateTimePickerExpiration.Value = batch.ExpirationDate;

                // Load IngredientModel Functions and Allergens

            }
        }

        public void ResetData(Form modalForm)
        {
            if (modalForm is AddBatchModal editBatchModal)
            {
                // Reset form fields to the original batch data
                editBatchModal.txtBoxBatchNumber.Text = _originalBatch.BatchNumber;
                editBatchModal.numericUpDownQuantity.Value = _originalBatch.QuantityInStock;
                editBatchModal.numericUpDownCost.Value = _originalBatch.BatchCost;
                editBatchModal.dateTimePickerExpiration.Value = _originalBatch.ExpirationDate;


            }
        }
    }


}
