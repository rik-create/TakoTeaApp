using MaterialSkin;
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

namespace TakoTea.Views.AddOns
{
    public partial class AddAddOnsModal : MaterialForm
    {
        public AddAddOnsModal()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);


            ModalSettingsConfigurator.ApplyStandardModalSettings(this);

        }

        private void AddProductModal_Load(object sender, EventArgs e)
        {

        }
    }
}
