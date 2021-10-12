using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class HelloWorld : PageModel
    {
        public IActionResult OnGet()
        {
            return Request.IsHtmx()
                // Todo: <span>Hello, World!</span>
                ? Content("", "text/html")
                : Page();
        }
    }
}