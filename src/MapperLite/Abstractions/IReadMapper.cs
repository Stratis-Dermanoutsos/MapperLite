using System.Linq.Expressions;

namespace MapperLite.Abstractions;

public interface IReadMapper<TSource, TSelf>
    where TSource : class
    where TSelf : IReadMapper<TSource, TSelf>
{
    static abstract Expression<Func<TSource, TSelf>> Projection { get; }
    static abstract TSelf FromSource(TSource source);
}
