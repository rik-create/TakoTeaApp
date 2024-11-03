using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.View.Stock
{
    public partial class LowStockAlertsForm : MaterialForm
    {
        public LowStockAlertsForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }
    }
}
