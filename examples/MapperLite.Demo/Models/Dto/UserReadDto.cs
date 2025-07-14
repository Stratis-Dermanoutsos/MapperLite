using MapperLite.Demo.Helpers;

namespace MapperLite.Demo.Models.Dto;

public partial class UserReadDto : JsonStringifiable
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;

    public List<UserAddressReadDto> Addresses { get; set; } = [];
}
