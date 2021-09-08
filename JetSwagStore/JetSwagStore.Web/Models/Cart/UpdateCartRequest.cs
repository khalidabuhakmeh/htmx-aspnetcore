namespace JetSwagStore.Models.Cart;

public class UpdateCartRequest
{
    public int ProductId { get; set; }
    public int? ProductOptionId { get; set; }
    public int Quantity { get; set; }
    public bool Remove { get; set; } 
}