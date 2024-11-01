using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.View.Stock
{
    public partial class AdjustStockForm : MaterialForm
    {
        public AdjustStockForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }
    }
}
