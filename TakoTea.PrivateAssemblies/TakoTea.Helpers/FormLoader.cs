using System.Windows.Forms;
using TakoTea.Interfaces;
namespace TakoTea.Helpers
{
    public class FormLoader : ITabFormLoader
    {
        private readonly IFormFactory _formFactory;
        public FormLoader(IFormFactory formFactory)
        {
            _formFactory = formFactory;
        }
        public Form LoadForm(string formKey)
        {
            Form form = _formFactory.CreateForm(formKey);
            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
            }
            return form;
        }
    }
}
