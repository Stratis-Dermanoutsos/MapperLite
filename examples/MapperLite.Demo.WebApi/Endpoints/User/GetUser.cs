using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.WebApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class GetUser
{
    public static RouteGroupBuilder MapGetUser(this RouteGroupBuilder group)
    {
        group.MapGet("{id:int}", async (
                [FromRoute(Name = "id")] int id,
                [FromServices] AppDbContext dbContext,
                [FromServices] IMapper mapper,
                CancellationToken cancellationToken) =>
        {
            var user = await dbContext.Users
                .AsNoTracking()
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return user is null ?
                // If the user is not found, return a NotFound result
                Results.NotFound() :
                // Return the user as a response
                Results.Ok(mapper.Map<UserReadDto>(user));
        })
        .WithName("GetUser")
        .WithSummary("Gets a user by ID")
        .WithDescription("Retrieves a user from the database based on the provided ID.");

        return group;
    }
}
