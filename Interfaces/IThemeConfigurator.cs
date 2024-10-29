using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.Interfaces
{
    public interface IThemeConfigurator
    {
        void ApplyTheme(MaterialForm form);
    }
    public interface IFormSettingsConfigurator
    {
        void ApplySettings(MaterialForm form);
    }
}
