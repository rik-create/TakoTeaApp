using System;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;

namespace TakoTea.Services
{
    public class BatchService : IBatchService
    {
        public void AddBatch(Batch batch)
        {
            using (Entities context = new Entities())
            {
                _ = context.Batches.Add(batch);
                _ = context.SaveChanges();
                LoggingHelper.LogChange(
                    "Batch",                // Table name
                    batch.BatchID,            // Record ID (assuming BatchID is auto-generated)
                    "New Batch",              // Column name (or any descriptive text)
                    null,                     // Old value (null for new batch)
                    batch.ToString(),         // New value (you might need to override ToString() in your Batch class for a more descriptive log)
                    "Added",                  // Action
                    $"Batch '{batch.BatchNumber}' added for ingredient '{batch.IngredientID}'", "" // Description
                );
            }
        }

        public void Update(Batch batch)
        {
            try
            {
                using (Entities context = new Entities())
                {
                    Batch existingBatch = context.Batches.Find(batch.BatchID);

                    if (existingBatch != null)
                    {

                        existingBatch.BatchNumber = batch.BatchNumber;
                        existingBatch.IngredientID = batch.IngredientID;
                        existingBatch.UpdatedAt = batch.UpdatedAt;
                        existingBatch.StockLevel = batch.StockLevel;
                        existingBatch.ExpirationDate = batch.ExpirationDate;
                        existingBatch.BatchCost = batch.BatchCost;

                        _ = context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Batch not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update batch in the database.", ex);
            }
        }

        public void DeleteBatch(int batchId)
        {
            try
            {
                using (Entities context = new Entities())
                {
                    Batch batch = context.Batches.Find(batchId);

                    string deletionDescription = DialogHelper.ShowInputDialog(
                                                formTitle: "Enter Deletion Description",
                                                labelText: "Deletion Description:",
                                                validationMessage: "Description cannot be empty.",
                                                validateInput: input => !string.IsNullOrWhiteSpace(input)
                                            ); if (batch != null)
                    {
                        _ = context.Batches.Remove(batch);
                        _ = context.SaveChanges();
                        LoggingHelper.LogChange(
                            "Batch",                // Table name
                            batchId,                  // Record ID
                            "Deleted Batch",          // Column name (or any descriptive text)
                            batch.ToString(),         // Old value
                            null,                     // New value
                            "Deleted",                // Action
                            $"Batch '{batch.BatchNumber}' deleted for ingredient '{batch.IngredientID}'", deletionDescription// Description
                        );
                    }
                    else
                    {
                        throw new Exception("Batch not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete batch from the database.", ex);
            }
        }
    }
}
