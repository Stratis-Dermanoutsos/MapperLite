using System.Linq.Expressions;
using LinqKit;
using MapperLite.Abstractions;
using MapperLite.Demo.Models.Persistence;
// using MapperLite.Extensions;

namespace MapperLite.Demo.Models.Dto;

public partial class UserReadDto : IReadMapper<User, UserReadDto>
{
    public static Expression<Func<User, UserReadDto>> Projection =>
        source => new UserReadDto
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            Addresses = source.Addresses
                .AsQueryable()
                .Select(UserAddressReadDto.Projection.Expand())
                .ToList()
            // TODO: Use this when EF Core supports it. Currently only useful for in-memory projections.
            // Addresses = source.Addresses.AsProjection<UserAddress, UserAddressReadDto>()
        };

    public static UserReadDto FromSource(User source)
    {
        var dto = Projection.Compile()(source);

        return dto;
    }
}
