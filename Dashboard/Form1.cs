
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

namespace TakoTea.Dashboard
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.BlueGrey900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);
        }

        private void tabPage1_Click(object sender, EventArgs e)


        {



        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == tabPage1)
            {
                MainOverviewFoorm mainOverviewControl = new MainOverviewFoorm();

                mainOverviewControl.TopLevel = false;
                mainOverviewControl.FormBorderStyle = FormBorderStyle.None;
                mainOverviewControl.Dock = DockStyle.Fill;

                panelDash.Controls.Add(mainOverviewControl);

                mainOverviewControl.Show();
            }
        }
    }
}
