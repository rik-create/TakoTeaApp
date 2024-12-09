using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.Text = "Combo Meal Details";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

            // Create labels
            var lblName = new MaterialLabel { Text = $"Name: {comboMealName}", Location = new Point(20, 80), AutoSize = true };
            var lblBasePrice = new MaterialLabel { Text = $"Base Price: {basePrice:C}", Location = new Point(20, 120), AutoSize = true };
            var lblDiscountPercent = new MaterialLabel { Text = $"Discount Percent: {discountPercent}%", Location = new Point(20, 160), AutoSize = true };
            var lblDiscountedPrice = new MaterialLabel { Text = $"Discounted Price: {discountedPrice:C}", Location = new Point(20, 200), AutoSize = true };
            var lblVariants = new MaterialLabel { Text = "Variants:", Location = new Point(20, 240), AutoSize = true };
            var lblCreatedAt = new MaterialLabel { Text = $"Created At: {createdAt}", Location = new Point(20, 380), AutoSize = true };
            var lblCreatedBy = new MaterialLabel { Text = $"Created By: {createdBy}", Location = new Point(20, 420), AutoSize = true };

            // Create a TextBox for displaying variants (multiline and read-only)
            var txtVariants = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Location = new Point(20, 280),
                Size = new Size(440, 80),
                Text = variantsText
            };

            // Add controls to the form
            this.Controls.AddRange(new Control[] {
                lblName, lblBasePrice, lblDiscountPercent, lblDiscountedPrice, lblVariants,
                txtVariants, lblCreatedAt, lblCreatedBy
            });
        }
    }
}
