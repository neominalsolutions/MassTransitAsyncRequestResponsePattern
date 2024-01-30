
using MassTransit;
using Contracts.Products;

namespace ProductAPI.Consumers
{
    public class GetProductRequestConsumer : IConsumer<GetOrderedProductsRequest>
  {
    public async Task Consume(ConsumeContext<GetOrderedProductsRequest> context)
    {
      await context.RespondAsync(new GetOrderedProductsResponse
      {
        Products = new List<ProductView>
        {
         new ProductView
         {
           ProductName = "Product-1",
           ProductId = new Guid("5cd816e8-4a27-45b8-8bb2-e5d846844629"),
           UnitPrice = 15
         },
         new ProductView
         {
           ProductName = "Product-2",
           ProductId = new Guid("a805e23e-c6e1-4712-9e27-104605aa9bf3"),
           UnitPrice = 15
         }
        }
      });
    }
  }
}
