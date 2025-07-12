using MapperLite.Configuration;
using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.Models.Persistence;

namespace MapperLite.Demo.Profiles;

public class UserProfile : MapperProfile
{
    public override void Configure(MapperConfiguration config)
    {
        config.CreateMapFrom<User, UserReadDto>();
    }
}
