namespace JetSwagStore.Models.Home;

public class IndexViewModel
{
    public IndexViewModel(List<ProductViewModel> results, Category? category, string? query)
    {
        Category = category;
        Query = query;
        Results = results;
    }

    public string CategoryDisplay => Category is not null ? Category.Name : "All Products";
    public bool HasQuery => !string.IsNullOrWhiteSpace(Query);
    
    public string? Query { get; }
    public Category? Category { get; }
    public IEnumerable<ProductViewModel> Results { get; }
}