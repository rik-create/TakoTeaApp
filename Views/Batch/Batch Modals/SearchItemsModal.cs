using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.View.Batch.Batch_Modals
{
    public partial class SearchItemsModal : MaterialForm
    {
        public SearchItemsModal()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);

        }
    }
}
