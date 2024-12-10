using Microsoft.Reporting.WinForms;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using TakoTea.Models;


namespace TakoTea.Views.Order.Order_Modals
{

    public partial class ReceiptForm : Form
    {
        private readonly MenuOrderFormService menuOrderFormService = new MenuOrderFormService();
        private readonly int orderID;
        public ReceiptForm(int order)
        {
            InitializeComponent();
            orderID = order;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void lblReceiptContent_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptReportForm_Load(object sender, EventArgs e)
        {


        }

        private OrderModel GetOrderData(int orderId)
        {
            using (Entities context = new Entities())
            {
                return context.OrderModels // Use the correct DbSet name
                                    .Include(o => o.OrderItems)
                                    .FirstOrDefault(o => o.OrderId == orderId);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private readonly ReportViewer reportViewer1 = new ReportViewer(); // Or get the existing instance

        /*        private void buttonPrint_Click(object sender, EventArgs e)
                {
                    // Create a PrintDocument object
                    PrintDocument printDocument = new PrintDocument();

                    // Set the PrintPage event handler
                    printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

                    // Set the default page settings to landscape
                    printDocument.DefaultPageSettings.Landscape = true;

                    // Calculate the desired paper size based on panelReports dimensions
                    var paperSize = new PaperSize("Custom", this.Width, this.Height);
                    printDocument.DefaultPageSettings.PaperSize = paperSize;

                    // Show the print dialog and print the document if the user clicks OK
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = printDocument;
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Print the document
                        printDocument.Print();
                    }
                }*/

        /*        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
                {
                    // Assuming 'panelReports' is the Panel you want to print
                    var panel = panelReports;

                    // Create a new Bitmap with the same size as the panel
                    Bitmap memoryImage = new Bitmap(panel.Width, panel.Height);

                    using (Graphics graphics = Graphics.FromImage(memoryImage))
                    {
                        // Capture the panel to the bitmap
                        panel.DrawToBitmap(memoryImage, new Rectangle(0, 0, panel.Width, panel.Height));

                        // Draw the captured image onto the print document's graphics
                        e.Graphics.DrawImage(memoryImage, 0, 0);
                    }
                }*/

        private void buttonSendToEmail_Click(object sender, EventArgs e)
        {
            // 3. Show input dialog for email address
            string customerEmail = GetEmailAddressFromInputDialog();
            if (string.IsNullOrWhiteSpace(customerEmail))
            {
                return; // User canceled or entered an invalid email
            }


            menuOrderFormService.SendDigitalReceipt(orderID, customerEmail, this);
        }
        // Helper method to get the email address from a well-designed input dialog
        private string GetEmailAddressFromInputDialog()
        {
            using (Form form = new Form())
            {
                form.Text = "Enter Email Address";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.ShowIcon = false;
                form.Width = 300;
                form.Height = 150;

                Label label = new Label()
                {
                    Text = "Email Address:",
                    Left = 12,
                    Top = 12,
                    AutoSize = true
                };
                TextBox textBox = new TextBox()
                {
                    Left = 12,
                    Top = 35,
                    Width = 260,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                Button buttonOk = new Button()
                {
                    Text = "OK",
                    Left = 114,
                    Top = 70,
                    Width = 75,
                    DialogResult = DialogResult.OK,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };
                buttonOk.Click += (s, a) =>
                {
                    string email = textBox.Text.Trim();
                    if (!IsValidEmail(email))
                    {
                        _ = MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _ = textBox.Focus();
                        form.DialogResult = DialogResult.None; // Prevent the dialog from closing
                    }
                };

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;

                return form.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
            }
        }

        // Helper method for basic email validation (you can add more robust validation if needed)
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // Helper function to render the report as an image (you'll need to implement this)
        private byte[] RenderReportToImage(LocalReport report)
        {
            // 1. Render the report to a bitmap

            byte[] bytes = report.Render("Image", null, out _, out _, out _, out _, out _);

            // 2. Convert the bitmap to a byte array
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bmp = new Bitmap(new MemoryStream(bytes)))
                {
                    bmp.Save(ms, ImageFormat.Png);
                }
                return ms.ToArray();
            }
        }

        private void panelReports_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            menuOrderFormService.PrintReceiptForm(this); ;
        }
    }
}
