using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Items.Item_Modals;
using TakoTea.View.Items.Item_Modals;


namespace TakoTea.Items
{
    public partial class ItemListForm : MaterialForm
    {
        public ItemListForm()
        {
            InitializeComponent();


            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);



        }

        private void Item_Load(object sender, EventArgs e)
        {

        }

        private void materialButtonEdit_Click(object sender, EventArgs e)
        {
            EditItemModal itemEditForm = new EditItemModal();
            itemEditForm.MinimizeBox = false;
            itemEditForm.MaximizeBox = false;
            itemEditForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCheckedListBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void floatingActionButtonAddItem_Click(object sender, EventArgs e)
        {
            AddItemModal addItemModal = new AddItemModal();
            addItemModal.ShowDialog();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
