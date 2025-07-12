using MapperLite.Configuration;
using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.Models.Persistence;
using MapperLite.Demo.Profiles;

// Create the MapperConfiguration
var config = new MapperConfiguration();

// Create the mapping profiles
var userProfile = new UserProfile();
var userAddressProfile = new UserAddressProfile();

// Configure the profiles with the MapperConfiguration
userProfile.Configure(config);
userAddressProfile.Configure(config);

// Create the Mapper instance with the configuration
var mapper = new MapperLite.Mapper(config);

var user = new User
{
    Id = 1,
    FirstName = "John",
    LastName = "Doe",
    Addresses = [
        new UserAddress { Id = 1, Street = "Main St", Number = "123", City = "Anytown", ZipCode = "12345" },
        new UserAddress { Id = 2, Street = "Elm St", City = "Othertown", ZipCode = "67890" }
    ]
};

var userDto = mapper.Map<UserReadDto>(user);
// var userDto = mapper.Map<User, UserReadDto>(user); // Equal to the above line

// Output the results
Console.WriteLine("User Model:\t" + user);
Console.WriteLine("User DTO:\t" + userDto);
