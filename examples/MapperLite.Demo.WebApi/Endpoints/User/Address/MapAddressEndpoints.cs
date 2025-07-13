namespace MapperLite.Demo.WebApi.Endpoints.User.Address;

public static class MapAddressEndpoints
{
    public static RouteGroupBuilder MapAddress(this RouteGroupBuilder group)
    {
        return group.MapGroup("addresses")
            .MapGetAddress()
            .MapGetAddresses();
    }
}
