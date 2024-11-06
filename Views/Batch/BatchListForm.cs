using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.MainForm;
using TakoTea.View.Batch.Batch_Modals;
using TakoTea.Views.Batch.Batch_Modals;

namespace TakoTea.View.Batch
{
    public partial class BatchListForm : MaterialForm
    {
        public BatchListForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }


        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

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
            panelFilteringComponents.Visible = true;
            panelFilteringComponents.Enabled = true;
        }

        private void floatingActionButtonAddBatch_Click_1(object sender, EventArgs e)
        {
            NewBatchForm newBatchForm = new NewBatchForm();
            newBatchForm.ShowDialog();
        }

        private void buttonEditBatch_Click(object sender, EventArgs e)
        {
            EditBatchForm edit = new EditBatchForm("10023");
            edit.ShowDialog();
        }
    }
}
