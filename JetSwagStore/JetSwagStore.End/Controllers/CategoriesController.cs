using Microsoft.AspNetCore.Mvc;

namespace JetSwagStore.Controllers;

public class CategoriesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
}