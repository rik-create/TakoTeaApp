using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Model;

namespace TakoTea.Dashboard.Dashboard_Modals
{
    public partial class OrderQueueForm : MaterialForm
    {
        private OrderQueue orderQueue;

        public OrderQueueForm(OrderQueue queue)
        {
            InitializeComponent();
            orderQueue = queue;
            LoadOrderQueue();
        }

        private void LoadOrderQueue()
        {
            listViewOrders.Items.Clear();
            foreach (var order in orderQueue.GetAllOrders())
            {
                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                item.SubItems.Add(order.CustomerName);
                item.SubItems.Add(order.Product);
                item.SubItems.Add(order.Size);
                item.SubItems.Add(order.Quantity.ToString());
                item.SubItems.Add(string.Join(", ", order.Addons));
                item.SubItems.Add(order.Status);
                item.SubItems.Add(order.OrderTime.ToString("HH:mm:ss"));

                listViewOrders.Items.Add(item);
            }
        }

        private async void ProcessOrder(OrderModel order)
        {
            order.Status = "In Progress";
            // Simulate order preparation time
            await Task.Delay(TimeSpan.FromSeconds(5)); // Simulating a delay for order preparation
            order.Status = "Completed";
            // Update the UI or notify the customer about the completed order
        }

        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            if (orderQueue.Count > 0)
            {
                OrderModel order = orderQueue.DequeueOrder();
                order.Status = "In Progress";
                LoadOrderQueue(); // Refresh the list
                                  // Here you can also add code to start processing the order
            }
            else
            {
                MessageBox.Show("No orders to process.");
            }
        }

        // Implement additional buttons to mark orders as completed or update their statuses
    }

    public class OrderQueue
    {
        private Queue<OrderModel> orders = new Queue<OrderModel>();

        public void EnqueueOrder(OrderModel order)
        {
            orders.Enqueue(order);
        }

        public OrderModel DequeueOrder()
        {
            return orders.Count > 0 ? orders.Dequeue() : null;
        }

        public int Count => orders.Count;


        // Method to get all orders in the queue
        public List<OrderModel> GetAllOrders()
        {
            return new List<OrderModel>(orders);
        }
    }

}
