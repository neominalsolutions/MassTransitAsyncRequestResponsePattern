using Contracts.Orders.GetOrderById;
using MassTransit;
using MassTransit.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReportingAPI.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {

    // IRequestClient interface ile Request atılacak olan contract için bir tanımlama yapılır.
    private readonly IRequestClient<GetOrderByIdRequest> orderApiClient;


    public OrdersController(IRequestClient<GetOrderByIdRequest> orderApiClient)
    {
      this.orderApiClient = orderApiClient;
    }


    [HttpGet]
    public async Task<IActionResult> GetOrderedProducts(Guid orderId)
    {

      var request = new GetOrderByIdRequest { OrderId = orderId };

      // async responselar success yada fail dönebilir
      // Her bir async request için success ve error response nesneleri tanımlanmalıdır. 
      var orderResponse = await this.orderApiClient.GetResponse<GetOrderByIdSuccessResponse, GetOrderByIdErrorResponse>(request);


      if(orderResponse.Is(out Response<GetOrderByIdErrorResponse> errorRes))
      {
        return StatusCode(500, errorRes.Message);
      }

      return Ok(orderResponse.Message);
      
    }
  }
}
