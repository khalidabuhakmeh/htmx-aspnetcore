using Microsoft.AspNetCore.Mvc;

namespace JetSwagStore.Controllers.Admin;

[Area("admin"), Route("[area]/[controller]")]
public class ProductsController : Controller
{
    [Route("[area]")]
    [Route("[area]/[controller]")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}