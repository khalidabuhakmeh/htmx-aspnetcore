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
                    Disabled = true
                });
                
                return items;
            }
        }

        [BindProperty(SupportsGet = true)]
        public string? Cuisine { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? Food { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnGetFoods()
        {
            var html = new StringBuilder();
            if (Cuisine is { Length: > 0 } cuisine && cuisines.TryGetValue(cuisine, out var foods))
            {
                html.AppendLine("<option disabled selected>Select a food</option>");
                foreach (var food in cuisines[Cuisine!]) 
                {
                    html.AppendLine($"<option>{food}</option>");
                }    
            }

            return Content(html.ToString(), "text/html");
        }

        public IActionResult OnGetLove()
        {
            return Content($"<span><i class=\"fa fa-heart\"></i> I love {Food}!</span>");
        }
    }
}