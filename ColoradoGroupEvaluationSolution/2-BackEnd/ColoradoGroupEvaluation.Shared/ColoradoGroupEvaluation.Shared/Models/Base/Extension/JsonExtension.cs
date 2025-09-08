using System.Text.Json;

namespace ColoradoGroupEvaluation.Shared.Models.Base.Extension;

public static class JsonExtension
{
    public static string ObjectToJson<T>(this T obj)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Serialize(obj, options);
    }

    public static T JsonToObject<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json)!;
    }
}