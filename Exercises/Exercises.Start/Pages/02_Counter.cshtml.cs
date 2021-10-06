using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class Counter : PageModel
    {
        private static int count = 0;
        
        public void OnGet()
        {
            // reset on refresh
            count = 0;
        }

        public IActionResult OnPost()
        {
            // TODO: Increment the count on each request
            return Content($"<span></span>", "text/html");
        }
    }
}