using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Orders
{
    public class OrderItemView
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal ListPrice { get; set; }
    }


    public class GetOrderSuccessResponse
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItemView> OrderItems { get; set; }
    }
}
