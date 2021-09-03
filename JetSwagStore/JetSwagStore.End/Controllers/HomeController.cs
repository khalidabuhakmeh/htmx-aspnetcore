using System.Diagnostics;
using System.Linq;
using Htmx;
using JetSwagStore.End.Models;
using JetSwagStore.Models;
using JetSwagStore.Models.Extensions;
using JetSwagStore.Models.Home;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JetSwagStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly StoreDbContext db;

    public HomeController(ILogger<HomeController> logger, StoreDbContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    [HttpGet, Route("")]
    public async Task<IActionResult> Index(string? category, string? query)
    {
        Category? categoryRecord = null;
        var hasCategory = false;
        if (!string.IsNullOrWhiteSpace(category)) 
        {
            categoryRecord = await db.Categories.FirstOrDefaultAsync(c => c.Name == category);
            hasCategory = categoryRecord != null;
        }

        var hasQuery = !string.IsNullOrWhiteSpace(query);

        var results =
            await db.Products
                .Include(x => x.Options)
                .If(hasCategory, q => q.Where(p => p.Categories.Contains(categoryRecord!)))
                .If(hasQuery, q => q.Where(p => EF.Functions.Like(p.Name, $"%{query}%") ))
                .Select(p => new ProductViewModel { Info = p })
                .ToListAsync();

        var model = new IndexViewModel(results, categoryRecord, query);
        
        Response.Htmx(h => {
            // we want to push the current url 
            // into the history
            h.Push(Request.GetEncodedUrl());
        });

        return Request.IsHtmx()
            ? PartialView("_Products", model)
            : View(model);
    }

    [HttpGet, Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet, Route("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}