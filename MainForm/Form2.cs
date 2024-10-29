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

namespace TakoTea.MainForm
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();

            materialDrawer1.Controls.Add(materialButton3);
            InitializeMaterialListView();
        }

        private void InitializeMaterialListView()
        {
            // Create a MaterialListView
            MaterialListView materialListView = new MaterialListView
            {
                Dock = DockStyle.Fill,
                View = View.Details, // Set view style to Details
                FullRowSelect = true, // Select the entire row
                GridLines = true // Show grid lines
            };

            // Add columns
            materialListView.Columns.Add("Column 1", 100);
            materialListView.Columns.Add("Column 2", 100);
            materialListView.Columns.Add("Column 3", 100);

            // Add sample data
            ListViewItem item1 = new ListViewItem(new[] { "Item 1", "Data 1", "More Data 1" });
            ListViewItem item2 = new ListViewItem(new[] { "Item 2", "Data 2", "More Data 2" });
            materialListView.Items.Add(item1);
            materialListView.Items.Add(item2);

            // Add the MaterialListView to the form
            this.Controls.Add(materialListView);
        }
    }
}
