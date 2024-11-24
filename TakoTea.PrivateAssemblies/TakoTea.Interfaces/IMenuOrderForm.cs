using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Models;

namespace TakoTea.Interfaces
{
    public interface IMenuOrderForm
    {
        void LoadMenuVariants(FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg);
        void AddToOrderList(string productName, int quantity, decimal price);
        void ClearOrderList();
        void UpdateTotal();
        void ConfirmOrder();
        void CancelOrder();
        void DisplayCustomerDetails(string customerName);
        int GenerateNewOrderId();
        void ResetForm();
        void UpdateStockLevels();
        void DisplayConfirmationMessage(string message);
        void GenerateReceipt(int orderId);
        void AddToSalesHistory(int orderId, DateTime orderDate, decimal totalAmount, string paymentMethod, string customerName);
        bool ValidateOrder();
        void SaveDraftOrder(int draftOrderId, List<OrderItem> items, decimal totalAmount, string customerName, string paymentMethod);
        void LoadDraftOrder(int draftOrderId);
        void PrintOrderSummary(int orderId);
        void HandlePayment(int orderId, decimal amountPaid, string paymentMethod);
        void ApplyDiscount(decimal discountValue, bool isPercentage);
        void HandleRefund(int orderId, string reason, decimal refundAmount);
        void SendDigitalReceipt(int orderId, string customerContact);
        void LogActivity(string activityType, string description);
    }

}
