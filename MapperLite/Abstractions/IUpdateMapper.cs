namespace MapperLite.Abstractions;

public interface IUpdateMapper<TSource>
    where TSource : class
{
    TSource MergeWithSource(TSource source);
}
