using MapperLite.Demo.Helpers;

namespace MapperLite.Demo.Models.Dto;

public partial class UserAddressReadDto : JsonStringifiable
{
    public required string StreetFull { get; init; }
    public required string City { get; init; }
    public required string ZipCode { get; init; }
}
