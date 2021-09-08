namespace JetSwagStore.Models.Components.Categories;

public class CategoriesViewModel
{
    public IEnumerable<CategoryViewModel> Results { get; set; }
        = Array.Empty<CategoryViewModel>();
}