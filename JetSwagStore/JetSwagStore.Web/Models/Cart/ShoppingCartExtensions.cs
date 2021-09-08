using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace JetSwagStore.Models.Cart;

public static class ShoppingCartExtensions
{
    public static IServiceCollection AddShoppingCart(this IServiceCollection services)
    {
        services.AddScoped<CurrentShoppingCart>();
        services.AddScoped<ShoppingCartMiddleware>();
        
        return services;
    }

    public static IApplicationBuilder UseShoppingCart(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ShoppingCartMiddleware>();
    } 
}