using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;
namespace TakoTea.Configurations
{
    public static class ThemeConfigurator
    {
        public static void ApplyDarkTheme(MaterialForm form)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.LightBlue900,
                Primary.BlueGrey900,
                Primary.BlueGrey900,
                Accent.Red700,
                TextShade.WHITE
            );
        }


        public static ColorScheme GetCurrentColorScheme()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            return materialSkinManager.ColorScheme;
        }

        // Get the primary color
        public static Color GetPrimaryColor()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            return materialSkinManager.ColorScheme.PrimaryColor;
        }

 

        // Get the accent color
        public static Color GetAccentColor()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            return materialSkinManager.ColorScheme.AccentColor;
        }

        // Get the text color
        public static Color GetTextColor()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            return materialSkinManager.ColorScheme.TextColor;
        }

    }
}
