using MapperLite.Configuration;

namespace MapperLite;

public class Mapper(MapperConfiguration config) : IMapper
{
    public IEnumerable<TDestination> MapMany<TDestination>(IEnumerable<object> source)
        where TDestination : class
    {
        ArgumentNullException.ThrowIfNull(source);

        var enumerable = source as object[] ?? [.. source];

        return enumerable.Length == 0 ? [] : enumerable.Select(Map<TDestination>);
    }

    public TDestination Map<TDestination>(object? source)
        where TDestination : class
    {
        ArgumentNullException.ThrowIfNull(source);

        var sourceType = source.GetType();

        // Find the Map<TSource, TDestination>(TSource source) method
        var mapMethod = typeof(Mapper)
            .GetMethods()
            .FirstOrDefault(m =>
                m is { Name: nameof(Map), IsGenericMethodDefinition: true }
                && m.GetGenericArguments().Length == 2
                && m.GetParameters().Length == 1)
                        ?? throw new InvalidOperationException("Could not find generic Map<TSource, TDestination> method.");

        var genericMethod = mapMethod.MakeGenericMethod(sourceType, typeof(TDestination));

        return (TDestination?)genericMethod.Invoke(this, [source])
               ?? throw new InvalidOperationException($"Mapping from {sourceType} to {typeof(TDestination)} returned null.");
    }

    public IEnumerable<TDestination> MapMany<TSource, TDestination>(IEnumerable<TSource> source)
        where TSource : class
        where TDestination : class
    {
        return source.Select(Map<TSource, TDestination>);
    }

    public TDestination Map<TSource, TDestination>(TSource? source)
        where TSource : class
        where TDestination : class
    {
        ArgumentNullException.ThrowIfNull(source);

        var mapFunc = config.GetMap<TSource, TDestination>()
                      ?? throw new InvalidOperationException($"No mapping found from {typeof(TSource)} to {typeof(TDestination)}.");

        return mapFunc(source);
    }

    public TDestination MapPartial<TSource, TDestination>(TSource source, TDestination destination)
        where TSource : class
        where TDestination : class
    {
        var mapFunc = config.GetMapPartial<TSource, TDestination>()
                      ?? throw new InvalidOperationException($"No mapping found from {typeof(TSource)} to {typeof(TDestination)}.");

        return mapFunc(source, destination);
    }
}
