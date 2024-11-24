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
namespace TakoTea.View.Order
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

            _service.LoadMenuVariants(flPanelProductVariantsMenu, dataGridViewOrderList);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderEntryModal orderEntryModal = new OrderEntryModal(dataGridViewOrderList);
            _ = orderEntryModal.ShowDialog();
           

        }

   

    }
}
