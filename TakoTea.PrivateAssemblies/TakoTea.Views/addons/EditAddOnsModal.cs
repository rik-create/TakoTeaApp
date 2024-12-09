using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;

namespace TakoTea.Views.addons
{
    public partial class EditAddOnsModal : MaterialForm
    {
        private readonly int _addOnId;
        private readonly AddOnRepository _addOnRepository;
        private readonly AddOnService _addOnService;

        private MaterialTextBox txtAddOnName;
        private MaterialTextBox txtAdditionalPrice;
        private MaterialTextBox txtUseForProductID;
        private MaterialTextBox txtQuantityUsedPerProduct;

        public EditAddOnsModal(int addOnId)
        {
            _addOnId = addOnId;
            _addOnRepository = new AddOnRepository();
            _addOnService = new AddOnService();

            InitializeComponents();
            LoadData();
        }

        private void InitializeComponents()
        {
            // Set form properties
            this.Text = "Edit Add-on";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create labels and text boxes
            var lblAddOnName = new MaterialLabel { Text = "Add-on Name:", Location = new Point(20, 80), AutoSize = true };
            txtAddOnName = new MaterialTextBox { Location = new Point(180, 75), Width = 200 }; // Moved to the right

            var lblAdditionalPrice = new MaterialLabel { Text = "Additional Price:", Location = new Point(20, 130), AutoSize = true };
            txtAdditionalPrice = new MaterialTextBox { Location = new Point(180, 125), Width = 200 }; // Ensure initialization
            txtAdditionalPrice.KeyPress += (s, e) =>
            {
                // Allow only numeric input, decimal point, and control characters
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                var textBox = s as TextBox;
                if (textBox != null && (e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            };

            var lblUseForProductID = new MaterialLabel { Text = "Use For Product ID:", Location = new Point(20, 180), AutoSize = true };
            txtUseForProductID = new MaterialTextBox { Location = new Point(180, 175), Width = 200 }; // Moved to the right
            txtUseForProductID.ReadOnly = true;

            var lblQuantityUsedPerProduct = new MaterialLabel { Text = "Quantity Used:", Location = new Point(20, 230), AutoSize = true };
            txtQuantityUsedPerProduct = new MaterialTextBox { Location = new Point(180, 225), Width = 200 }; // Moved to the right

            // Create buttons with adjusted positions and spacing
            var btnConfirm = new MaterialButton { Text = "Confirm", Location = new Point(80, 280), Width = 100 }; // More spacing
            var btnCancel = new MaterialButton { Text = "Cancel", Location = new Point(200, 280), Width = 100 }; // More spacing

            // Add event handlers for buttons
            btnConfirm.Click += btnConfirm_Click;
            btnCancel.Click += btnCancel_Click;

            // Add controls to the form
            this.Controls.AddRange(new Control[] {
                    lblAddOnName, txtAddOnName, lblAdditionalPrice, txtAdditionalPrice,
                    lblUseForProductID, txtUseForProductID, lblQuantityUsedPerProduct, txtQuantityUsedPerProduct,
                    btnConfirm, btnCancel
                });
        }

        private void LoadData()
        {
            try
            {
                var addOn = _addOnRepository.GetAddOnById(_addOnId);
                if (addOn != null)
                {
                    txtAddOnName.Text = addOn.AddOnName;
                    txtAdditionalPrice.Text = addOn.AdditionalPrice.ToString();
                    txtUseForProductID.Text = addOn.UseForProductID.ToString();
                    txtQuantityUsedPerProduct.Text = addOn.QuantityUsedPerProduct.ToString();
                }
                else
                {
                    MessageBox.Show("Add-on not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading add-on: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtAdditionalPrice.Text, out decimal additionalPrice) || additionalPrice <= 0)
                {
                    DialogHelper.ShowError("Please enter a valid additional price.");
                    return;
                }

                int? useForProductId = null;
                if (!string.IsNullOrEmpty(txtUseForProductID.Text))
                {
                    if (int.TryParse(txtUseForProductID.Text, out int parsedProductId))
                    {
                        useForProductId = parsedProductId;
                    }
                    else
                    {
                        DialogHelper.ShowError("Please enter a valid integer for 'Use For Product ID'.");
                        return;
                    }
                }

                decimal? quantityUsedPerProduct = null;
                if (!string.IsNullOrEmpty(txtQuantityUsedPerProduct.Text))
                {
                    if (decimal.TryParse(txtQuantityUsedPerProduct.Text, out decimal parsedQuantity))
                    {
                        quantityUsedPerProduct = parsedQuantity;
                    }
                    else
                    {
                        DialogHelper.ShowError("Please enter a valid decimal for 'Quantity Used Per Product'.");
                        return;
                    }
                }

                var originalAddOn = _addOnRepository.GetAddOnById(_addOnId);

                var updatedAddOn = new AddOn
                {
                    Id = _addOnId,
                    AddOnName = txtAddOnName.Text,
                    AdditionalPrice = additionalPrice,
                    UseForProductID = useForProductId,
                    QuantityUsedPerProduct = quantityUsedPerProduct
                };

                _addOnService.UpdateAddOn(updatedAddOn);

                LogAddOnChanges(originalAddOn, updatedAddOn);

                DialogHelper.ShowSuccess("Add-on updated successfully!");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to update add-on. Error: {ex.Message}");
            }
        }

        private void LogAddOnChanges(AddOn originalAddOn, AddOn updatedAddOn)
        {
            if (originalAddOn == null || updatedAddOn == null)
            {
                return;
            }

            if (originalAddOn.AddOnName != updatedAddOn.AddOnName)
            {
                LoggingHelper.LogChange(
                    "AddOns",
                    _addOnId,
                    "AddOnName changed",
                    originalAddOn.AddOnName,
                    updatedAddOn.AddOnName,
                    "Updated",
                    $"AddOnName changed from '{originalAddOn.AddOnName}' to '{updatedAddOn.AddOnName}'",
                    "Change in AddOnName"
                );
            }

            if (originalAddOn.AdditionalPrice != updatedAddOn.AdditionalPrice)
            {
                LoggingHelper.LogChange(
                    "AddOns",
                    _addOnId,
                    "AdditionalPrice changed",
                    originalAddOn.AdditionalPrice.ToString(),
                    updatedAddOn.AdditionalPrice.ToString(),
                    "Updated",
                    $"AdditionalPrice changed from '{originalAddOn.AdditionalPrice}' to '{updatedAddOn.AdditionalPrice}'",
                    "Change in AdditionalPrice"
                );
            }

            if (originalAddOn.UseForProductID != updatedAddOn.UseForProductID)
            {
                LoggingHelper.LogChange(
                    "AddOns",
                    _addOnId,
                    "UseForProductID changed",
                    originalAddOn.UseForProductID.ToString(),
                    updatedAddOn.UseForProductID.ToString(),
                    "Updated",
                    $"UseForProductID changed from '{originalAddOn.UseForProductID}' to '{updatedAddOn.UseForProductID}'",
                    "Change in UseForProductID"
                );
            }

            if (originalAddOn.QuantityUsedPerProduct != updatedAddOn.QuantityUsedPerProduct)
            {
                LoggingHelper.LogChange(
                    "AddOns",
                    _addOnId,
                    "QuantityUsedPerProduct changed",
                    originalAddOn.QuantityUsedPerProduct.ToString(),
                    updatedAddOn.QuantityUsedPerProduct.ToString(),
                    "Updated",
                    $"QuantityUsedPerProduct changed from '{originalAddOn.QuantityUsedPerProduct}' to '{updatedAddOn.QuantityUsedPerProduct}'",
                    "Change in QuantityUsedPerProduct"
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}