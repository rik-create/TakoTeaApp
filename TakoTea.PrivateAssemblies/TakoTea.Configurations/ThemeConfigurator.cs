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
        public static Color GetCustomAccentColor()
        {
            return Color.FromArgb(184, 35, 32); // Return the custom accent color
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

        public static Color GetYellowColor()
        {
            return Color.FromArgb(255, 211, 47); // Return the yellow color (RGB 255, 211, 47)
        }

    }
}
