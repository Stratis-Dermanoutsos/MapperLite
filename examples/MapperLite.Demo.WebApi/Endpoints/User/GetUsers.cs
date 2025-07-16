using MapperLite.Configuration;
using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.WebApi.Database;
using MapperLite.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class GetUsers
{
    public static RouteGroupBuilder MapGetUsers(this RouteGroupBuilder group)
    {
        group.MapGet("/", (
                [FromServices] AppDbContext dbContext,
                [FromServices] MapperConfiguration mappingConfig,
                [FromServices] IMapper mapper) =>
            {
                var users = dbContext.Users
                    .AsNoTracking()
                    .ProjectTo<Models.Persistence.User, UserReadDto>(mappingConfig);

                // Return the users as a response
                return Results.Ok(users);
            })
            .WithName("GetUsers")
            .WithSummary("Gets all users")
            .WithDescription("Retrieves users from the database.");

        return group;
    }
}
