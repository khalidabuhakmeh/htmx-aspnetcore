namespace JetSwagStore.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Sort { get; set; } = 10_000;

    public ICollection<Product> Products { get; set; }
        = new List<Product>();
}