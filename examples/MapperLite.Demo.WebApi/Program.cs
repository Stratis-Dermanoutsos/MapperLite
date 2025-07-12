using MapperLite.Demo.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.AddEndpoints();

app.UseHttpsRedirection();

app.Run();

/// <summary>
/// Needed for Test project
/// </summary>
public partial class Program;
