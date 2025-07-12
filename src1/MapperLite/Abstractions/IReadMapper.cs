namespace MapperLite.Abstractions;

public interface IReadMapper<in TSource, out TSelf>
    where TSource : class
    where TSelf : IReadMapper<TSource, TSelf>
{
    static abstract TSelf FromSource(TSource source);
}
