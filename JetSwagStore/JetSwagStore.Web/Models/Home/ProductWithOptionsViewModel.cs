using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JetSwagStore.Models.Home;

public class ProductWithOptionsViewModel : ProductViewModel
{
    public int ProductId => Info.Id;
    
    [Display(Name = "Options")]
    public int? ProductOptionId { get; set; }
    public IEnumerable<SelectListItem> Options =>
        Info.Options.Select(i => new SelectListItem(i.Name, i.Id.ToString())).ToList();
    public bool InstantlyShowModal { get; set; }

    public HtmlString CurrentOptionPriceDisplay
    {
        get
        {
            if (!ProductOptionId.HasValue)
                return base.PriceDisplay;
            
            // selected option
            var item = Info.Options.First(o => o.Id == ProductOptionId);
            var total = (Info.DiscountPrice ?? Info.Price) + item.AdditionalCost;

            return new HtmlString($"${total:###.00}");
        }
    }

    
}