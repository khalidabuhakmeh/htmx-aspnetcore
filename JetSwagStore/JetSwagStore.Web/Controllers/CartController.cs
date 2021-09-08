using Htmx;
using JetSwagStore.Models;
using JetSwagStore.Models.Cart;
using JetSwagStore.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace JetSwagStore.Controllers;

[Route("[controller]")]
public class CartController : Controller
{
    private readonly StoreDbContext db;
    private readonly CurrentShoppingCart currentShoppingCart;

    public CartController(StoreDbContext db, CurrentShoppingCart currentShoppingCart)
    {
        this.db = db;
        this.currentShoppingCart = currentShoppingCart;
    }

    [HttpPost, Route("")]
    public async Task<IActionResult> Add([FromForm] UpdateCartRequest input)
    {
        if (input.Remove)
        {
            input.Quantity = 0;
        }

        var (product, option) =
            await db.UpdateShoppingCart(
                input.ProductId,
                input.ProductOptionId,
                currentShoppingCart.Id,
                input.Quantity
            );

        if (option is not null)
        {
            return PartialView("_ProductOptions", new ProductWithOptionsViewModel
            {
                Info = product!,
                ProductOptionId = option.Id,
                ShouldRenderCartButton = true,
                InstantlyShowModal = true
            });
        }

        // added via card or view options
        return PartialView("_Product", new ProductViewModel
        {
            Info = product!,
            ShouldRenderCartButton = true
        });
    }

    [HttpPut, Route("")]
    public async Task<IActionResult> Update([FromForm] UpdateCartRequest input)
    {
        if (input.Remove)
        {
            input.Quantity = 0;
        }

        await db.UpdateShoppingCart(
            input.ProductId,
            input.ProductOptionId,
            currentShoppingCart.Id,
            input.Quantity
        );

        // We should update the UI
        var product = await db.Products.FindAsync(input.ProductId);
        var model = new ProductViewModel
        {
            Info = product!,
            ShouldRenderCartButton = true
        };

        return PartialView("_CartItems", model);
    }

    [HttpGet, Route("")]
    public IActionResult Show()
    {
        return PartialView("_CartItems");
    }

    [HttpDelete, Route("")]
    public async Task<IActionResult> Delete()
    {
        var cart = await db.ShoppingCarts.FindAsync(currentShoppingCart.Id);
        cart?.Items.Clear();
        await db.SaveChangesAsync();
        
        // force page to do a complete refresh
        Response.Htmx(htmx => {
            htmx.Refresh();
        });

        return PartialView("_CartItems");
    }
}