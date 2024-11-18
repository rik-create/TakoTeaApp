using MaterialSkin.Controls;
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
