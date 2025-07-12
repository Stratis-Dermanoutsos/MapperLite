namespace MapperLite.Demo.Models.Persistence;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public List<UserAddress> Addresses { get; set; } = [];

    public override string ToString()
    {
        return $"User {Id}: {FirstName} {LastName}. Addresses: {string.Join(" - ", Addresses.Select(a => a.ToString()))}";
    }
}
