using MaterialSkin.Controls;
using Org.BouncyCastle.Cmp;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Controls;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Services;
using TakoTea.Views.Order;
using TakoTea.Views.Order.Order_Modals;
namespace TakoTea.View.Orders
{

    //TODO: ADD CHANGE
    public partial class MenuOrderForm : MaterialForm
    {
        MenuOrderFormService _service;
        ProductsService productsService;
        private Entities context;
        public MenuOrderForm()
        {
            InitializeComponent();
            _service = new MenuOrderFormService();
            context = new Entities();
            lblTotalItemInOrderList.Text = "0";

            OrderEntryModal orderEntryModal = new OrderEntryModal(dataGridViewOrderList);
            orderEntryModal.Show();
            orderEntryModal.Close();
            productsService = new ProductsService(context);

            dgvDraftOrders.CellClick += dgvDraftOrders_CellClick; // Register the event handler

            dateTimePickerOrderDate.Value = DateTime.Now;
            dateTimePickerOrderDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerOrderDate.CustomFormat = "MMMM ,d , yyyy";
            // ... rest of the code ...
            this.Load += MenuOrderForm_Load; // Register the Load event handler
            txtBoxSearchVariant.TextChanged += txtBoxSearchVariant_TextChanged;


            dataGridViewOrderList.CellValueChanged += dataGridViewOrderList_CellValueChanged;
            dataGridViewOrderList.CellDoubleClick += dataGridViewOrderList_CellDoubleClick; // Register the event handler

            dataGridViewOrderList.RowsAdded += dataGridViewOrderList_RowsAdded;

            // Add a ContextMenuStrip to your form
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            contextMenuStrip.Items.Add(deleteMenuItem);

            // Attach the ContextMenuStrip to the DataGridView
            dgvDraftOrders.ContextMenuStrip = contextMenuStrip;
            lblOrderId.Text = _service.GenerateNewOrderId().ToString();
            // Handle the delete menu item click
            deleteMenuItem.Click += deleteMenuItem_Click;
            numericUpDownPaymenAmount.Maximum = 100000000;

            LoadPaymentMethods();
        }

        // Assuming you have a DataGridView named dgvDraftOrders and a Button named btnLoadDraft

        private void PopulateDraftOrdersDataGridView()
        {
            var draftOrders = context.DraftOrders.Select(o => new
            {
                o.DraftOrderId,
                o.CreatedDate,
                o.CustomerName,
                o.TotalAmount
            }).ToList();

            // Check if the column already exists before adding it
            if (!dgvDraftOrders.Columns.Contains("LoadButtonColumn"))
            {
                dgvDraftOrders.DataSource = draftOrders;
                DataGridViewButtonColumn loadButtonColumn = new DataGridViewButtonColumn();
                loadButtonColumn.HeaderText = "";
                loadButtonColumn.Name = "LoadButtonColumn";
                loadButtonColumn.Text = "Load";
                loadButtonColumn.UseColumnTextForButtonValue = true;
                dgvDraftOrders.Columns.Add(loadButtonColumn);
            }
            dgvDraftOrders.DataSource = draftOrders;


        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Confirmation before deleting
                if (MessageBox.Show("Are you sure you want to delete the selected draft orders?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvDraftOrders.SelectedRows)
                    {
                        int draftOrderId = Convert.ToInt32(row.Cells["DraftOrderId"].Value);

                        // Delete from the database
                        var draftOrder = context.DraftOrders.Find(draftOrderId);
                        if (draftOrder != null)
                        {
                            context.DraftOrders.Remove(draftOrder);
                            context.SaveChanges();
                        }
                    }

                    // Refresh the DataGridView
                    PopulateDraftOrdersDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the draft order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDraftOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked cell is in the LoadButtonColumn
                if (e.ColumnIndex == dgvDraftOrders.Columns["LoadButtonColumn"].Index && e.RowIndex >= 0)
                {
                    // Confirmation
                    if (MessageBox.Show("Are you sure you want to load this draft order?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int draftOrderId = Convert.ToInt32(dgvDraftOrders.Rows[e.RowIndex].Cells["DraftOrderId"].Value);

                        _service.LoadDraftOrder(draftOrderId, dataGridViewOrderList, lblTotalInOrderList);

                        // Delete the draft from the database
                        var draftOrder = context.DraftOrders.Find(draftOrderId);
                        if (draftOrder != null)
                        {
                            context.DraftOrders.Remove(draftOrder);
                            context.SaveChanges();
                        }
                    }
                }

                PopulateDraftOrdersDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the draft order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = lblCustomerlbl.Text; // Assuming you have a TextBox for customer name
                string paymentMethod = cmbPaymentMethod.SelectedItem.ToString(); // Assuming you have a ComboBox for payment method
                string totalAmount = lblTotalInOrderList.Text.Substring(1);

                _service.SaveDraftOrder(dataGridViewOrderList, totalAmount, customerName, paymentMethod);
                MessageBox.Show("Draft order saved successfully.");
                dataGridViewOrderList.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the draft order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnViewDraftOrders_Click(object sender, EventArgs e)
        {
            if (btnViewDraftOrders.Text == "View Draft Orders")
            {
                // Show draft orders
                btnViewDraftOrders.Text = "Close Draft Orders";
                flPanelProductVariantsMenu.Hide();
                dgvDraftOrders.Show();
                PopulateDraftOrdersDataGridView();

                // Load draft orders into dgvDraftOrders (replace with your actual logic)
                /*                LoadDraftOrders();
                */
              }
            else
            {
                // Close draft orders view
                btnViewDraftOrders.Text = "View Draft Orders";
                flPanelProductVariantsMenu.Show();
                dgvDraftOrders.Hide();
            }
        }


        // In your MenuOrderForm class

        private void dataGridViewOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked (not the header or new row)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewOrderList.Rows[e.RowIndex].IsNewRow)
            {
                // Get the data from the selected row
                string productName = dataGridViewOrderList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string size = dataGridViewOrderList.Rows[e.RowIndex].Cells[1].Value.ToString();
                string addOns = dataGridViewOrderList.Rows[e.RowIndex].Cells[2].Value.ToString();
                int quantity = Convert.ToInt32(dataGridViewOrderList.Rows[e.RowIndex].Cells[3].Value);
                decimal totalPrice = Convert.ToDecimal(dataGridViewOrderList.Rows[e.RowIndex].Cells[4].Value);

                // Determine if it's a combo meal or product variant
                bool isComboMeal = string.IsNullOrEmpty(size);

                // Create and show the OrderEntryModal
                using (OrderEntryModal orderEntryModal = new OrderEntryModal(dataGridViewOrderList))
                {
                    if (isComboMeal)
                    {
                        // If it's a combo meal, find and set the combo meal data
                        var comboMeal = context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == productName);
                        if (comboMeal != null)
                        {
                            orderEntryModal.SetComboMealData(comboMeal);
                        }
                    }
                    else
                    {
                        // If it's a product variant, find and set the product variant data
                        var productVariant = context.ProductVariants.FirstOrDefault(pv => pv.VariantName == productName && pv.Size == size);
                        if (productVariant != null)
                        {
                            orderEntryModal.SetProductData(productVariant);

                            // Set the selected add-ons in the modal
                            for (int i = 0; i < orderEntryModal.chckListBoxAddOns.Items.Count; i++)
                            {
                                string addOnItemName = orderEntryModal.chckListBoxAddOns.Items[i].ToString().Split(new[] { " - " }, StringSplitOptions.None)[0];
                                if (addOns.Contains(addOnItemName))
                                {
                                    orderEntryModal.chckListBoxAddOns.SetItemChecked(i, true);
                                }
                            }
                        }
                    }

                    // Set the quantity in the modal
                    orderEntryModal.numericUpDownQuantity.Value = quantity;

                    // Show the modal
                    orderEntryModal.ShowDialog();
                    if (orderEntryModal.AddToDgViewOrderListClicked)
                    {
                        // Remove the original row from the DataGridView

                        // Update the total price
                        UpdateTotalInOrderList();
                    }
                }


            }
        }

        // In your form's constructor or InitializeComponent method:
        // ... other initialization code ...


// ... rest of the code ...

        private void dataGridViewOrderList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the changed cell is in the price column (assuming it's column index 4)
            if (e.ColumnIndex == 4)
            {
                UpdateTotalInOrderList();
                UpdateTotalItemsInOrderList();
                UpdateChange();
            }

            // Check if the changed cell is in the quantity column (assuming it's column index 3)
            if (e.ColumnIndex == 3)
            {
                var quantityCell = dataGridViewOrderList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (quantityCell.Value != null && int.TryParse(quantityCell.Value.ToString(), out int quantity))
                {
                    if (quantity == 0)
                    {
                        dataGridViewOrderList.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }



        private void MenuOrderForm_Load(object sender, EventArgs e)
        {

            _service.LoadMenuVariants(flPanelProductVariantsMenu, dataGridViewOrderList);
            // In your parent form's constructor or InitializeComponent method:

            // ... other initialization code ...
            dataGridViewOrderList.Rows.Clear();
            btnClearOrderList.Click += buttonClearOrderList_Click;
            _service.PopulateCategories(flowLayoutPanelCategpries, dataGridViewOrderList, flPanelProductVariantsMenu);
            UpdateTotalInOrderList();

            lblOrderId.Text = _service.GenerateNewOrderId().ToString();

        }

        private void dataGridViewOrderList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotalInOrderList();
            UpdateTotalItemsInOrderList();
            UpdateChange();
        }

        // In your parent form class (where the parentDataGridView is located)

        private void buttonClearOrderList_Click(object sender, EventArgs e)
        {
            dataGridViewOrderList.Rows.Clear();
            UpdateTotalInOrderList();
            UpdateTotalItemsInOrderList();
            UpdateChange();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Assuming you have an instance of your productsService class called `_service`

            // Get the ProductVariantIngredientIDs for a specific ProductVariantID (e.g., 123)
            int productVariantId = 12;
            var productVariantIngredientIds = productsService.GetProductVariantIngredientIds(productVariantId);

            // Display the IDs in a message box
            MessageBox.Show("ProductVariantIngredientIDs: " + string.Join(", ", productVariantIngredientIds));

            // Get the IngredientID and QuantityPerVariant for a specific ProductVariantIngredientID (e.g., 456)
            int productVariantIngredientId = 1;


            var (ingredientId, quantityPerVariant) = productsService.GetIngredientAndQuantity(productVariantIngredientId);



            MessageBox.Show($"Ingredient ID: {ingredientId}, Quantity per Variant: {quantityPerVariant}");
        }


        private void materialButton1_Click(object sender, EventArgs e)
        {
            

        }

        private void UpdateChange()
        {
            if (decimal.TryParse(lblTotalInOrderList.Text.Replace("₱", ""), out decimal totalDue) &&
                decimal.TryParse(numericUpDownPaymenAmount.Value.ToString(), out decimal amountPaid))
            {
                decimal change = amountPaid - totalDue;
                lblChange.Text = $"₱{change:F2}";
            }
            else
            {
                // Handle parsing errors if necessary
                lblChange.Text = "Invalid input";
            }
        }
        private void UpdateTotalItemsInOrderList()
        {
            int totalItems = 0;

            foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
            {
                if (!row.IsNewRow && row.Cells["ColumnQty"].Value != null) // Assuming "Quantity" is the column name
                {
                    totalItems += Convert.ToInt32(row.Cells["ColumnQty"].Value);
                }
            }

            lblTotalItemInOrderList.Text = totalItems.ToString();
        }
        public void UpdateTotalInOrderList()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewOrderList.Rows) // Use dataGridViewOrderList here
            {
                if (row.Cells[4].Value != null && decimal.TryParse(row.Cells[4].Value.ToString(), out decimal rowTotal))
                {
                    total += rowTotal;
                }
            }
            lblTotalInOrderList.Text = $"₱{total:F2}";
        }

        // Assuming you have these controls on your Form:
        // - cmbPaymentMethod (ComboBox)

        private void LoadPaymentMethods()
        {
            // Clear existing items in the ComboBox
            cmbPaymentMethod.Items.Clear();

            // Get the payment methods (assuming you have a method to retrieve them)
            var paymentMethods = PaymentMethodService.GetAllPaymentMethods(); // Or however you get your payment methods

            // Add the payment methods to the ComboBox
            cmbPaymentMethod.Items.AddRange(paymentMethods.ToArray());

            // Optionally, set a default selected item
            if (cmbPaymentMethod.Items.Count > 0)
            {
                cmbPaymentMethod.SelectedIndex = 0; // Select the first item by default
            }
        }
        private void txtBoxSearchVariant_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtBoxSearchVariant.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                // If the search box is empty, load all menu variants
                _service.LoadMenuVariants(flPanelProductVariantsMenu, dataGridViewOrderList);
            }
            else
            {
                // Otherwise, filter and display unique variants based on the search text
                _service.FilterAndDisplayUniqueVariants(searchText, flPanelProductVariantsMenu, dataGridViewOrderList);
            }
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flPanelProductVariantsMenu_Paint(object sender, PaintEventArgs e)
        {

        }
   



  private void btnConfirmOrder_Click(object sender, EventArgs e)
        {


           
            try
            {

                if (IsChangeEnough())
                {
                    // Call the ConfirmOrder method in the productsService class
                    _service.ConfirmOrder(
                        dataGridViewOrderList,
                        lblTotalInOrderList,
                        lblOrderId,
                        cmbPaymentMethod,
                        cmbPaymentStatus,
                        cmbOrderStatus,
                        dateTimePickerOrderDate,
                        txtCustomer.Text,
                        numericUpDownPaymenAmount.Value
                    );

                    _service.GenerateReceipt((int.Parse(lblOrderId.Text)));

                    lblOrderId.Text = _service.GenerateNewOrderId().ToString();
                }
                else
                {
                    MessageBox.Show("The payment amount is not enough to cover the total amount due.", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
          
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while confirming the order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGoToOrderQueue_Click(object sender, EventArgs e)
        {
            OrdersQueueForm ordersQueueForm = new OrdersQueueForm(context);
            ordersQueueForm.Show();

        }

        private void buttonNow_Click(object sender, EventArgs e)
        {
            dateTimePickerOrderDate.Value = DateTime.Now;
            dateTimePickerOrderDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerOrderDate.CustomFormat = "MMMM ,d , yyyy";

        }

        private void numericUpDownPaymenAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdateChange();
        }
        private bool IsChangeEnough()
        {
            if (decimal.TryParse(lblChange.Text.Replace("₱", ""), out decimal change) &&
                decimal.TryParse(lblTotalInOrderList.Text.Replace("₱", ""), out decimal totalInOrderList))
            {
                return change >= totalInOrderList;
            }
            return false;
        }
    }
}
