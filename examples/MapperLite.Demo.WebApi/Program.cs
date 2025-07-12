using MapperLite.Demo.Profiles;
using MapperLite.Demo.WebApi.Extensions;
using MapperLite.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMapperLite(
    new UserAddressProfile(),
    new UserProfile()
);

var app = builder.Build();

app.AddEndpoints();

app.UseHttpsRedirection();

app.Run();

/// <summary>
/// Needed for Test project
/// </summary>
public partial class Program;
