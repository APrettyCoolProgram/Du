// 240511.1130

using System.Text.Json;

namespace Du
{
    public static class WithJson
    {
        /// <summary>Export JSON data to an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="jsonObject">The JSON object.</param>
        /// <param name="filePath">The export file path.</param>
        /// <param name="formatJson">Determines if the JSON data is formatted.</param>
        /// <example>
        ///     To call Du.WithJson.ExportToLocalFile():
        ///     <code>
        ///         TheObject theObject = new TheObject();      
        ///         Du.WithJson.ExportToLocalFile<TheObject>(theObject, "/Path/To/Export/File");
        /// </code>
        /// </example>

        public static void ExportToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool formatJson = true)
        {
            JsonSerializerOptions jsonFormat = new JsonSerializerOptions();

            if (formatJson)
            {
                jsonFormat.WriteIndented = true;
            }
            else
            {
                jsonFormat.WriteIndented = false;
            }

            string fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

            File.WriteAllText(filePath, fileContent);
        }

        /// <summary>Import JSON data from an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="filePath">The import file path.</param>
        /// <example>
        ///     To call Du.WithJson.ImportFromLocalFile():
        ///     <code>
        ///         TheObject theObject = Du.WithJson.ImportFromLocalFile<TheObject>("/Path/To/Import/File");
        ///     </code>
        /// </example>
        /// <returns>The contents of the file as a JSON object.</returns>
        public static JsonObject ImportFromLocalFile<JsonObject>(string filePath)
        {
            var configurationFileContents = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<JsonObject>(configurationFileContents);
        }
    }
}