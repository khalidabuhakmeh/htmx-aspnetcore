namespace JetSwagStore.Models;

public class ShoppingCartItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int? ProductId { get; set; }
    public int? ProductOptionId { get; set; }
    public Product? Product { get; set; }
    public ProductOption? Option { get; set; }

    public double GetTotalPrice()
    {
        if (Product is null) return 0;
        
        var price = Product.DiscountPrice ?? Product.Price;
        var additionalCost = Option?.AdditionalCost ?? 0;

        return Quantity * (price + additionalCost);
    }
}