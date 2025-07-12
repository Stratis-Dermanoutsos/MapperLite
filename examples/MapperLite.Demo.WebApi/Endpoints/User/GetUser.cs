using MapperLite.Demo.Helpers;
using MapperLite.Demo.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class GetUser
{
    public static RouteGroupBuilder MapGetUser(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:int}", (
                [FromRoute(Name = "id")] int id,
                [FromServices] IMapper mapper) =>
        {
            // Simulate fetching a user from a database
            var user = UserGenerator.GenerateUser(id);

            // Return the user as a response
            return Results.Ok(mapper.Map<UserReadDto>(user));
        })
        .WithName("GetUser")
        .WithSummary("Gets a user by ID")
        .WithDescription("Retrieves a user from the system based on the provided ID.");

        return group;
    }
}
