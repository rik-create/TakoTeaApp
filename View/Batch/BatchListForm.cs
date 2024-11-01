using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.MainForm;
using TakoTea.View.Batch.Batch_Modals;

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

        private void floatingActionButtonAddBatch_Click(object sender, EventArgs e)
        {


            TakoTeaForm.Instance.Hide();

            AddBatchModal addBatchModal = new AddBatchModal();
            addBatchModal.ShowDialog();


            TakoTeaForm.Instance.Show();
            ThemeConfigurator.ApplyDarkTheme(this);



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
    }
}
