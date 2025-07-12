namespace MapperLite;

public interface IMapper
{
    TDestination Map<TDestination>(object source)
        where TDestination : class;

    TDestination Map<TSource, TDestination>(TSource source)
        where TSource : class
        where TDestination : class;

    TDestination MapPartial<TSource, TDestination>(TSource source, TDestination destination)
        where TSource : class
        where TDestination : class;
}
