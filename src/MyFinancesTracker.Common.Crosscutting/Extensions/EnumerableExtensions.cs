namespace MyFinancesTracker.Common.Crosscutting.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T[]> Chunk<T>(this IEnumerable<T> source, int chunkSize)
    {
        return source
            .Select((value, index) => (index, value))
            .GroupBy(t => t.index / chunkSize)
            .Select(g => g.Select(t => t.value).ToArray())
            .ToList();
    }

    public static async ValueTask<IEnumerable<TResult>> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, ValueTask<TResult>> asyncOperation)
    {
        var result = new List<TResult>();
        foreach (var entity in source)
        {
            result.Add(await asyncOperation(entity));
        }

        return result;
    }
}
