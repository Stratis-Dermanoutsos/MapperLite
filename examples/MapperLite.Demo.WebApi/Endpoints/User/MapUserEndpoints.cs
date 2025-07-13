using MapperLite.Demo.Helpers;
using MapperLite.Demo.WebApi.Endpoints.User.Address;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class MapUserEndpoints
{
    public static RouteGroupBuilder MapUser(this RouteGroupBuilder group)
    {
        return group.MapGroup("users")
            .MapGetUser()
            .MapGetUsers()
            .MapAddress();
    }
}
