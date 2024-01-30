namespace OrderAPI.Models
{
  public class Order
  {
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }

    public List<OrderItem> Items { get; set; }

  }
}
