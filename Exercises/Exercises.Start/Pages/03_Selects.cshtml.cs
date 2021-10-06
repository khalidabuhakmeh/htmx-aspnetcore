using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exercises.Pages
{
    public class Selects : PageModel
    {
        private readonly Dictionary<string, List<string>> cuisines =
            new()
            {
                {"Italian", new List<string> {"Spaghetti", "Pizza", "Lasagna"}},
                {"Mexican", new List<string> {"Tacos", "Enchiladas", "Churros"}},
                {"American", new List<string> {"Burgers", "Hot dogs", "Barbeque"}}
            };

        public IList<SelectListItem> CuisineItems
        {
            get
            {
                var items = cuisines.Keys
                    .Select(c => new SelectListItem(c, c))
                    .ToList();
                
                items.Insert(0, new SelectListItem("Choose an option", "") {
                    Disabled = true,
                    Selected = true
                });
                
                return items;
            }
        }
        
        // TODO: Add Parameters

        public void OnGet()
        {
        }

        public IActionResult OnGetFoods()
        {
            var html = new StringBuilder();
            
            // Todo: Generate Options

            return Content(html.ToString(), "text/html");
        }

        public IActionResult OnGetLove()
        {
            // Todo: Return Span
            
            return Content($"");
        }
    }
}