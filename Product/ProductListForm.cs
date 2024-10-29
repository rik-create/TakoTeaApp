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
using TakoTea.Dashboard;
using TakoTea.Product.Product_Modals;

namespace TakoTea.Product
{
    public partial class ProductListForm : MaterialForm
    {
        public ProductListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);


            materialCheckedListBox1.Items.Add("Milktea");
            materialCheckedListBox1.Items.Add("Takoyaki");
            materialCheckedListBox1.Items.Add("Milktea");
            materialCheckedListBox1.Items.Add("Takoyaki");
            materialCheckedListBox1.Items.Add("Milktea");
            materialCheckedListBox1.Items.Add("Takoyaki");
            materialCheckedListBox1.Items.Add("Milktea");
            materialCheckedListBox1.Items.Add("Takoyaki");


        }

 
        private void materialButton1_Click_1(object sender, EventArgs e)

        {
            this.Hide();
            Form1.Instance.Hide();
            
            EditProductModal editProductModal = new EditProductModal();
            editProductModal.ShowDialog();
            Form1.Instance.Show();
            this.Show();


        }
    }
}
