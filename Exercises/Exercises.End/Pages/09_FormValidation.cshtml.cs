using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class FormValidation : PageModel
    {
        [BindProperty, Required]
        public string? Name { get; init; } = string.Empty;

        [BindProperty, Required]
        public int Age { get; init; }

        public async Task<IActionResult> OnPost()
        {
            // see the loading spinner (remove for production)
            await Task.Delay(TimeSpan.FromSeconds(1));
            // handle Htmx request
            return Request.IsHtmx()
                ? Partial("_Form", this)
                : Page();
        }
    }
}