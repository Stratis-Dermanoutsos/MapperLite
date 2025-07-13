using MapperLite.Configuration;
using MapperLite.Demo.Helpers;
using MapperLite.Demo.Models.Dto;
using MapperLite.Demo.Models.Persistence;
using MapperLite.Demo.Profiles;

// Create the MapperConfiguration
var config = new MapperConfiguration();

// Create the mapping profiles and configure them
List<MapperProfile> profiles = [
    new UserProfile(),
    new UserAddressProfile()
];
profiles.ForEach(profile => profile.Configure(config));

// Create the Mapper instance with the configuration
var mapper = new MapperLite.Mapper(config);

var user = UserGenerator.GenerateUser();

var userDto = mapper.Map<UserReadDto>(user);
// var userDto = mapper.Map<User, UserReadDto>(user); // Equal to the above line

// Output the results
Console.WriteLine("User Model:\t" + user);
Console.WriteLine("User DTO:\t" + userDto);
