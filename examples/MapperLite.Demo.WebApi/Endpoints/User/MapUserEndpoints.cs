using MapperLite.Demo.Helpers;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class MapUserEndpoints
{
    public static RouteGroupBuilder MapUser(this RouteGroupBuilder group)
    {
        return group.MapGroup("users")
            .MapGetUser()
            .MapGetUsers();
    }
}
