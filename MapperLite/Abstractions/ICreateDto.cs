namespace MapperLite.Abstractions;

public interface ICreateDto<out TSource>
    where TSource : class
{
    TSource ToSource();
}
