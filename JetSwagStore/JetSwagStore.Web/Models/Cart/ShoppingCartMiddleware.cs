using JetSwagStore.Models;

namespace JetSwagStore.Models.Cart;

public class ShoppingCartMiddleware : IMiddleware
{
    private readonly StoreDbContext db;
    private readonly CurrentShoppingCart currentShoppingCart;
    private const string ShoppingCartCookie = "__shoppingCart";

    public ShoppingCartMiddleware(StoreDbContext db, CurrentShoppingCart currentShoppingCart)
    {
        this.db = db;
        this.currentShoppingCart = currentShoppingCart;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var id = 0;
        if (!context.Request.Cookies.ContainsKey(ShoppingCartCookie))
        {
            id = await CreateShoppingCart();
        }
        else
        {
            if (context.Request.Cookies.TryGetValue(ShoppingCartCookie, out var result) && int.TryParse(result, out id))
            {
                var cart = await db.ShoppingCarts.FindAsync(id);
                id = cart?.Id ?? await CreateShoppingCart();
            }
        }

        // Will be available through the request
        currentShoppingCart.Id = id; 
        context.Response.Cookies.Append(ShoppingCartCookie, id.ToString());
        await next(context);
    }

    private async Task<int> CreateShoppingCart()
    {
        var cart = new ShoppingCart();
        await db.ShoppingCarts.AddAsync(cart);
        await db.SaveChangesAsync();
        return cart.Id;
    }
}