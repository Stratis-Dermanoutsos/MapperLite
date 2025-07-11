namespace MapperLite.Abstractions;

public interface ICreationMapper<out TSource>
    where TSource : class
{
    TSource ToSource();
}
