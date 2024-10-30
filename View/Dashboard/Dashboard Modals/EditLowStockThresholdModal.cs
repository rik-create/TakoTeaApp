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

namespace TakoTea.Dashboard.Dashboard_Modals
{
    public partial class EditLowStockThresholdModal : MaterialForm
    {
        public EditLowStockThresholdModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            this.Sizable = false;
        }
    }
}
