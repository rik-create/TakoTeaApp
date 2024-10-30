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

namespace TakoTea.View.Stock.Stock_Modal
{
    public partial class ReorderItemModal : MaterialForm
    {
        public ReorderItemModal()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            this.FormStyle = FormStyles.ActionBar_40;

        }
    }
}
