using System;
using System.Drawing;
using System.Windows.Forms;
using TakoTea.Configurations;
namespace TakoTea.Controls
{
    public partial class ProductWidget : UserControl
    {
        public ProductWidget()
        {
            InitializeComponent();
            lblProductName.BackColor = ThemeConfigurator.GetCustomAccentColor();
            lblProductName.ForeColor = Color.White;
        }
        private void ProductWidget_Load(object sender, EventArgs e)
        {
        }
    }
}
