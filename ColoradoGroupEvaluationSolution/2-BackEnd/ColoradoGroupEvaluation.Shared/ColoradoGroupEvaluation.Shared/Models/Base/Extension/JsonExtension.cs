using System.Text.Json;

namespace ColoradoGroupEvaluation.Shared.Models.Base.Extension;

public static class JsonExtension
{
    /// <summary>
    /// Serializa um objeto para uma string JSON usando System.Text.Json.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser serializado.</typeparam>
    /// <param name="obj">O objeto a ser serializado.</param>
    /// <returns>Uma string JSON representando o objeto.</returns>
    public static string ObjectToJson<T>(this T obj)
    {
        // Usa JsonSerializer.Serialize para converter o objeto em JSON.
        // O método Serialize já lida com nulos e tipos complexos.
        return JsonSerializer.Serialize(obj);
    }

    /// <summary>
    /// Deserializa uma string JSON para um objeto do tipo especificado usando System.Text.Json.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto para o qual a string JSON será deserializada.</typeparam>
    /// <param name="json">A string JSON a ser deserializada.</param>
    /// <returns>Um objeto do tipo T deserializado a partir da string JSON.</returns>
    public static T JsonToObject<T>(this string json)
    {
        // Usa JsonSerializer.Deserialize para converter a string JSON em um objeto.
        // É importante que a string JSON seja válida para o tipo T.
        return JsonSerializer.Deserialize<T>(json)!; // O '!' indica que esperamos um valor não nulo aqui.
    }
}