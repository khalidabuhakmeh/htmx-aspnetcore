using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class ClientsideTemplates : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnGetJson()
        {
            return new JsonResult(new {
                Id = 1,
                Title = "This is Great!",
                Author = "You"
            });
        }
    }
}