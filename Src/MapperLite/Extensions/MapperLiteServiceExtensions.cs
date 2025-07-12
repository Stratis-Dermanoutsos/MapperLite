using MapperLite.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MapperLite.Extensions;

public static class MapperLiteServiceExtensions
{
    /// <summary>
    /// Maps the mapping profiles to the <see cref="MapperConfiguration"/> and registers the <see cref="IMapper"/> service.
    /// </summary>
    /// <param name="services">The service collection to add the mapper to.</param>
    /// <param name="profiles">One or more mapping profiles to register.</param>
    public static IServiceCollection AddMapperLite(this IServiceCollection services, params MapperProfile[] profiles)
    {
        var config = new MapperConfiguration();

        foreach (var profile in profiles)
        {
            profile.Configure(config);
        }

        services.AddSingleton(config);
        services.AddSingleton<IMapper, Mapper>();

        return services;
    }
}
