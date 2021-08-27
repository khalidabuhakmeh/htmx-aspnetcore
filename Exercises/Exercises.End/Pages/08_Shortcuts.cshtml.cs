using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class Shortcuts : PageModel
    {
        private const string ApiUrl =
            "https://www.forbes.com/forbesapi/thought/uri.json?enrich=false&query=1&relatedlimit=0";

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetHelp([FromServices] HttpClient http)
        {
            var json = await http.GetStringAsync(ApiUrl);
            var result = JsonNode.Parse(json);

            return Partial("_Toast", new Quote(
                    result?["thought"]?["thoughtAuthor"]?["name"]?.ToString() ?? "",
                    result?["thought"]?["quote"]?.ToString() ?? ""
                )
            );
        }

        public record Quote(string Author, string Text);
    }
}