// 260902_code
// 260902_documentation

using System.Text.Json;

namespace Du.DuJson;

/// <summary>Provides functionality to export JSON objects to files.</summary>
public static class ExportJson
{
    // [260902]
    /// <summary>Exports a JSON object to a file.</summary>
    /// <typeparam name="JsonObject">The type of the JSON object.</typeparam>
    /// <param name="jsonObject">The JSON object to export.</param>
    /// <param name="filePath">The file path to export the JSON object to.</param>
    /// <param name="prettyJson">Determines if the JSON data is formatted.</param>
    /// <example>
    /// <code>
    /// var myObject = new MyObject();
    /// Du.DuJson.ExportJson.ToLocalFile&lt;MyObject&gt;(myObject, @"C:\Path\to\file.json");        // formatted
    /// Du.DuJson.ExportJson.ToLocalFile&lt;MyObject&gt;(myObject, @"C:\Path\to\file.json", false); // not formatted
    /// </code>
    /// </example>
    public static void ToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool prettyJson = true)
    {
        // TODO - There is a better way to do this.
        var jsonFormat = prettyJson
                ? new JsonSerializerOptions { WriteIndented = true }
                : new JsonSerializerOptions { WriteIndented = false };

        var fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

        File.WriteAllText(filePath, fileContent);
    }
}