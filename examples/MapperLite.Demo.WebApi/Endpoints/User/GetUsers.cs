using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.WebApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class GetUsers
{
    public static RouteGroupBuilder MapGetUsers(this RouteGroupBuilder group)
    {
        group.MapGet("/", (
                [FromServices] AppDbContext dbContext,
                [FromServices] IMapper mapper) =>
            {
                var users = dbContext.Users
                    .AsNoTracking()
                    .Include(x => x.Addresses);

                // Return the users as a response
                return Results.Ok(mapper.MapMany<UserReadDto>(users));
            })
            .WithName("GetUsers")
            .WithSummary("Gets all users")
            .WithDescription("Retrieves users from the database.");

        return group;
    }
}
