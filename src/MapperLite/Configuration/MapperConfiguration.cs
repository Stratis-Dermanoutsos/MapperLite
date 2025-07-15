using System.Linq.Expressions;
using MapperLite.Abstractions;

namespace MapperLite.Configuration;

public class MapperConfiguration
{
    private readonly Dictionary<(Type, Type), Delegate> _mappings = [];
    private readonly Dictionary<(Type, Type), LambdaExpression> _projections = [];

    /// <summary>
    /// Creates a mapping from <typeparamref name="TSource"/> to <typeparamref name="TDestination"/>.
    /// </summary>
    /// <typeparam name="TSource">The source type to map from.</typeparam>
    /// <typeparam name="TDestination">Class implementing <see cref="IReadMapper{TSource, TDestination}"/>.</typeparam>
    public void CreateMapFrom<TSource, TDestination>()
        where TSource : class
        where TDestination : class, IReadMapper<TSource, TDestination>
    {
        CheckDuplicateMappingWithThrow<TSource, TDestination>();

        // Register FromSource delegate
        _mappings[(typeof(TSource), typeof(TDestination))] =
            (Func<TSource, TDestination>)TDestination.FromSource;

        // Register Projection Expression
        _projections[(typeof(TSource), typeof(TDestination))] =
            TDestination.Projection;
    }

    /// <summary>
    /// Creates a partial mapping from <typeparamref name="TSource"/> to <typeparamref name="TDestination"/>.
    /// <br />
    /// By partial, we mean that the mapping will merge the source into the destination instead of creating a new instance.
    /// </summary>
    /// <typeparam name="TSource">The source type to map from.</typeparam>
    /// <typeparam name="TDestination">Class implementing <see cref="IUpdateMapper{TDestination}"/>.</typeparam>
    public void CreateMapPartial<TSource, TDestination>()
        where TSource : class, IUpdateMapper<TDestination>
        where TDestination : class
    {
        CheckDuplicateMappingWithThrow<TSource, TDestination>();

        // Register factory using MergeWithSource
        _mappings[(typeof(TSource), typeof(TDestination))] =
            (Func<TSource, TDestination, TDestination>)((src, dest) => src.MergeWithSource(dest));
    }

    /// <summary>
    /// Creates a mapping from <typeparamref name="TSource"/> to <typeparamref name="TDestination"/>.
    /// </summary>
    /// <typeparam name="TSource">Class implementing <see cref="ICreationMapper{TDestination}"/>.</typeparam>
    /// <typeparam name="TDestination">The source type to map to.</typeparam>
    public void CreateMapTo<TSource, TDestination>()
        where TSource : class, ICreationMapper<TDestination>
        where TDestination : class
    {
        CheckDuplicateMappingWithThrow<TSource, TDestination>();

        _mappings[(typeof(TSource), typeof(TDestination))] =
            (Func<TSource, TDestination>)(src => src.ToSource());
    }

    public Func<TSource, TDestination>? GetMap<TSource, TDestination>()
    {
        if (_mappings.TryGetValue((typeof(TSource), typeof(TDestination)), out var del)
            && del is Func<TSource, TDestination> func)
        {
            return func;
        }

        return null;
    }

    public Func<TSource, TDestination, TDestination>? GetMapPartial<TSource, TDestination>()
    {
        if (_mappings.TryGetValue((typeof(TSource), typeof(TDestination)), out var del)
            && del is Func<TSource, TDestination, TDestination> func)
        {
            return func;
        }

        return null;
    }

    public Expression<Func<TSource, TDestination>>? GetProjection<TSource, TDestination>()
        where TSource : class
        where TDestination : class
    {
        if (_projections.TryGetValue((typeof(TSource), typeof(TDestination)), out var expr))
        {
            return expr as Expression<Func<TSource, TDestination>>;
        }

        return null;
    }

    /// <summary>
    /// Checks if a mapping from <typeparamref name="TSource"/> to <typeparamref name="TDestination"/> already exists.
    /// </summary>
    /// <typeparam name="TSource">The source type to map from.</typeparam>
    /// <typeparam name="TDestination">The destination type to map to.</typeparam>
    /// <exception cref="InvalidOperationException">Thrown if a mapping already exists.</exception>
    private void CheckDuplicateMappingWithThrow<TSource, TDestination>()
        where TSource : class
        where TDestination : class
    {
        if (_mappings.ContainsKey((typeof(TSource), typeof(TDestination))))
        {
            throw new InvalidOperationException($"A map from {typeof(TSource)} to {typeof(TDestination)} is already registered.");
        }
    }
}
