using Htmx;
using JetSwagStore.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace JetSwagStore.Models.Cart;

public class ShoppingCartViewModelFilter : ActionFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Controller is Controller controller)
        {
            var db = context.HttpContext.RequestServices.GetRequiredService<StoreDbContext>();
            var currentShoppingCart = context.HttpContext.RequestServices.GetRequiredService<CurrentShoppingCart>();

            var cart = await db.ShoppingCarts.FindAsync(currentShoppingCart.Id);
            if (cart != null)
            {
                var currentCart = new CartViewModel(cart) {
                    //IsHtmxOutOfBandSwap = context.HttpContext.Request.IsHtmx()
                };
                
                controller.ViewData["CurrentCart"] =  currentCart;
            }
        }

        await next();
    }
}