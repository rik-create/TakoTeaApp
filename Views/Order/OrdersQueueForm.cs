using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.MainForm;
using TakoTea.View.Batch.Batch_Modals;

namespace TakoTea.View.Order
{
    public partial class OrdersQueueForm : MaterialForm
    {
        public OrdersQueueForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }
 

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

  
    }
}
