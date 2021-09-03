using System.ComponentModel.DataAnnotations.Schema;

namespace JetSwagStore.Models;

public class ProductOption
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double AdditionalCost { get; set; }
    public int CurrentInventory { get; set; } = 1;
    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;
}