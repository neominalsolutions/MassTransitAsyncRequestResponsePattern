using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Orders.GetOrderById
{
    public class GetOrderByIdErrorResponse
    {
        public string Message { get; set; } = "Order is Not Found";

    }
}
