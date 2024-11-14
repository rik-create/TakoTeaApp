using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.View.Stock.Stock_Modal;
using TakoTea.View.Stock;

namespace TakoTea.Controller.Factory
{
    public static class ModalFactory
    {
        public static EditStockModal CreateEditStockModal(StockDetails stock)
        {
            return new EditStockModal(stock.IngredientName, stock.CurrentQuantity, stock.MeasuringUnit, stock.ReorderLevel);
        }
    }


}
