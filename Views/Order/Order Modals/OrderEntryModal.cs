using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.Views.Order.Order_Modals
{
    public partial class OrderEntryModal : MaterialForm
    {
        public OrderEntryModal()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);

        }
    }
}
