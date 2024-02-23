namespace MyFinancesTracker.Common.Crosscutting.Interfaces;

/// <summary>
/// Defines a creator from source to destination type.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TDestination">The destination type.</typeparam>
public interface ICreator<in TSource, TDestination>
{
    /// <summary>
    /// Creates a destination object based on the source object.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <returns>The created destination object.</returns>
    ValueTask<TDestination> CreateAsync(TSource source);
}
