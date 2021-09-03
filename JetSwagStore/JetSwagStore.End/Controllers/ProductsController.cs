using Microsoft.AspNetCore.Mvc;

namespace JetSwagStore.Controllers;

[Route("[controller]")]
public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}