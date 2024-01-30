namespace ProductAPI.Models
{
  public class Product
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public short Stock { get; set; }

  }
}
