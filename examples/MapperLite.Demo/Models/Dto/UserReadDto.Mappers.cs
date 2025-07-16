using System.Linq.Expressions;
using LinqKit;
using MapperLite.Abstractions;
using MapperLite.Demo.Models.Persistence;

namespace MapperLite.Demo.Models.Dto;

public partial class UserReadDto : IReadMapper<User, UserReadDto>
{
    public static Expression<Func<User, UserReadDto>> Projection { get; } =
        source => new UserReadDto
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            Addresses = source.Addresses
                .AsQueryable()
                .Select(UserAddressReadDto.Projection.Expand())
                .ToList()
        };

    public static UserReadDto FromSource(User source)
    {
        var dto = Projection.Compile()(source);

        return dto;
    }
}
