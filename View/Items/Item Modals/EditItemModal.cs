using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.Items.Item_Modals
{
    public partial class EditItemModal : MaterialForm
    {
        public EditItemModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
        }
    }
}
