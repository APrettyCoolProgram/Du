// 260220_code
// 260220_documentation

using System.Text.Json;

namespace Du;

/// <summary> Provides utilities for working with JSON data.</summary>
public class DuJson
{
    /// <summary>JSON serialization options configured for prettified output with indentation.</summary>
    private static readonly JsonSerializerOptions PrettifyOptions = new()
    {
        WriteIndented = true
    };

    /// <summary>Reads a JSON file and returns its contents as a prettified (indented) JSON string.</summary>
    /// <param name="jsonSourcePath">The file path to the JSON file to prettify.</param>
    /// <returns>A prettified JSON string with proper indentation.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the file at <paramref name="jsonSourcePath"/> does not exist.</exception>
    /// <exception cref="JsonException">Thrown when the file contents are not valid JSON.</exception>
    public static string Prettify(string jsonSourcePath)
    {
        var jsonContent        = File.ReadAllText(jsonSourcePath);
        using var jsonDocument = JsonDocument.Parse(jsonContent);

        return JsonSerializer.Serialize(jsonDocument, PrettifyOptions);
    }
}