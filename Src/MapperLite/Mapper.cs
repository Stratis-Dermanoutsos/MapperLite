using MapperLite.Configuration;

namespace MapperLite;

public class Mapper(MapperConfiguration config) : IMapper
{
    public TDestination Map<TDestination>(object source)
        where TDestination : class
    {
        ArgumentNullException.ThrowIfNull(source);

        var sourceType = source.GetType();
        var mapMethod = (typeof(Mapper)
                            .GetMethod(nameof(Map), [ sourceType ]) // look for Map<TSource, TDestination>(TSource source)
                        ?? typeof(Mapper).GetMethods()
                            .FirstOrDefault(m =>
                                m is { Name: nameof(Map), IsGenericMethodDefinition: true }
                                && m.GetParameters().Length == 1
                                && m.GetGenericArguments().Length == 2))
                        ?? throw new InvalidOperationException("Could not find generic Map method.");

        var genericMethod = mapMethod.MakeGenericMethod(sourceType, typeof(TDestination)) ?? throw new InvalidOperationException();
        return (TDestination?)genericMethod.Invoke(this, [source])
               ?? throw new InvalidOperationException($"Mapping from {sourceType} to {typeof(TDestination)} returned null.");
    }

    public TDestination Map<TSource, TDestination>(TSource source)
        where TSource : class
        where TDestination : class
    {
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
