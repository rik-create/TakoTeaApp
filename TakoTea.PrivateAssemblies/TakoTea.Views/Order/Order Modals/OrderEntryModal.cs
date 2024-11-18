using MaterialSkin.Controls;
using TakoTea.Configurations;
namespace TakoTea.Views.Order.Order_Modals
{
    public partial class OrderEntryModal : MaterialForm
    {
        public OrderEntryModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
        }
        private void takoyakiItemControl1_Load(object sender, System.EventArgs e)
        {
        }
        private void materialCard2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }
        private void takoyakiItemControl1_Load_1(object sender, System.EventArgs e)
        {
        }
    }
}
