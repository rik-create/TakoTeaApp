using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;

namespace TakoTea.Items
{
    public partial class ItemAddForm : MaterialForm
    {
        public ItemAddForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
