using MapperLite.Demo.Helpers;
using MapperLite.Demo.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MapperLite.Demo.WebApi.Endpoints.User.Address;

public static class GetAddress
{
    public static RouteGroupBuilder MapGetAddress(this RouteGroupBuilder group)
    {
        group.MapGet("{id:int}", (
                [FromRoute(Name = "id")] int id,
                [FromServices] IMapper mapper) =>
        {
            // Simulate fetching an address from a database
            var address = UserAddressGenerator.GenerateUserAddress(id);

            // Return the address as a response
            return Results.Ok(mapper.Map<UserAddressReadDto>(address));
        })
        .WithName("GetAddress")
        .WithSummary("Gets an address by ID")
        .WithDescription("Retrieves an address from the system based on the provided ID.");

        return group;
    }
}
