using MapperLite.Demo.Helpers;

namespace MapperLite.Demo.Models.Persistence;

public class UserAddress : JsonStringifiable
{
    public int Id { get; set; }

    public required string Street { get; set; }
    public string? Number { get; set; }
    public required string City { get; set; }
    public required string ZipCode { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}
