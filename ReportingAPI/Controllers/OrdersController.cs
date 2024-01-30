
using Contracts.Orders;
using Contracts.Products;
using MassTransit;
using MassTransit.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportingAPI.Dtos;

namespace ReportingAPI.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {

    private readonly IRequestClient<GetOrderRequest> orderApiClient;
    private readonly IRequestClient<GetOrderedProductsRequest> productApiClient;

    public OrdersController(IRequestClient<GetOrderRequest> orderApiClient, IRequestClient<GetOrderedProductsRequest> productApiClient)
    {
      this.orderApiClient = orderApiClient;
      this.productApiClient = productApiClient;
    }


    [HttpGet]
    public async Task<IActionResult> GetOrderedProducts(Guid orderId)
    {

      var response = new OrderedProductsDto();

      var orderResponse = await this.orderApiClient.GetResponse<GetOrderSuccessResponse, OrderNotFoundResponse>(new GetOrderRequest
      {
        OrderId = orderId
      });

      if(orderResponse.Is(out Response<OrderNotFoundResponse> res))
      {
        return StatusCode(500, res.Message);
      }
      else if(orderResponse.Is(out Response<GetOrderSuccessResponse> res1))
      {
        var productIds = res1.Message.OrderItems.Select(x => x.ProductId).ToList();

        var productResponse = await this.productApiClient.GetResponse<GetOrderedProductsResponse>(new GetOrderedProductsRequest
        {
          ProductIds = productIds.ToArray()
        });



        response.OrderId = orderId;
        response.OrderDate = res1.Message.OrderDate;
        response.Products = res1.Message.OrderItems.Select(a => new OrderedProductDto
        {
          ProductName = productResponse.Message.Products.FirstOrDefault(x => x.ProductId == a.ProductId).ProductName,
          ListPrice = res1.Message.OrderItems.FirstOrDefault(x => x.ProductId == a.ProductId).ListPrice
        }).ToList();
  
      }

      return Ok(response);


    }
  }
}
