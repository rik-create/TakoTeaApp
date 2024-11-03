using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.View.Reports
{
    public partial class SalesReportForm : MaterialForm
    {
        public SalesReportForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);


        }
    }
}
