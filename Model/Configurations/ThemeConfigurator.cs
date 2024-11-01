using MaterialSkin;
using MaterialSkin.Controls;

namespace TakoTea.Configurations
{
    public static class ThemeConfigurator
    {
        public static void ApplyDarkTheme(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red600,
                Primary.BlueGrey900,
                Primary.Blue200,
                Accent.LightBlue700,
                TextShade.WHITE
            );
        }
    }
}
