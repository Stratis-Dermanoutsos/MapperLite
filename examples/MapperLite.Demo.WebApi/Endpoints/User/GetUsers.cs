using MapperLite.Demo.Helpers;
using MapperLite.Demo.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MapperLite.Demo.WebApi.Endpoints.User;

public static class GetUsers
{
    public static RouteGroupBuilder MapGetUsers(this RouteGroupBuilder group)
    {
        group.MapGet("/", ([FromServices] IMapper mapper) =>
            {
                // Simulate fetching users from a database
                var users = UserGenerator.GenerateUsers();

                // Return the users as a response
                return Results.Ok(mapper.MapMany<UserReadDto>(users));
            })
            .WithName("GetUsers")
            .WithSummary("Gets all users")
            .WithDescription("Retrieves users from the system.");

        return group;
    }
}
