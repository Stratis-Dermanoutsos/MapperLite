namespace MapperLite.Abstractions;

public interface IUpdateDto<TSource>
    where TSource : class
{
    TSource MergeWithSource(TSource source);
}
