using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class TagHelpers : PageModel
    {
        public IActionResult OnGet()
        {
            return Request.IsHtmx()
                ? Content("<span>Hello, World with Tag Helpers!</span>", "text/html")
                : Page();
        }
    }
}