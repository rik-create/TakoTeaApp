using System;
using System.Windows.Forms;
using TakoTea.Models;
using TakoTea.View.Batches;
using TakoTea.View.Orders;
using TakoTea.Views.mainform;
using TakoTea.Views.MainForm;
namespace TakoTea
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OrdersQueueForm(new Entities()));
            /*      // Register the dependency in the DI container
                  services.AddSingleton<IFormFactory, TakoTea.Views.FormFactory>();
                  services.AddTransient<FormLoader>();
                  // Resolve the loader wherever needed
                  var loader = serviceProvider.GetRequiredService<FormLoader>();
                  var form = loader.LoadForm("Dashboard");*/
        }
    }
}
