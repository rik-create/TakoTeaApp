using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.View.Stock.Stock_Modal
{
    public partial class AdjustStockModal : MaterialForm
    {
        public AdjustStockModal()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }
    }
}
