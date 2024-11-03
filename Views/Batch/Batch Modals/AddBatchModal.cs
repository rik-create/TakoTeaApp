using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;

namespace TakoTea.View.Batch.Batch_Modals
{
    public partial class AddBatchModal : MaterialForm
    {
        public AddBatchModal()
        {
            InitializeComponent();


            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);






        }



        private void materialButtonSearchItems_Click_1(object sender, EventArgs e)
        {

            this.Hide();

            SearchItemsModal searchItemsModal = new SearchItemsModal();
            searchItemsModal.ShowDialog();


            this.Show();
        }
    }
}
