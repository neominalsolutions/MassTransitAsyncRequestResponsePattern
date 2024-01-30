using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Products
{
    public class ProductView
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

    }

    public class GetOrderedProductsResponse
  {
        public List<ProductView> Products { get; set; }
    }
}
