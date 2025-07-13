using MapperLite.Demo.WebApi.Endpoints.User;

namespace MapperLite.Demo.WebApi.Extensions;

public static class EndpointsExtensions
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api");

        group.MapUser();

        return app;
    }
}
