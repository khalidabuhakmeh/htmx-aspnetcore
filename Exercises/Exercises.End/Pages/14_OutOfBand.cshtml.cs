using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class OutOfBand : PageModel
    {
        public int TotalItemsInCart { get; set; } = 1;
        public bool RenderCartOutOfBand { get; set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPostAddToCart(int count)
        {
            TotalItemsInCart = count;
            RenderCartOutOfBand = true;
            return Partial("_ShoppingItem", this);
        }
    }
    
}