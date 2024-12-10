using System.Windows.Forms;

namespace TakoTea.Interfaces
{
    public interface IModalDataLoader
    {
        void LoadData(Form modalForm);
        void ResetData(Form modalForm);
    }


}
