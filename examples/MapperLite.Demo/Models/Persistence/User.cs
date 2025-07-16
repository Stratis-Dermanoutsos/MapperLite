using MapperLite.Demo.Helpers;

namespace MapperLite.Demo.Models.Persistence;

public class User : JsonStringifiable
{
    public int Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public List<UserAddress> Addresses { get; set; } = [];
}
