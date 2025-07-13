using System.Text.Json;

namespace MapperLite.Demo.Helpers;

public class JsonStringifiable
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, GetType(), new JsonSerializerOptions());
    }
}
