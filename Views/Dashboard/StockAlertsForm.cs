using MaterialSkin.Controls;
using System;
using TakoTea.Dashboard.Dashboard_Modals;

namespace TakoTea.Dashboard
{

    public partial class StockAlertsForm : MaterialForm
    {
        public StockAlertsForm()
        {
            InitializeComponent();
            Configurations.ThemeConfigurator.ApplyDarkTheme(this);
        }

        private void materialButtonEditThreshold_Click(object sender, EventArgs e)
        {
            EditLowStockThresholdModal editLowStockThresholdModal = new EditLowStockThresholdModal();
            editLowStockThresholdModal.ShowDialog();
        }
    }
}
