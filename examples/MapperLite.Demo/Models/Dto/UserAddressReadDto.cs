namespace MapperLite.Demo.Models.Dto;

public partial class UserAddressReadDto
{
    public required string StreetFull { get; init; }
    public required string City { get; init; }
    public required string ZipCode { get; init; }

    public override string ToString()
    {
        return $"{StreetFull}";
    }
}
