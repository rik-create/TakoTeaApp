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
using TakoTea.Views.Order.Order_Modals;

namespace TakoTea.View.Order
{
    public partial class MenuOrderForm : MaterialForm   
    {
        public MenuOrderForm()
        {
            InitializeComponent();




         



        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void categoryButtonOrdering8_Load(object sender, EventArgs e)
        {

        }

        private void categoryButtonOrdering7_Load(object sender, EventArgs e)
        {

        }

        private void categoryButtonOrdering6_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelCategpries_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productWidget1_Load(object sender, EventArgs e)
        {

        }

        private void productWidget1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OrderEntryModal orderEntryModal = new OrderEntryModal();
            orderEntryModal.ShowDialog();
        }
    }
}
