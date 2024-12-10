using System;
using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Views.Batches;
using TakoTea.Views.Stock.Stock_Modal;

namespace TakoTea.Views.DataLoaders.Modals
{
    public static class ModalDataLoaderFactory
    {
        public static IModalDataLoader GetDataLoader(Form modalForm, object key)
        {
            switch (modalForm)
            {
                case AddBatchModal _:
                    return new EditBatchModalDataLoader((int)key);
                case EditStockModal _:
                    return new EditStockModalDataLoader((int)key);
                default:
                    throw new NotSupportedException("No data loader available for the given modal.");
            }

        }
    }

}
