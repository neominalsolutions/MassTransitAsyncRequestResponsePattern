namespace ReportingAPI.Dtos
{
 
  public class OrderedProductsDto
  {
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }

    public List<OrderedProductDto> Products { get; set; }
  }
}
