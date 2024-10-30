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
using TakoTea.Configurations;
using TakoTea.Item_Management;
using TakoTea.Items.Item_Modals;


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
    }
}
