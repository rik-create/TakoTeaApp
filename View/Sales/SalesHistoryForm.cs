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
using TakoTea.View.Sales.Sales_Modals;

namespace TakoTea.View.Sales
{
    public partial class SalesHistoryForm : MaterialForm

    {
        public SalesHistoryForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void floatingActionButtonSalesEntry_Click(object sender, EventArgs e)
        {
            AddSalesEntryModal addSalesEntryModal = new AddSalesEntryModal();
            addSalesEntryModal.ShowDialog();
        }

        private void pictureBoxExportExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
