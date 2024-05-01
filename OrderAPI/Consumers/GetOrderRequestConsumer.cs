using Contracts.Orders;
using Contracts.Orders.GetOrderById;
using MassTransit;

namespace OrderAPI.Consumers
{
    public class GetOrderRequestConsumer : IConsumer<GetOrderByIdRequest>
  {
    public async Task Consume(ConsumeContext<GetOrderByIdRequest> context)
    {

      if(context.Message.OrderId != new Guid("9a967ee1-d1e0-4c05-afae-d01bd9aa507a"))
      {
        await context.RespondAsync(new GetOrderByIdErrorResponse());
      }


      await context.RespondAsync(new GetOrderByIdSuccessResponse
      {
        OrderId = context.Message.OrderId,
        OrderDate = DateTime.Now,
        OrderItems = new List<OrderItem>
        {
          new OrderItem
          {
            ListPrice = 10,
            ProductId = Guid.NewGuid(),
            Quantity = 3
          },
           new OrderItem
          {
            ListPrice = 100,
            ProductId = Guid.NewGuid(),
            Quantity = 2
          }
        }

      });
      
    }
  }
}
