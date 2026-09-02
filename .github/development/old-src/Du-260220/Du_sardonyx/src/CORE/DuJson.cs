// =====================================================================================================================
//    FILE: Du.DuJson.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-1-2021-11:19 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

using System;
using System.IO;
using System.Text.Json;

namespace Du
{
    public class DuJson
    {
        /// <summary>Deserialize a file to a JSON object.</summary>
        /// <param name="filePath">The path to the file to deserialize (e.g., "/path/to/file.txt").</param>
        /// <example>
        /// <c>DuJson.DeserializeFile<OjectType>(filePath);</c>
        /// </example>
        /// <returns>The contents of the file as a JSON object.</returns>
        public static T DeserializeFile<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);

            T jsonObject = DeserializeString<T>(jsonString);
            //T jsonObject = JsonSerializer.Deserialize<T>(jsonString); // Old way, can delete when this method is confirmed to work.

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

        /// <summary>Deserialize a string to a JSON object.</summary>
        /// <param name="jsonString">The string to deserialize.</param>
        /// <example>
        /// <c>DuJson.DeserializeString<ObjectType>(jsonString);</c>
        /// </example>
        /// <returns>The contents of the JSON string as an object.</returns>
        public static T DeserializeString<T>(string jsonString)
        {
            T jsonObject = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

        /// <summary>Serialize a JSON object to a pretty-print formatted string.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject">The JSON object to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeToFormattedString<ObjectType>(jsonObject);</c>
        /// </example>
        /// <returns>The JSON object as a pretty-print formatted string.</returns>
        public static string SerializeToFormattedString<T>(T jsonObject)
        {
            var formatOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return JsonSerializer.Serialize(jsonObject, formatOptions);
        }

        /// <summary>Serialize a JSON object to a minified string.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject">The JSON object to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeToMinifiedString<ObjectType>(jsonObject);</c>
        /// </example>
        /// <returns>The JSON object as a pretty-print formatted string.</returns>
        public static string SerializeToMinifiedString<T>(T jsonObject)
        {
            return JsonSerializer.Serialize(jsonObject);
        }

        /// <summary>Serializes JSON data and writes it to a file with pretty-print formatting.</summary>
        /// <typeparam name="T">The JSON object type.</typeparam>
        /// <param name="filePath">The path to write to (e.g., "/path/to/file.txt").</param>
        /// <param name="jsonData">The JSON object to serialze and write.</param>
        /// <example>
        /// <c>DuJson.WriteFormattedJsonToFile<ObjectType>(filePath, jsonObject);</c>
        /// </example>
        public static void WriteFormattedJsonToFile<T>(string filePath, T jsonData)
        {
            var jsonOutput = SerializeToFormattedString(jsonData);

            File.WriteAllText(filePath, jsonOutput);
        }

        /// <summary>Serializes JSON data and writes it to a file with minified formatting.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The path to write to (e.g., "/path/to/file.txt").</param>
        /// <param name="jsonData">The JSON object to serialze and write.</param>
        /// <example>
        /// <c>DuJson.WriteMinifiedJsonToFile<ObjectType>(filePath, jsonObject);</c>
        /// </example>
        public static void WriteMinifiedJsonToFile<T>(string filePath, T jsonData)
        {
            var jsonOutput = SerializeToMinifiedString(jsonData);

            File.WriteAllText(filePath, jsonOutput);
        }
    }
}
