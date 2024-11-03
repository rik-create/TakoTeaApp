using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.View.Batch
{
    public partial class AddBatchForm : MaterialForm
    {
        public AddBatchForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }
    }
}
