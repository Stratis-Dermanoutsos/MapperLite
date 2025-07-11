namespace MapperLite.Abstractions;

public interface IReadDto<in TSource, out TSelf>
    where TSource : class
    where TSelf : IReadDto<TSource, TSelf>
{
    static abstract TSelf FromSource(TSource source);
}
