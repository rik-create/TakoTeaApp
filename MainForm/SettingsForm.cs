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
using static MaterialSkin.Controls.MaterialForm;

namespace TakoTea.Dashboard
{
    public partial class SettingsForm : MaterialForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.BlueGrey900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);
            this.FormStyle = FormStyles.StatusAndActionBar_None;
        }
    }
}
