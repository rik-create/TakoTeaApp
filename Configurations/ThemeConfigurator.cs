using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Primary.Red500,
                Primary.BlueGrey900,
                Primary.Blue200,
                Accent.LightBlue200,
                TextShade.WHITE
            );
        }
    }
}
