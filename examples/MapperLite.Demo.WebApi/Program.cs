using MapperLite.Demo.Profiles;
using MapperLite.Demo.WebApi.Database;
using MapperLite.Demo.WebApi.Extensions;
using MapperLite.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMapperLite(
    new UserAddressProfile(),
    new UserProfile()
);

// Register the DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Default.db"));

var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.AddEndpoints();

app.UseHttpsRedirection();

app.Run();

/// <summary>
/// Needed for Test project
/// </summary>
public partial class Program;
