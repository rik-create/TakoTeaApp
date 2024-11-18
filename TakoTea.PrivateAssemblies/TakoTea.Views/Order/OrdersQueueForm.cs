using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;
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
