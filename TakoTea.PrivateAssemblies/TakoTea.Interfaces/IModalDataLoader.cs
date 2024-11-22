using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakoTea.Interfaces
{
    public interface IModalDataLoader
    {
        void LoadData(Form modalForm);
        void ResetData(Form modalForm);
    }


}
