using MapperLite.Abstractions;
using MapperLite.Configuration;

namespace MapperLite.Extensions;

public static class Queryable
{
    public static IQueryable<TDestination> ProjectTo<TSource, TDestination>(
        this IQueryable<TSource> source,
        MapperConfiguration config)
        where TSource : class
        where TDestination : class, IReadMapper<TSource, TDestination>
    {
        var projection = config.GetProjection<TSource, TDestination>()
                         ?? throw new InvalidOperationException("No projection mapping registered.");

        return source.Select(projection);
    }
}
