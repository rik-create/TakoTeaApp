using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Interfaces;
using TakoTea.Product.Product_Modals;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Product.Product_Modals;
namespace TakoTea.Product
{
    public partial class ProductListForm : MaterialForm
    {

        IProductVariantService _variantService;
        DataAccessObject _dataAccessObject;
        public ProductListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

            _dataAccessObject = new DataAccessObject();
            _variantService = new ProductVariantService(_dataAccessObject);

            DrawerWidth = 0;
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
        }
        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            Hide();
            ParentForm.Hide();
            EditProductModal editProductModal = new EditProductModal();
            _ = editProductModal.ShowDialog();
            ParentForm.Show();
            Show();
        }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void materialLabel25_Click(object sender, EventArgs e)
        {
        }
        private void materialTextBox23_Click(object sender, EventArgs e)
        {
        }
        private void materialButton3_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void floatingActionButtonAddProduct_Click(object sender, EventArgs e)
        {
            AddProductModal addProductModal = new AddProductModal(_variantService);
            _ = addProductModal.ShowDialog();
            ThemeConfigurator.ApplyDarkTheme(this);
        }
        private void materialRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void btnAddComboMeal_Click(object sender, EventArgs e)
        {
            AddComboMealModal addComboMealModal = new AddComboMealModal();
            _ = addComboMealModal.ShowDialog();
        }
    }
}
