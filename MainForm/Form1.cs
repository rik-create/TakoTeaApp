
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
using TakoTea.MainForm;

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
            Form formToLoad = null;
            Control targetPanel = null;


         

            switch (materialTabControl1.SelectedTab.Name)
            {
                case "tabPageDashboard":
                    formToLoad = new MainOverviewFormLoader().LoadForm();
                    targetPanel = panelDashboard;



                    break;
                case "tabPageSales":
                    formToLoad = new SalesFormLoader().LoadForm();
                    targetPanel = panelSales;
                    break;
                case "tabPageItem":
                    formToLoad = new ItemFormLoader().LoadForm();
                    targetPanel = panelItem; 
                    break;
                case "tabPageStock":
                    formToLoad = new StockFormLoader().LoadForm();
                    targetPanel = panelStock; 
                    break;
                case "tabPageOrder":
                    formToLoad = new OrderFormLoader().LoadForm();
                    targetPanel = panelOrder; 
                    break;
                case "tabPageBatch":
                    formToLoad = new BatchFormLoader().LoadForm();
                    targetPanel = panelBatch;
                    break;
                case "tabPageReports":
                    formToLoad = new ReportsFormLoader().LoadForm();
                    targetPanel = panelReports;
                    break;
                case "tabPageSettings":
                    formToLoad = new SettingsFormLoader().LoadForm();
                    targetPanel = panelSettings;
                    break;
                default:
                    return; // If no matching tab, exit
            }
            if (targetPanel != null && formToLoad != null)
            {
                targetPanel.Controls.Clear(); // Clears any previous control


                targetPanel.Controls.Add(formToLoad); // Adds the new form
                formToLoad.Show();

                // Position it manually inside the panel (optional: center it)
              

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }
    }
}
