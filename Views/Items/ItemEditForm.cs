using MaterialSkin.Controls;
using System.Windows.Forms;
using TakoTea.Configurations;

namespace TakoTea.Item_Management
{
    public partial class ItemEditForm : MaterialForm
    {
        public ItemEditForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
