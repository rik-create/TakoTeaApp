using System.Windows.Forms;
using TakoTea.Configurations;
namespace TakoTea.Controls
{
    public partial class CategoryButtonOrdering : UserControl
    {
        public CategoryButtonOrdering()
        {
            InitializeComponent();
            buttonCategory.BackColor = ThemeConfigurator.GetCustomAccentColor();
            buttonCategory.ForeColor = ThemeConfigurator.GetTextColor();
        }

    }
}
