using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;

namespace TakoTea.View.Items
{
    public partial class IngredientListForm : MaterialForm
    {
        public IngredientListForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btnShowFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnHideFilters_Click(object sender, EventArgs e)
        {
            panelFilteringComponents.Visible = false;
            panelFilteringComponents.Enabled = false;
            btnHideFilters.Enabled = false;
            pBoxShowFilter.Enabled = true;
        }

        private void pBoxShowFilter_Click(object sender, EventArgs e)
        {
            panelFilteringComponents.Visible = true;
            panelFilteringComponents.Enabled = true;
            btnHideFilters.Enabled = true;
            pBoxShowFilter.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
