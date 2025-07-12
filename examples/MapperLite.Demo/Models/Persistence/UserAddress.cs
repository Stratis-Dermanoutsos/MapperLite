namespace MapperLite.Demo.Models.Persistence;

public class UserAddress
{
    public int Id { get; set; }
    public required string Street { get; set; }
    public string? Number { get; set; }
    public required string City { get; set; }
    public required string ZipCode { get; set; }

    public override string ToString()
    {
        return $"{Id}. {Street} {Number}, {City}, {ZipCode}";
    }
}
