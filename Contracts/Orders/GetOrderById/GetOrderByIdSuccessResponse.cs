using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Orders.GetOrderById
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal ListPrice { get; set; }
    }


    public class GetOrderByIdSuccessResponse
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
