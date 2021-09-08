using System.Linq;

namespace JetSwagStore.Models.Home;

public class CartViewModel
{
    public CartViewModel(ShoppingCart cart)
    {
        Items = cart.Items.Select(i => new CartItemViewModel {
            ItemId = i.Id,
            Quantity = i.Quantity,
            ProductId = i.ProductId.GetValueOrDefault(),
            Name = i.Product?.Name ?? string.Empty,
            OptionName = i.Option?.Name,
            OptionId = i.Option?.Id,
            TotalPrice = i.GetTotalPrice(),
            ImageUrl = i.Product?.ImageUrl ?? string.Empty
        }).ToList();
    }
    
    public int TotalItems => Items.Sum(c => c.Quantity);
    public IList<CartItemViewModel> Items { get; }
    public double TotalPrice => Items.Sum(c => c.TotalPrice);
    public CartItemViewModel? HasProduct(int productId) => Items.FirstOrDefault(i => i.ProductId == productId);
    public CartItemViewModel? HasProductOption(int productId, int? optionId) => Items.FirstOrDefault(i => i.ProductId == productId && i.OptionId == optionId);
    public bool HasItems => Items.Any();
}

public class CartItemViewModel
{
    public int ItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? OptionName { get; set; }
    public double TotalPrice { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int? OptionId { get; set; }
}