using MapperLite.Demo.Models.Persistence;
using RandomNameGeneratorLibrary;

namespace MapperLite.Demo.Helpers;

public static class UserGenerator
{
    private static readonly Random Random = new();
    private static readonly PersonNameGenerator NameGenerator = new();

    public static User GenerateUser(int id = 1)
    {
        return new User
        {
            Id = id,
            FirstName = NameGenerator.GenerateRandomFirstName(),
            LastName = NameGenerator.GenerateRandomLastName(),
            Addresses = UserAddressGenerator.GenerateUserAddresses()
        };
    }

    public static List<User> GenerateUsers(int number = 0)
    {
        if (number <= 0)
        {
            number = Random.Next(1, 10); // Generate between 1 and 10 users if no number is specified
        }
        return [.. Enumerable.Range(1, number).Select(GenerateUser)];
    }
}
