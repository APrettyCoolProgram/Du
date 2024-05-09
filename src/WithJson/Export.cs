// 240509.1117

using System.Text.Json;

namespace Du.WithJson
{
    public static class Export
    {
        /// <summary>Export JSON data to an external file.</summary>
        /// <typeparam name="JsonObject"></typeparam>
        /// <param name="jsonObject"></param>
        /// <param name="filePath"></param>
        /// <param name="formatJson"></param>

        public static void ToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool formatJson = true)
        {
            JsonSerializerOptions jsonFormat = formatJson
                ? new JsonSerializerOptions
                {
                    WriteIndented = true
                }
                : new JsonSerializerOptions
                {
                    WriteIndented = false
                };

            string fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

            File.WriteAllText(filePath, fileContent);
        }
    }
}