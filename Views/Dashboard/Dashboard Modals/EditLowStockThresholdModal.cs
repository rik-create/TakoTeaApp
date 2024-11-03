using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.Dashboard.Dashboard_Modals
{
    public partial class EditLowStockThresholdModal : MaterialForm
    {
        public EditLowStockThresholdModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            this.Sizable = false;
        }
    }
}
