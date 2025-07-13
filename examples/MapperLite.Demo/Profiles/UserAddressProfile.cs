using MapperLite.Configuration;
using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.Models.Persistence;

namespace MapperLite.Demo.Profiles;

public class UserAddressProfile : MapperProfile
{
    public override void Configure(MapperConfiguration config)
    {
        config.CreateMapFrom<UserAddress, UserAddressReadDto>();
    }
}
