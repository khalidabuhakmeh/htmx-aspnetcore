using Exercises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    /// <summary>
    /// We will be receiving events from the ServerEventsWorker service
    /// about the need to update our UI. We've registered the worker
    /// as a hosted service in our startup file (Program.cs).
    /// <seealso cref="Exercises.Models.ServerEventsWorker"/>
    /// </summary>
    [ResponseCache(Duration = 1 /* second */)]
    public class ServerEvents : PageModel
    {
        public void OnGet()
        {
        }

        public ContentResult OnGetRandom()
        {
            return Content($"<span>{Number.Value}</span>", "text/html");
        }
    }
}