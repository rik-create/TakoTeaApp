using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Product;
using TakoTea.View.Batches;
using TakoTea.View.Orders;
using TakoTea.View.Settings;
using TakoTea.Views.ComboMealForms;
using TakoTea.Views.Dashboard;
using TakoTea.Views.Items;
using TakoTea.Views.Logs2;
using TakoTea.Views.Stock;
namespace TakoTea.Views
{
    public class FormFactory : IFormFactory
    {
        public Form CreateForm(string formKey)
        {
            switch (formKey)
            {
                case "Dashboard":
                    return new DashboardForm();
                case "Product":
                    return new ProductListForm();
                case "Sales":
                    return new SalesListForm();
                case "Item":
                    return new IngredientListForm();
                case "Stock":
                    return new CurrentStockLevelForm();
                case "Order":
                    return new MenuOrderForm();
                case "Batch":
                    return new BatchListForm();
                case "Reports":
                    return new LogsForm();
                case "Settings":
                    return new UserManagementForm();
                case "ProductCateg":
                    return new ProductForm();
                case "VariantChanges":
                    return new ProductListLogsForm();
                case "IngredientChanges":
                    return new IngredientListLogsForm();
                case "BatchChanges":
                    return new BatchListLogsForm();
                case "ComboMeal":
                    return new ComboMealListForm();
                case "AddOn":
                    return new AddOnsListForm();

                // Add more cases as needed...
                default:
                    return null;
            }
        }
    }
}
