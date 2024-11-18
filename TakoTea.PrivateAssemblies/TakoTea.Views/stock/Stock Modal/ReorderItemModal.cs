using MaterialSkin.Controls;
using TakoTea.Configurations;
namespace TakoTea.View.Stock.Stock_Modal
{
    public partial class ReorderItemModal : MaterialForm
    {
        public ReorderItemModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            FormStyle = FormStyles.ActionBar_40;
        }
    }
}
