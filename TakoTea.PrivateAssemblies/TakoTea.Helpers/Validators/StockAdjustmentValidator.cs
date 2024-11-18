using FluentValidation;
using System.Windows.Forms;
namespace TakoTea.Helpers.Validators
{
    public class StockAdjustmentValidator : AbstractValidator<StockAdjustment>
    {
        public StockAdjustmentValidator()
        {
            _ = RuleFor(x => x.AdjustmentType)
                .NotEmpty().WithMessage("Adjustment type is required.");
            _ = RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("Reason for adjustment is required.");
            _ = RuleFor(x => x.NewQuantity)
                .GreaterThan(0).WithMessage("New quantity must be greater than 0.");
        }
        public static bool ValidateStockAdjustment(decimal newQuantity, string adjustmentType, string reason)
        {
            // Create a StockAdjustment object with the provided values
            StockAdjustment stockAdjustment = new StockAdjustment
            {
                NewQuantity = newQuantity,
                AdjustmentType = adjustmentType,
                Reason = reason
            };
            // Create a validator for the StockAdjustment object
            StockAdjustmentValidator validator = new StockAdjustmentValidator();
            // Perform the validation
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(stockAdjustment);
            // If validation fails, display the error messages
            if (!validationResult.IsValid)
            {
                foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                {
                    _ = MessageBox.Show(failure.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false; // Return false if validation fails
            }
            return true; // Return true if validation is successful
        }
    }
    public class StockAdjustment
    {
        public decimal NewQuantity { get; set; }
        public string AdjustmentType { get; set; }
        public string Reason { get; set; }
    }
}
