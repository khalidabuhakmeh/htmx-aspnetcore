using System.Linq;

namespace JetSwagStore.Models.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> If<T>(
        this IQueryable<T> query, 
        bool should,
        params Func<IQueryable<T>, IQueryable<T>>[] transforms)
    {
        return should 
            ? transforms.Aggregate(query,
                (current, transform) => transform.Invoke(current)) 
            : query;
    }

    public static IEnumerable<T> If<T>(
        this IEnumerable<T> query,
        bool should,
        params Func<IEnumerable<T>, IEnumerable<T>>[] transforms)
    {
        return should 
            ? transforms.Aggregate(query,
                (current, transform) => transform.Invoke(current)) 
            : query;
    }
}