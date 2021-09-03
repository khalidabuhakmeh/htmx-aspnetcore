using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Htmx;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Westwind.AspNetCore.Markdown.Utilities;

namespace Exercises.Pages
{
    public class Search : PageModel
    {
        private static List<Game> Games = new()
        {
            new (1993, "Super Mario Bros. 3", "Nintendo", "NES"),
            new (1992, "The Legend of Zelda: A Link To The Past", "Nintendo", "SNES"),
            new (1992, "Street Fighter II Turbo", "Capcom", "Arcade"),
            new (1992, "Sonic The Hedgehog 2", "Sega", "Mega Drive"),
            new (1986, "Outrun", "Sega", "Arcade"),
            new (1978, "Space Invaders", "Taito", "Arcade"),
            new (1992, "Streets Of Rage 2", "Sega", "Mega Drive"),
            new (1994, "Super Metroid", "Nintendo", "SNES"),
            new (1972, "Pong", "Atari", "Atari"),
            new (1996, "Resident Evil", "Capcom", "Playstation"),
            new (1995, "Chrono Trigger", "Squaresoft", "SNES")
        };
        
        [BindProperty(SupportsGet = true)]
        public string? Query { get; set; }

        public List<Game> Results { get; private set; }
            = Games;

        public IActionResult OnGet()
        {
            Results = string.IsNullOrEmpty(Query)
                ? Games
                : Games.Where(g => g.ToString().Contains(Query, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!Request.IsHtmx()) 
                return Page();
            
            Response.Htmx(h => {
                // we want to push the current url 
                // into the history
                h.Push(Request.GetEncodedUrl());
            });

            return Partial("_Results", this);
        }
    }

    public record Game(int Year, string Name, string Publisher, string Console);
}