using MaterialSkin.Controls;
using System.Windows.Forms;
using TakoTea.Configurations;

namespace TakoTea.Dashboard.Dashboard_Modals
{
    public partial class OrderQueueForm : MaterialForm
    {
        public OrderQueueForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
