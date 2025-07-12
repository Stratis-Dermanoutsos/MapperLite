using MapperLite.Demo.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class GetUser
{
    public static RouteGroupBuilder MapGetUser(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:int}", ([FromRoute(Name = "id")] int id) =>
        {
            // Simulate fetching a user from a database
            var user = UserGenerator.GenerateUser(id);

            // Return the user as a response
            return Results.Ok(user);
        })
        .WithName("GetUser")
        .WithSummary("Gets a user by ID")
        .WithDescription("Retrieves a user from the system based on the provided ID.");

        return group;
    }
}
