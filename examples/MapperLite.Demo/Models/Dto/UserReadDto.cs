namespace MapperLite.Demo.Models.Dto;

public partial class UserReadDto
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;

    public List<UserAddressReadDto> Addresses { get; init; } = [];

    public override string ToString()
    {
        return $"UserDto: {FirstName} {LastName}. Addresses' streets: {string.Join(", ", Addresses.Select(a => a.ToString()))}";
    }
}
