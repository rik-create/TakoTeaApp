using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using TakoTea.Configurations;

namespace TakoTea.Views.ComboMealForms
{
    public partial class ComboMealDetailsForm : MaterialForm
    {
        public ComboMealDetailsForm(string comboMealName, decimal basePrice, decimal discountPercent,
                                      decimal discountedPrice, string variantsText, DateTime createdAt, string createdBy)
        {
            // Set form properties
            Text = "Combo Meal Details";
            Size = new Size(500, 500);
            StartPosition = FormStartPosition.CenterParent;
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

            // Create labels
            MaterialLabel lblName = new MaterialLabel { Text = $"Name: {comboMealName}", Location = new Point(20, 80), AutoSize = true };
            MaterialLabel lblBasePrice = new MaterialLabel { Text = $"Base Price: {basePrice:C}", Location = new Point(20, 120), AutoSize = true };
            MaterialLabel lblDiscountPercent = new MaterialLabel { Text = $"Discount Percent: {discountPercent}%", Location = new Point(20, 160), AutoSize = true };
            MaterialLabel lblDiscountedPrice = new MaterialLabel { Text = $"Discounted Price: {discountedPrice:C}", Location = new Point(20, 200), AutoSize = true };
            MaterialLabel lblVariants = new MaterialLabel { Text = "Variants:", Location = new Point(20, 240), AutoSize = true };
            MaterialLabel lblCreatedAt = new MaterialLabel { Text = $"Created At: {createdAt}", Location = new Point(20, 380), AutoSize = true };
            MaterialLabel lblCreatedBy = new MaterialLabel { Text = $"Created By: {createdBy}", Location = new Point(20, 420), AutoSize = true };

            // Create a TextBox for displaying variants (multiline and read-only)
            TextBox txtVariants = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Location = new Point(20, 280),
                Size = new Size(440, 80),
                Text = variantsText
            };

            // Add controls to the form
            Controls.AddRange(new Control[] {
                lblName, lblBasePrice, lblDiscountPercent, lblDiscountedPrice, lblVariants,
                txtVariants, lblCreatedAt, lblCreatedBy
            });
        }
    }
}
