using System.Collections.Generic;
using System.Security.Cryptography;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class Polling : PageModel
    {
        public List<Stonk> Companies { get; set; }
            = new() {
                new Stonk("Apple", "apple", 100, 100),
                new Stonk("Empire", "empire", 800, 1000),
                new Stonk("Rebel", "rebel", 10, 10)
            };

        public IActionResult OnGet()
        {
            foreach (var company in Companies) {
                company.CurrentPrice += RandomNumberGenerator.GetInt32(-10, 10);
            }

            return Request.IsHtmx()
                ? Partial("_Stonks", this)
                : Page();
        }
    }
    
    public class Stonk
    {
        public Stonk(string name, string icon, decimal currentPrice, decimal openingPrice)
        {
            Name = name;
            Icon = icon;
            CurrentPrice = currentPrice;
            OpeningPrice = openingPrice;
        }

        public bool IsUp => CurrentPrice - OpeningPrice >= 0;
        public string Name { get; init; }
        public string Icon { get; init; }
        public decimal CurrentPrice { get; set; }
        public decimal OpeningPrice { get; init; }
    }
}