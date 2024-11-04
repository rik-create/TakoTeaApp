using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public List<string> Addons { get; set; }
        public string Status { get; set; } // e.g., "Pending", "In Progress", "Completed"
        public DateTime OrderTime { get; set; }
    }
}
