
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Dashboard.Dashboard_Modals;
using TakoTea.Factory;
using TakoTea.MainForm;

namespace TakoTea.Dashboard
{
    public partial class MainForm : MaterialForm
    {
        public static MainForm Instance;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.BlueGrey900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);

            Instance = this;

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
                    formToLoad = new MainOverviewFormLoader2().LoadForm();
                    targetPanel = panelDashboard;
                    this.Text = "TakoTea Dashboard";
                    break;
                case "tabPageProduct":
                    formToLoad = new ProductFormLoader().LoadForm();
                    targetPanel = panelProduct;
                    this.Text = "TakoTea Product";
                    break;
                case "tabPageSales":
                    formToLoad = new SalesFormLoader().LoadForm();
                    targetPanel = panelSales;
                    this.Text = "TakoTea Sales Management";

                    break;
                case "tabPageItem":
                    formToLoad = new ItemFormLoader().LoadForm();
                    targetPanel = panelItem;
                    this.Text = "TakoTea Item Management";

                    break;
                case "tabPageStock":
                    formToLoad = new StockFormLoader().LoadForm();
                    targetPanel = panelStock;
                    this.Text = "TakoTea Stock Management";

                    break;
                case "tabPageOrder":
                    formToLoad = new OrderFormLoader().LoadForm();
                    targetPanel = panelOrder;
                    this.Text = "TakoTea Order Management";

                    break;
                case "tabPageBatch":
                    formToLoad = new BatchFormLoader().LoadForm();
                    targetPanel = panelBatch;
                    this.Text = "TakoTea Batch Management";

                    break;
                case "tabPageReports":
                    formToLoad = new ReportsFormLoader().LoadForm();
                    targetPanel = panelReports;
                    this.Text = "TakoTea Reports";

                    break;
                case "tabPageSettings":
                    formToLoad = new SettingsFormLoader().LoadForm();
                    targetPanel = panelSettings;
                    this.Text = "TakoTea Settings";

                    break;
                default:
                    return; // If no matching tab, exit
            }
            if (targetPanel != null && formToLoad != null)
            {
                targetPanel.Controls.Clear(); // Clears any previous control


                targetPanel.Controls.Add(formToLoad); // Adds the new form
                formToLoad.Show();



            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            Form formToLoad = null;
            Control targetPanel = null;
            formToLoad = new MainOverviewFormLoader().LoadForm();
            targetPanel = panelDashboard;

            if (targetPanel != null && formToLoad != null)
            {
                targetPanel.Controls.Clear(); // Clears any previous control


                targetPanel.Controls.Add(formToLoad); // Adds the new form
                formToLoad.Show();




            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form2 reportsForm = new Form2();
            reportsForm.Show();
        }

        private void menuStripDashboardSections_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var loader = DashboardFormLoaderFactory.GetFormLoader(e.ClickedItem.Name);

            if (loader != null)
            {
                Form form = loader.LoadForm();
                panelDashboard.Controls.Clear();
                panelDashboard.Controls.Add(form);
                form.Show();
            }
        }

        private void menuStripItem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var loader = ItemFormLoaderFactory.GetFormLoader(e.ClickedItem.Name);

            if (loader != null)
            {
                Form form = loader.LoadForm();
                panelItem.Controls.Clear();
                panelItem.Controls.Add(form);
                form.Show();
            }
        }

        private void menuStripStocks_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            {
                var loader = StockFormLoaderFactory.GetFormLoader(e.ClickedItem.Name);

                if (loader != null)
                {
                    Form form = loader.LoadForm();
                    panelStock.Controls.Clear();
                    panelStock.Controls.Add(form);
                    form.Show();
                }
            }
        }
    }
}



