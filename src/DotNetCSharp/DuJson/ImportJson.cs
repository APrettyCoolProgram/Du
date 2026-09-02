// 260902_code
// 260902_documentation

using System.Text.Json;

namespace Du.DuJson;

public static class ImportJson
{
    // [260902]
    /// <summary>Imports a JSON object from a file.</summary>
    /// <typeparam name="JsonObject">The type of the JSON object.</typeparam>
    /// <param name="filePath">The file path to import the JSON object from.</param>
    /// <returns>The imported JSON object.</returns>
    /// <example>
    /// <code>
    /// var myObject = DuJson.ImportJson.FromLocalFile&lt;MyObject&gt;(@"C:\Path\to\file.json");
    /// </code>
    /// </example>
    public static JsonObject FromLocalFile<JsonObject>(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<JsonObject>(fileContents);
    }
}