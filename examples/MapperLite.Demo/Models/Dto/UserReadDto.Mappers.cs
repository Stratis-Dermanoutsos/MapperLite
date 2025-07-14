using System.Linq.Expressions;
using MapperLite.Abstractions;
using MapperLite.Demo.Models.Persistence;

namespace MapperLite.Demo.Models.Dto;

public partial class UserReadDto : IReadMapper<User, UserReadDto>
{
    public static Expression<Func<User, UserReadDto>> Projection { get; } =
        source => new UserReadDto
        {
            FirstName = source.FirstName,
            LastName = source.LastName
        };

    public static UserReadDto FromSource(User source)
    {
        var dto = Projection.Compile()(source);
        dto.Addresses = [.. source.Addresses.Select(UserAddressReadDto.FromSource)];

        return dto;
    }
}
