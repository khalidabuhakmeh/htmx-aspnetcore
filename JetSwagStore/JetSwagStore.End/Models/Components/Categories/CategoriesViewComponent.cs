using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JetSwagStore.Models.Components.Categories;

public class CategoriesViewComponent : ViewComponent
{
    private readonly StoreDbContext _db;

    public CategoriesViewComponent(StoreDbContext db)
    {
        _db = db;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = new CategoriesViewModel
        {
            Results = await
                _db
                    .Categories
                    .Select(c => new CategoryViewModel
                    {
                        Name = c.Name,
                        TotalProductCount = c.Products.Count
                    })
                    .ToListAsync()
        };
        
        return View("Categories", model);
    }
}