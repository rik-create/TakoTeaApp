using MailKit.Net.Smtp;
using MailKit.Security;
using MaterialSkin.Controls;
using Microsoft.SqlServer.Management.Smo;
using MimeKit;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Product;
using TakoTea.Repository;
using TakoTea.View.Items.Item_Modals;
using TakoTea.View.Orders;
using TakoTea.View.Product;
using TakoTea.View.Product.Product_Modals;
using TakoTea.Views.mainform;
using TakoTea.Views.reports;
using TakoTea.Views.settings;
namespace TakoTea.Views.MainForm
{
    public partial class TakoTeaForm : MaterialForm
    {
        public static TakoTeaForm Instance;
        private readonly IFormFactory _formFactory;
        private readonly FormLoader _formLoader;
        private readonly Entities _context;
        private readonly LoginForm loginForm;
        public TakoTeaForm()
        {
            InitializeComponent();
            _formFactory = new FormFactory();
            _formLoader = new FormLoader(_formFactory);
            ThemeConfigurator.ApplyDarkTheme(this);
            Instance = this;
            InitializeNotificationTimer();
            _context = new Entities();
            // Assuming materialComboBoxQuickAccess is your ComboBox control

            // Clear existing items (if any)
            materialComboBoxQuickAccess.Items.Clear();

            // Add the new items
            materialComboBoxQuickAccess.Items.Add("Quick Access");
            materialComboBoxQuickAccess.Items.Add("Reports");
            materialComboBoxQuickAccess.Items.Add("Settings");
            materialComboBoxQuickAccess.Items.Add("Reload");

            // Optionally, set a default selected item
            materialComboBoxQuickAccess.SelectedIndex = 0; // Selects "Quick Access" by default
        }


        private void InitializeNotificationTimer()
        {
            // Create a Timer with the specified interval
            System.Timers.Timer timer = new System.Timers.Timer();

            // Set the interval based on the selected frequency in cmbAlertFrequency
            timer.Interval = GetNotificationInterval().TotalMilliseconds;

            // Attach the Elapsed event handler
            timer.Elapsed += CheckInventoryAndSendNotifications;

            // Start the timer
            timer.Start();
        }
        private void CheckInventoryAndSendNotifications(object sender, System.Timers.ElapsedEventArgs e)
        {
            var context = new Entities();
            var settings = context.Settings.FirstOrDefault();
            if (settings == null)
            {
                return;
            }

            // Check if notifications are enabled
            if (!settings.EnableInAppNotifications.Value && !settings.EnableEmailNotifications.Value)
            {
                return; // Exit if both types of notifications are disabled
            }

            var emailAddresses = settings.SavedEmails.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);

            var lowStockIngredients = context.Ingredients.Where(i => i.StockLevel <= i.LowLevel).ToList();
            var outOfStockIngredients = context.Ingredients.Where(i => i.StockLevel <= 0).ToList();

            StringBuilder message = new StringBuilder();
            if (lowStockIngredients.Count > 0)
            {
                message.AppendLine("Low Stock Ingredients:");
                foreach (var ingredient in lowStockIngredients)
                {
                    message.AppendLine($"- {ingredient.IngredientName}: {ingredient.StockLevel} {ingredient.MeasuringUnit}");
                }
            }

            if (outOfStockIngredients.Count > 0)
            {
                message.AppendLine("\nOut of Stock Ingredients:");
                foreach (var ingredient in outOfStockIngredients)
                {
                    message.AppendLine($"- {ingredient.IngredientName}");
                }
            }

            if (message.Length > 0)
            {
                if (settings.EnableInAppNotifications.Value)
                {
                    // Show in-app notification (you'll need to implement this)
                    ShowInAppNotification(message.ToString());
                }

                if (settings.EnableEmailNotifications.Value && emailAddresses.Length > 0)
                {
                    SendEmailNotifications(emailAddresses, "Inventory Alert", message.ToString());
                }
            }
        }

        private void ShowInAppNotification(string message)
        {
            MessageBox.Show(message, "Inventory Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private TimeSpan GetNotificationInterval()
        {
            var _context = new Entities();


            // Retrieve the selected frequency from the database or settings
            string selectedFrequency = _context.Settings.FirstOrDefault()?.LowStockFrequency; // Assuming you have a Settings entity

            switch (selectedFrequency)
            {
                case "Daily":
                    return TimeSpan.FromDays(1);
                case "Hourly":
                    return TimeSpan.FromHours(1);
                // Add more cases for other frequencies as needed
                default:
                    return TimeSpan.FromDays(1); // Default to daily
            }
        }


        private void SendEmailNotifications(string[] recipients, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tako Tea", "takotea9@gmail.com")); // Replace with your email address
            foreach (string recipient in recipients)
            {
                message.To.Add(new MailboxAddress(recipient, recipient));
            }
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("takotea9@gmail.com", "rhdl vljl ztfn xzui");
                client.Send(message);
                client.Disconnect(true);
            }
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
                    Text = "TakoTea Logs";
                    break;
         
                default:
                    return; // Exit if no valid target panel found
            }
            // If a valid form and target panel were found, add the form to the panel
            if (targetPanel != null && formToLoad != null)
            {
                // Create and show the progress bar
                ProgressBar progressBar = LoadingScreenHelper.CreateProgressBar();
                targetPanel.Controls.Add(progressBar);
                progressBar.BringToFront(); // Ensure the progress bar is visible

                // Load the form asynchronously
                Task.Run(() =>
                {
                    // Simulate loading delay (remove this in your actual implementation)

                    // Update the UI on the main thread
                    BeginInvoke(new Action(() =>
                    {
                        targetPanel.Width = formToLoad.Width;
                        targetPanel.Height = formToLoad.Height;
                        CenterPanel(targetPanel);
                        AdjustFormHeightBasedOnPanel(targetPanel);
                        targetPanel.Controls.Clear(); // This will also remove the progress bar
                        targetPanel.Controls.Add(formToLoad);
                        formToLoad.Show();
                    }));
                });
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UserRepository.Initialize(_context);
            this.Shown += (s, args) => { this.Activate(); };


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

        private void btnReload_Click(object sender, EventArgs e)
        {
            CheckInventoryAndSendNotifications(null, null);


            // 1. Get the currently selected tab
            TabPage selectedTab = materialTabControl1.SelectedTab;

            string formKey = ""; // Initialize with an empty string
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
                    return; // Do nothing if an unexpected tab is selected
            }

            // 3. Load a new instance of the form
            Form newForm = _formLoader.LoadForm(formKey);

            // 4. Find the correct panel to update
            Panel targetPanel = null;
            switch (formKey)
            {
                case "Dashboard":
                    targetPanel = panelDashboard;
                    break;
                case "Product":
                    targetPanel = panelProduct;
                    break;
                case "Sales":
                    targetPanel = panelSales;
                    break;
                case "Item":
                    targetPanel = panelItem;
                    break;
                case "Stock":
                    targetPanel = panelStock;
                    break;
                case "Batch":
                    targetPanel = panelBatch;
                    break;
                case "Reports":
                    targetPanel = panelReports;
                    break;
         
                default:
                    return; // Do nothing if an unexpected formKey is encountered
            }

            // If a valid form and target panel were found, replace the form in the panel
            if (targetPanel != null && newForm != null)
            {
                targetPanel.Width = newForm.Width;
                targetPanel.Height = newForm.Height;
                CenterPanel(targetPanel);
                AdjustFormHeightBasedOnPanel(targetPanel);

                // Dispose of the old form before clearing the controls
                foreach (Control control in targetPanel.Controls)
                {
                    if (control is Form oldForm)
                    {
                        oldForm.Dispose();
                    }
                }

                targetPanel.Controls.Clear();
                targetPanel.Controls.Add(newForm);
                newForm.Show();
            }
        }

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
      
        }

        private void materialComboBoxQuickAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item
            string selectedItem = materialComboBoxQuickAccess.SelectedItem.ToString();

            // Handle different selections
            switch (selectedItem)
            {
                case "Quick Access":
                    toolStripQuickAccess.Visible = !toolStripQuickAccess.Visible;
                    toolStripQuickAccess.Enabled = toolStripQuickAccess.Visible;
                    break;
                case "Reports":
                    ReportingForm reportingForm = new ReportingForm();
                    reportingForm.Show();
                    materialComboBoxQuickAccess.Text = "Other Module";
                    break;
                case "Settings":
                    SettingsForm settingsForm = new SettingsForm();
                    settingsForm.ShowDialog();
                    materialComboBoxQuickAccess.Text = "Other Module";

                    break;
                case "Reload":
                    btnReload_Click(sender, e);
                    materialComboBoxQuickAccess.Text = "Other Module";

                    break;
             
            }
        }

        private void toolStripMenuItemProductVariant_Click(object sender, EventArgs e)
        {

        }
        private void menuStripProducts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripMenuItemProducts) // Assuming toolStripMenuItemProducts is your "Products" menu item
            {
                // Load ProductCategoryForm
                Form formToLoad = new ProductCategoryForm(); // Or use your factory if you have one
                panelProduct.Width = formToLoad.Width;
                panelProduct.Height = formToLoad.Height;
                CenterPanel(panelProduct);
                AdjustFormHeightBasedOnPanel(panelProduct);
                panelProduct.Controls.Clear();
                panelProduct.Controls.Add(formToLoad);
                formToLoad.Show();
            }
            else if (e.ClickedItem == toolStripMenuItemProductVariant) // Assuming toolStripMenuItemVariants is your "Variants" menu item
            {
                // Load ProductListForm
                Form formToLoad = new ProductListForm(); // Or use your factory
                panelProduct.Width = formToLoad.Width;
                panelProduct.Height = formToLoad.Height;
                CenterPanel(panelProduct);
                AdjustFormHeightBasedOnPanel(panelProduct);
                panelProduct.Controls.Clear();
                panelProduct.Controls.Add(formToLoad);
                formToLoad.Show();
            }
        }

        private void toolStripMenuItemProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
