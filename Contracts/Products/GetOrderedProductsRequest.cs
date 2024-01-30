using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Products
{
    public class GetOrderedProductsRequest
  {
        public Guid[] ProductIds { get; set; }

    }
}
