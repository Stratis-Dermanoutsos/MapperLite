using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.WebApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapperLite.Demo.WebApi.Endpoints.User.Address;

public static class GetAddress
{
    public static RouteGroupBuilder MapGetAddress(this RouteGroupBuilder group)
    {
        group.MapGet("{id:int}", async (
                [FromRoute(Name = "id")] int id,
                [FromServices] AppDbContext dbContext,
                [FromServices] IMapper mapper,
                CancellationToken cancellationToken) =>
        {
            var address = await dbContext.UserAddresses
                .AsNoTracking()
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return address is null ?
                // If the address is not found, return a NotFound result
                Results.NotFound() :
                // Return the address as a response
                Results.Ok(mapper.Map<UserAddressReadDto>(address));
        })
        .WithName("GetAddress")
        .WithSummary("Gets an address by ID")
        .WithDescription("Retrieves an address from the database based on the provided ID.");

        return group;
    }
}
