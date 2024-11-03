using MaterialSkin.Controls;
using TakoTea.Configurations;

namespace TakoTea.Dashboard
{
    public partial class UserActivitiesForm : MaterialForm
    {
        public UserActivitiesForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);



            materialCheckedListBox1.Items.Add("Others");
            materialCheckedListBox1.Items.Add("Edit");

            materialCheckedListBox1.Items.Add("Add");

            materialCheckedListBox1.Items.Add("Deletion");
            materialCheckedListBox1.Items.Add("Logins");




        }
    }
}
