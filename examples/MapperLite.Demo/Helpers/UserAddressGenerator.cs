using MapperLite.Demo.Models.Persistence;
using RandomNameGeneratorLibrary;

namespace MapperLite.Demo.Helpers;

public static class UserAddressGenerator
{
    private static readonly Random Random = new();
    private static readonly PlaceNameGenerator PlaceGenerator = new();

    public static UserAddress GenerateUserAddress(int id = 1, int maxUserId = 0)
    {
        return new UserAddress
        {
            Id = id,
            Street = PlaceGenerator.GenerateRandomPlaceName(),
            Number = Random.Next(10, 99).ToString("D2"),
            City = PlaceGenerator.GenerateRandomPlaceName(),
            ZipCode = Random.Next(0, 100000).ToString("D5"),
            UserId = maxUserId > 0 ? Random.Next(1, maxUserId) : 0
        };
    }

    public static List<UserAddress> GenerateUserAddresses(int number = 0, int maxUserId = 0)
    {
        if (number <= 0)
        {
            number = Random.Next(1, 10); // Generate between 1 and 10 users if no number is specified
        }
        return [.. Enumerable.Range(1, number).Select(x => GenerateUserAddress(x, maxUserId))];
    }
}
