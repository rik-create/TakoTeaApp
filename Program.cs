using System;
using System.Windows.Forms;
using TakoTea.MainForm;
using TakoTea.View.Batch;
using TakoTea.View.Dashboard;
using TakoTea.View.Order;
using TakoTea.View.Product.Product_Modals;
using TakoTea.View.Stock;
using TakoTea.View.Stock.Stock_Modal;
using TakoTea.Views.Order.Order_Modals;

namespace TakoTea
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TakoTeaForm());
        }
    }
}
