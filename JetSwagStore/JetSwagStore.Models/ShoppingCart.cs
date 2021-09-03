namespace JetSwagStore.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } 
        = DateTime.UtcNow;
    public ICollection<ShoppingCartItem> Items { get; set; }
        = new List<ShoppingCartItem>();
}