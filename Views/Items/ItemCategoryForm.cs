using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.View.Items
{
    public partial class ItemCategoryForm : MaterialForm
    {
        public ItemCategoryForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }
    }
}
