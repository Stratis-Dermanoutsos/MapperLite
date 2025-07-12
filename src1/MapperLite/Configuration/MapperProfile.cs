namespace MapperLite.Configuration;

/// <summary>
/// Abstract class used to define a mapping profile.
/// <br />
/// A profile is a class that contains one or more mapping configurations.
/// </summary>
public abstract class MapperProfile
{
    public abstract void Configure(MapperConfiguration config);
}
