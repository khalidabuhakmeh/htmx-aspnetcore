namespace JetSwagStore.Models;

public class OrderItem
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Manufacturer { get; set; } = "";
    public string ProductOptionName { get; set; } = "";

    public double Price { get; set; }
    public int Amount { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    
    // products can eventually disappear
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
}