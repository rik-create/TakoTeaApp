using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;

namespace TakoTea.Configurations
{
    public static class ThemeConfigurator
    {
        public static void ApplyDarkTheme(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.LightBlue900,
                Primary.BlueGrey900,
                Primary.BlueGrey900,
                Accent.Red700,
                TextShade.WHITE
            );
            form.BackColor = Color.White;

        }
    }
}
