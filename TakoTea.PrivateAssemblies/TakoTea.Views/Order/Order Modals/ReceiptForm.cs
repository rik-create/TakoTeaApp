using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Models;
using System.Data.Entity;


namespace TakoTea.Views.Order.Order_Modals
{
    public partial class ReceiptForm : Form
    {

        private int orderID;
        public ReceiptForm(int order)
        {
            InitializeComponent();
            orderID = order;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void lblReceiptContent_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptReportForm_Load(object sender, EventArgs e)
        {
  

        }

        private OrderModel GetOrderData(int orderId)
        {
            using (var context = new Entities())
            {
                return context.OrderModels // Use the correct DbSet name
                                    .Include(o => o.OrderItems)
                                    .FirstOrDefault(o => o.OrderId == orderId);
            }
                
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
