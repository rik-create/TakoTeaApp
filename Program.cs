using System;
using System.Windows.Forms;
using TakoTea.View.Batch;
using TakoTea.View.Stock;

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
            Application.Run(new BatchListForm());
        }
    }
}
