using MapperLite.Demo.Helpers;
using MapperLite.Demo.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MapperLite.Demo.WebApi.Endpoints.User.Address;

public static class GetAddresses
{
    public static RouteGroupBuilder MapGetAddresses(this RouteGroupBuilder group)
    {
        group.MapGet("/", ([FromServices] IMapper mapper) =>
            {
                // Simulate fetching addresss from a database
                var addresses = UserAddressGenerator.GenerateUserAddresses();

                // Return the addresses as a response
                return Results.Ok(mapper.MapMany<UserAddressReadDto>(addresses));
            })
            .WithName("GetAddresses")
            .WithSummary("Gets all addresses")
            .WithDescription("Retrieves addresses from the system.");

        return group;
    }
}
