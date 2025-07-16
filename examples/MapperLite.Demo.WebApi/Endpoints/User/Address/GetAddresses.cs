using MapperLite.Configuration;
using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.Models.Persistence;
using MapperLite.Demo.WebApi.Database;
using MapperLite.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapperLite.Demo.WebApi.Endpoints.User.Address;

public static class GetAddresses
{
    public static RouteGroupBuilder MapGetAddresses(this RouteGroupBuilder group)
    {
        group.MapGet("/", (
                [FromServices] AppDbContext dbContext,
                [FromServices] MapperConfiguration mappingConfig) =>
            {
                var addresses = dbContext.UserAddresses
                    .AsNoTracking()
                    .ProjectTo<UserAddress, UserAddressReadDto>(mappingConfig);

                // Return the addresses as a response
                return Results.Ok(addresses);
            })
            .WithName("GetAddresses")
            .WithSummary("Gets all addresses")
            .WithDescription("Retrieves addresses from the database.");

        return group;
    }
}
