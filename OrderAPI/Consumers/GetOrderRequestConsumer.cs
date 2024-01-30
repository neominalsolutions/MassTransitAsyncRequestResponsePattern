using Contracts.Orders;
using MassTransit;

namespace OrderAPI.Consumers
{
    public class GetOrderRequestConsumer : IConsumer<GetOrderRequest>
  {
    public async Task Consume(ConsumeContext<GetOrderRequest> context)
    {

      if(context.Message.OrderId != new Guid("9a967ee1-d1e0-4c05-afae-d01bd9aa507a"))
      {
        await context.RespondAsync(new OrderNotFoundResponse());
      }


      await context.RespondAsync(new GetOrderSuccessResponse
      {
        OrderId = context.Message.OrderId,
        OrderDate = DateTime.Now,
        OrderItems = new List<OrderItemView>
        {
          new OrderItemView
          {
            ListPrice = 10,
            ProductId = new Guid("5cd816e8-4a27-45b8-8bb2-e5d846844629"),
            Quantity = 3
          },
           new OrderItemView
          {
            ListPrice = 100,
            ProductId = new Guid("a805e23e-c6e1-4712-9e27-104605aa9bf3"),
            Quantity = 2
          }
        }

      });
      
    }
  }
}
