using System.Linq.Expressions;
using MapperLite.Abstractions;
using MapperLite.Demo.Models.Persistence;

namespace MapperLite.Demo.Models.Dto;

public partial class UserAddressReadDto : IReadMapper<UserAddress, UserAddressReadDto>
{
    public static Expression<Func<UserAddress, UserAddressReadDto>> Projection =>
        source => new UserAddressReadDto
        {
            StreetFull = source.Street + (string.IsNullOrEmpty(source.Number) ? string.Empty : " " + source.Number),
            City = source.City,
            ZipCode = source.ZipCode
        };

    public static UserAddressReadDto FromSource(UserAddress source)
    {
        return Projection.Compile()(source);
    }
}
