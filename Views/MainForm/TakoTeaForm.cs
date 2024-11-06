using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Controller.Factory;
using TakoTea.Factory;
using TakoTea.Items;
using TakoTea.View.Dashboard;
using TakoTea.View.Order;

namespace TakoTea.MainForm
{
    public partial class TakoTeaForm : MaterialForm
    {
        public static TakoTeaForm Instance;

        public TakoTeaForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);


            Instance = this;

        }

        private void tabPage1_Click(object sender, EventArgs e)


        {

        }
        // Method to adjust the main form's height based on the panel's current height
        private void AdjustFormHeightBasedOnPanel(Panel panel1)
        {
            this.Height = 774;
            int basePanelHeight = 618; // The base height of the panel
            int currentPanelHeight = panel1.Height; // Replace panel1 with the actual panel's name

            if (currentPanelHeight > basePanelHeight)
            {
                // Calculate the difference and adjust the main form's height
                int heightDifference = currentPanelHeight - basePanelHeight;
                this.Height += (heightDifference-36);
            }
            else if (currentPanelHeight < basePanelHeight)
            {
                // Optionally adjust down if the panel height is less than the base height
                int heightDifference = basePanelHeight - currentPanelHeight;
                this.Height -= heightDifference;
            }
        }


        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form formToLoad = null;
            Panel targetPanel = null;
            TabPage selectedTab = materialTabControl1.SelectedTab;

            switch (selectedTab.Name)
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
                    return;
            }

            if (targetPanel != null && formToLoad != null)
            {



                targetPanel.Width = formToLoad.Width;
                targetPanel.Height = formToLoad.Height;
                CenterPanel(targetPanel);
                AdjustFormHeightBasedOnPanel(targetPanel);
                targetPanel.Controls.Clear(); 
                targetPanel.Controls.Add(formToLoad);

                formToLoad.Show();
            }
        }

        private bool AreControlsOutOfBounds(TabPage tabPage)
        {
            foreach (Control control in tabPage.Controls)
            {
                // Check if the control is out of bounds
                if (!tabPage.ClientRectangle.Contains(control.Bounds))
                {
                    // If control's bounds exceed the parent's client area, return true
                    return true;
                }
            }
            // If no controls are out of bounds, return false
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            Form formToLoad = null;
            Control targetPanel = null;
            formToLoad = new MainOverviewFormLoader().LoadForm();
            targetPanel = panelDashboard;

            if (targetPanel != null && formToLoad != null)
            {
                panelDashboard.Width = formToLoad.Width;
                panelDashboard.Height = formToLoad.Height;
                CenterPanel(panelDashboard);
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

        private ToolStripMenuItem activeMenuItem = null;

        private void HandleMenuItemClick(ToolStripMenuItem clickedMenuItem)
        {
            // Check if the clicked item is the same as the currently active one
            if (activeMenuItem == clickedMenuItem)
            {
                // If the clicked item is already active, do nothing
                return;
            }

            // Re-enable the previously active menu item if it exists
            if (activeMenuItem != null)
            {
                activeMenuItem.Enabled = true;
            }

            // Disable the clicked menu item
            clickedMenuItem.Enabled = false;

            // Update the active menu item
            activeMenuItem = clickedMenuItem;
        }


        private void menuStripDashboardSections_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripMenuItem clickedMenuItem)
            {
                // Call the reusable method to handle active menu item state
                HandleMenuItemClick(clickedMenuItem);

                // Load the form associated with the clicked item
                var loader = DashboardFormLoaderFactory.GetFormLoader(clickedMenuItem.Name);
                if (loader != null)
                {
                    Form form = loader.LoadForm();
                    panelDashboard.Width = form.Width;
                    panelDashboard.Height = form.Height;
                    CenterPanel(panelDashboard);
                    AdjustFormHeightBasedOnPanel(panelDashboard);


                    panelDashboard.Controls.Clear();
                    panelDashboard.Controls.Add(form);
                    form.Show();
                }
            }
        }
        private void CenterPanel(Panel panel)
        {
            panel.Left = ((this.ClientSize.Width - panel.Width) / 2) -30;
        }


        private void menuStripItem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripMenuItem clickedMenuItem)
            {
                // Call the reusable method to handle active menu item state
                HandleMenuItemClick(clickedMenuItem);
                var loader = ItemFormLoaderFactory.GetFormLoader(e.ClickedItem.Name);

                if (loader != null)
                {
                    Form form = loader.LoadForm();
                    panelItem.Width = form.Width;
                    panelItem.Height = form.Height;
                    CenterPanel(panelItem);
                    panelItem.Controls.Clear();
                    panelItem.Controls.Add(form);


                    form.Show();
                }
            }
        }

        private void menuStripStocks_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            {
                if (e.ClickedItem is ToolStripMenuItem clickedMenuItem)
                {
                    // Call the reusable method to handle active menu item state
                    HandleMenuItemClick(clickedMenuItem);
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

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            MenuOrderForm menuOrderForm = new MenuOrderForm();
            menuOrderForm.Show();
        }


        private void menuStripProducts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripMenuItem clickedMenuItem)
            {
                HandleMenuItemClick(clickedMenuItem);
                var loader = ProductFormLoaderFactory.GetFormLoader(e.ClickedItem.Name);

                if (loader != null)
                {
                    Form form = loader.LoadForm();
                    panelProduct.Width = form.Width;
                    panelProduct.Height = form.Height;
                    CenterPanel(panelProduct);
                    panelProduct.Controls.Clear();
                    panelProduct.Controls.Add(form);


                    form.Show();
                }
            }
        }

        private void tabPageStock_Click(object sender, EventArgs e)
        {

        }
    }
}