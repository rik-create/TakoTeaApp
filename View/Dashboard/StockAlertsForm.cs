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
