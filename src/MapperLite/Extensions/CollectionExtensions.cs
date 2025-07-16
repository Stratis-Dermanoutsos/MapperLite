using System.Linq.Expressions;
using LinqKit;
using MapperLite.Abstractions;

namespace MapperLite.Extensions;

public static class CollectionExtensions
{
    /// <summary>
    /// Creates a projection for the source collection to a list of <typeparamref name="TDestination"/> using the projection defined in <typeparamref name="TDestination"/>.
    /// </summary>
    /// <remarks>Works only for in-memory projections. EF Core does not support extension methods when creating SQL commands.</remarks>
    /// <param name="source">The source collection to project.</param>
    /// <typeparam name="TSource">The source type.</typeparam>
    /// <typeparam name="TDestination">The resulting type that implements <see cref="IReadMapper{TSource, TDestination}"/>.</typeparam>
    /// <returns>A list of projected <typeparamref name="TDestination"/> instances.</returns>
    public static List<TDestination> AsProjection<TSource, TDestination>(
        this IEnumerable<TSource> source)
        where TSource : class
        where TDestination : class, IReadMapper<TSource, TDestination>
    {
        ArgumentNullException.ThrowIfNull(source);

        return [.. source.AsQueryable().Select(TDestination.Projection.Expand())];
    }
}
