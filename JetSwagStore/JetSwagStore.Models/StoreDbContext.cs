using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JetSwagStore.Models;

public class StoreDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlite("Data Source=store.db")
            .LogTo(Console.WriteLine);

    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // case insentive
        modelBuilder.Entity<Product>().Property(c => c.Name).UseCollation("NOCASE");
        modelBuilder.Entity<Product>().Property(c => c.Description).UseCollation("NOCASE");
        
        modelBuilder.Entity<Category>()
            .HasData(
                new Category {Id = 1, Name = ".NET", Sort = 1},
                new Category {Id = 2, Name = "Other", Sort = 5},
                new Category {Id = 3, Name = "Web", Sort = 2 },
                new Category {Id = 4, Name = "Java", Sort = 3 },
                new Category {Id = 5, Name = "Performance", Sort = 4 }
            );
        
        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Rider T-Shirt",
                    Description =
                        "JetBrains Rider, the premiere IDE for .NET developers. Show folks your love for Rider with this stylish T-Shirt.",
                    Manufacturer = "JetBrains",
                    ImageUrl = "Rider.jpg",
                    Price = 35
                },
                new Product
                {
                    Id = 2,
                    Name = "AppCode T-Shirt",
                    Description =
                        "AppCode for building your iOS applications without the need for XCode. Looking so swift in this cotton shirt.",
                    Manufacturer = "JetBrains", Price = 35, CurrentInventory = 100,
                    ImageUrl = "AppCode.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "DataGrip T-Shirt",
                    Description =
                        "Look stylish in this 100% cotton T-Shirt while dropping tables like a boss. DataGrip users represent!",
                    Manufacturer = "JetBrains", Price = 40, CurrentInventory = 100,
                    ImageUrl = "DataGrip.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "DotMemory T-Shirt",
                    Description =
                        "Allocate a few dollars to your style while finding pesky memory leaks in this one-of-a-kind T-Shirt.",
                    Manufacturer = "JetBrains", Price = 30, CurrentInventory = 100,
                    ImageUrl = "DotMemory.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "DotPeek T-Shirt",
                    Description =
                        "Be sure to add this to your clothes library. You'll have everyone taking a peek at this stylish T-shirt.",
                    ImageUrl = "DotPeek.jpg",
                    Manufacturer = "JetBrains",
                    Price = 40,
                    CurrentInventory = 100
                },
                new Product
                {
                    Id = 6,
                    Name = "DotTrace T-Shirt",
                    Description =
                        "The snug fit T-Shirt will trace around your physique perfectly. One of the most comfortable shirts you'll own.",
                    Manufacturer = "JetBrains", Price = 30, CurrentInventory = 100,
                    ImageUrl = "DotTrace.jpg"
                },
                new Product
                {
                    Id = 7,
                    Name = "IntelliJ T-Shirt",
                    Description = "Look Intelli-cute in this 100% cotton T-Shirt. Java never looked this good.",
                    Manufacturer = "JetBrains", Price = 40, DiscountPrice = 30,
                    ImageUrl = "IntelliJ.jpg"
                },
                new Product
                {
                    Id = 8,
                    Name = "ReSharper T-Shirt",
                    Description =
                        "Not only C#, but look sharp in this forward-thinking design. Stand-out in this beautifully crafted attire.",
                    Manufacturer = "JetBrains", Price = 40, DiscountPrice = 30, CurrentInventory = 100,
                    ImageUrl = "ReSharper.jpg"
                },
                new Product
                {
                    Id = 9,
                    Name = "WebStorm T-Shirt",
                    Description =
                        "Storm the web scene with this one-of-a-kind outfit. Import this T-shirt into your collection right away.",
                    Manufacturer = "JetBrains", Price = 30, CurrentInventory = 100,
                    ImageUrl = "WebStorm.jpg"
                }
            );

        modelBuilder.Entity("CategoryProduct")
            .HasData(
                new {ProductsId = 1, CategoriesId = 1},
                new {ProductsId = 2, CategoriesId = 2},
                new {ProductsId = 3, CategoriesId = 2},
                new {ProductsId = 4, CategoriesId = 1},
                new {ProductsId = 4, CategoriesId = 5},
                new {ProductsId = 5, CategoriesId = 1},
                new {ProductsId = 6, CategoriesId = 1},
                new {ProductsId = 6, CategoriesId = 5},
                new {ProductsId = 7, CategoriesId = 4},
                new {ProductsId = 8, CategoriesId = 1},
                new {ProductsId = 8, CategoriesId = 5},
                new {ProductsId = 9, CategoriesId = 3}
            );

        modelBuilder
            .Entity<ProductOption>()
            .HasData(
                // Rider options
                new() {Id = 1, Name = "Small", CurrentInventory = 20, ProductId = 1},
                new() {Id = 2, Name = "Medium", CurrentInventory = 20, ProductId = 1},
                new() {Id = 3, Name = "Large", CurrentInventory = 20, AdditionalCost = 5, ProductId = 1},
                new() {Id = 4, Name = "X-Large", CurrentInventory = 20, AdditionalCost = 10, ProductId = 1},
                new() {Id = 5, Name = "XX-Large", CurrentInventory = 20, AdditionalCost = 20, ProductId = 1},
                // IntelliJ
                new() {Id = 6, Name = "Small", CurrentInventory = 20, ProductId = 7},
                new() {Id = 7, Name = "Medium", CurrentInventory = 20, ProductId = 7},
                new() {Id = 8, Name = "Large", CurrentInventory = 20, AdditionalCost = 5, ProductId = 7},
                new() {Id = 9, Name = "X-Large", CurrentInventory = 20, AdditionalCost = 10, ProductId = 7},
                new() {Id = 10, Name = "XX-Large", CurrentInventory = 20, AdditionalCost = 20, ProductId = 7}
            );
    }

    public async Task<ShoppingCart?> FindShoppingCart(int id)
    {
        return await ShoppingCarts
            .Include(s => s.Items)
            .ThenInclude(i => i.Product)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }
}