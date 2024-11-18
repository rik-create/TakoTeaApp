using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Views.Items.Item_Modals;

using TakoTea.View.Order;
using TakoTea.View.Product.Product_Modals;
namespace TakoTea.Views.MainForm
{
    public partial class TakoTeaForm : MaterialForm
    {
        public static TakoTeaForm Instance;
        private readonly IFormFactory _formFactory;
        private readonly FormLoader _formLoader;
        public TakoTeaForm()
        {
            InitializeComponent();
            _formFactory = new FormFactory();
            _formLoader = new FormLoader(_formFactory);
            ThemeConfigurator.ApplyDarkTheme(this);
            Instance = this;
        }
        // Method to adjust the main form's height based on the panel's current height
        private void AdjustFormHeightBasedOnPanel(Panel panel1)
        {
            Height = 774;
            int basePanelHeight = 618; // The base height of the panel
            int currentPanelHeight = panel1.Height; // Replace panel1 with the actual panel's name
            if (currentPanelHeight > basePanelHeight)
            {
                // Calculate the difference and adjust the main form's height
                int heightDifference = currentPanelHeight - basePanelHeight;
                Height += heightDifference - 36;
            }
            else if (currentPanelHeight < basePanelHeight)
            {
                // Optionally adjust down if the panel height is less than the base height
                int heightDifference = basePanelHeight - currentPanelHeight;
                Height -= heightDifference;
            }
        }
        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = materialTabControl1.SelectedTab;
            // Determine the form key based on the selected tab
            string formKey;
            switch (selectedTab.Name)
            {
                case "tabPageDashboard":
                    formKey = "Dashboard";
                    break;
                case "tabPageProduct":
                    formKey = "Product";
                    break;
                case "tabPageSales":
                    formKey = "Sales";
                    break;
                case "tabPageItem":
                    formKey = "Item";
                    break;
                case "tabPageStock":
                    formKey = "Stock";
                    break;
                case "tabPageBatch":
                    formKey = "Batch";
                    break;
                case "tabPageReports":
                    formKey = "Reports";
                    break;
                case "tabPageSettings":
                    formKey = "Settings";
                    break;
                default:
                    return; // Exit if no valid tab is selected
            }
            // Load the form using the form key
            Form formToLoad = _formLoader.LoadForm(formKey);
            Panel targetPanel;
            // Set the target panel and form name based on the formKey
            switch (formKey)
            {
                case "Dashboard":
                    targetPanel = panelDashboard;
                    Text = "TakoTea Dashboard";
                    break;
                case "Product":
                    targetPanel = panelProduct;
                    Text = "TakoTea Product";
                    break;
                case "Sales":
                    targetPanel = panelSales;
                    Text = "TakoTea Sales Management";
                    break;
                case "Item":
                    targetPanel = panelItem;
                    Text = "TakoTea Item Management";
                    break;
                case "Stock":
                    targetPanel = panelStock;
                    Text = "TakoTea Stock Management";
                    break;
                case "Batch":
                    targetPanel = panelBatch;
                    Text = "TakoTea Batch Management";
                    break;
                case "Reports":
                    targetPanel = panelReports;
                    Text = "TakoTea Reports";
                    break;
                case "Settings":
                    targetPanel = panelSettings;
                    Text = "TakoTea Settings";
                    break;
                default:
                    return; // Exit if no valid target panel found
            }
            // If a valid form and target panel were found, add the form to the panel
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
        private void Form1_Load(object sender, EventArgs e)
        {
            Form form = _formLoader.LoadForm("Dashboard");  // Correct usage with a string as argument
            Form formToLoad = form;
            Panel targetPanel = panelDashboard;
            if (targetPanel != null && formToLoad != null)
            {
                panelDashboard.Width = formToLoad.Width;
                panelDashboard.Height = formToLoad.Height;
                CenterPanel(panelDashboard);
                AdjustFormHeightBasedOnPanel(targetPanel);
                targetPanel.Controls.Clear(); // Clears any previous control
                targetPanel.Controls.Add(formToLoad); // Adds the new form
                formToLoad.Show();
            }
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
        private void CenterPanel(Panel panel)
        {
            panel.Left = ((ClientSize.Width - panel.Width) / 2) - 30;
        }
        /*        private void menuStripItem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
        */
        private void tabPageStock_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            toolStripQuickAccess.Visible = !toolStripQuickAccess.Visible;
            toolStripQuickAccess.Enabled = toolStripQuickAccess.Visible;
        }
        private void toolStripBtnNewOrder_Click(object sender, EventArgs e)
        {
            MenuOrderForm menuOrderForm = new MenuOrderForm();
            menuOrderForm.Show();
        }
        private void toolStripBtnAddIngredient_Click(object sender, EventArgs e)
        {
            AddItemModal addItemModal = new AddItemModal();
            _ = addItemModal.ShowDialog();
        }
        private void toolStripBtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductModal addProductModal = new AddProductModal();
            _ = addProductModal.ShowDialog();
        }
    }
}