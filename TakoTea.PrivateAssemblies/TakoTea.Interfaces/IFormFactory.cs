using System.Windows.Forms;
namespace TakoTea.Interfaces
{
    public interface IFormFactory
    {
        Form CreateForm(string formKey);
    }
}
