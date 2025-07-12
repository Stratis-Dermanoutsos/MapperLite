using MapperLite.Abstractions;
using MapperLite.Demo.Models.Persistence;

namespace MapperLite.Demo.Models.Dto;

public partial class UserReadDto : IReadMapper<User, UserReadDto>
{
    public static UserReadDto FromSource(User source)
    {
        return new UserReadDto
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            Addresses = [.. source.Addresses.Select(UserAddressReadDto.FromSource)]
        };
    }
}
