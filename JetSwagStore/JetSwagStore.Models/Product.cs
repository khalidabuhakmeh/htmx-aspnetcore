namespace JetSwagStore.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Manufacturer { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public double Price { get; set; }
    public double? DiscountPrice { get; set; }
    public int? CurrentInventory { get; set; }

    public ICollection<ProductOption> Options { get; set; }
        = new List<ProductOption>();

    public ICollection<Category> Categories { get; set; }
        = new List<Category>();
}