using JetSwagStore.Models;
using JetSwagStore.Models.Cart;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews(options => {
        // will get the cart once we've executed an action
        options.Filters.Add<ShoppingCartViewModelFilter>();
    })
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<StoreDbContext>();
builder.Services.AddShoppingCart();

var app = builder.Build();

// migrate to latest database version
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseShoppingCart();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();