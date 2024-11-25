using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Controls;
using TakoTea.Models;
using TakoTea.Views.Order;
using TakoTea.Views.Order.Order_Modals;
namespace TakoTea.View.Orders
{
    public partial class MenuOrderForm : MaterialForm
    {
        MenuOrderFormService _service;
        public MenuOrderForm()
        {
            InitializeComponent();
            _service = new MenuOrderFormService();


            OrderEntryModal orderEntryModal = new OrderEntryModal(dataGridViewOrderList);
            orderEntryModal.Show();
            orderEntryModal.Close();


            // ... rest of the code ...
            this.Load += MenuOrderForm_Load; // Register the Load event handler
            txtBoxSearchVariant.TextChanged += txtBoxSearchVariant_TextChanged;
            btnSearch.Click += btnSearch_Click;


            dataGridViewOrderList.CellValueChanged += dataGridViewOrderList_CellValueChanged;

            dataGridViewOrderList.RowsAdded += dataGridViewOrderList_RowsAdded;

        }

        private void dataGridViewOrderList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the changed cell is in the price column (assuming it's column index 4)
            if (e.ColumnIndex == 4)
            {
                UpdateTotalInOrderList();
            }

        }



        private void MenuOrderForm_Load(object sender, EventArgs e)
        {

            _service.LoadMenuVariants(flPanelProductVariantsMenu, dataGridViewOrderList);
            // In your parent form's constructor or InitializeComponent method:

            // ... other initialization code ...

            btnClearOrderList.Click += buttonClearOrderList_Click;
            _service.PopulateCategories(flowLayoutPanelCategpries, dataGridViewOrderList, flPanelProductVariantsMenu);
            UpdateTotalInOrderList();

            lblOrderId.Text = _service.GenerateNewOrderId().ToString();

        }

        private void dataGridViewOrderList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotalInOrderList();
        }

        // In your parent form class (where the parentDataGridView is located)

        private void buttonClearOrderList_Click(object sender, EventArgs e)
        {
            dataGridViewOrderList.Rows.Clear();
            UpdateTotalInOrderList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MenuOrderForm_Load(sender, e);
        }


        private void materialButton1_Click(object sender, EventArgs e)
        {
            

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


            // Call the ConfirmOrder method in the service class
            _service.ConfirmOrder(
                dataGridViewOrderList,
                lblTotalInOrderList,
                lblOrderId,
                cmbPaymentMethod,
                cmbPaymentStatus
            );

            // Optionally, perform additional actions after confirming the order
            // For example:
            // - Clear the order list: dataGridViewOrderList.Rows.Clear();
            // - Generate a receipt: _service.GenerateReceipt(orderId);
            // - Reset the form
            // - etc.
        }
    }
}
