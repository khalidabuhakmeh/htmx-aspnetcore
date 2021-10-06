using System.Linq;
using Microsoft.AspNetCore.Html;

namespace JetSwagStore.Models.Home;

public class ProductViewModel
{
    public Product Info { get; set; } = null!;
    
    public bool IsOnSale => Info.DiscountPrice.HasValue;
    public bool HasOptions => Info.Options.Any();
    public bool ShouldRenderCartButton { get; set; }

    public HtmlString PriceDisplay
    {
        get
        {
            if (HasOptions)
            {
                var price = IsOnSale ? Info.DiscountPrice : Info.Price;
                var prices = Info.Options.Select(p => price + p.AdditionalCost).ToList();
                var min = prices.Min();
                var max = prices.Max();

                return new HtmlString($"${min:###.00} - ${max:###.00}");
            }

            return IsOnSale
                ? new HtmlString($"<span class=\"text-muted text-decoration-line-through\">${Info.Price:###.00}</span> ${Info.DiscountPrice:###.00}")
                : new HtmlString($"${Info.Price:###.00}");
        }
    }
}