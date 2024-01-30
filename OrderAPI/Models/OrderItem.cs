namespace OrderAPI.Models
{
  public class OrderItem
  {
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

  }
}
