using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
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
