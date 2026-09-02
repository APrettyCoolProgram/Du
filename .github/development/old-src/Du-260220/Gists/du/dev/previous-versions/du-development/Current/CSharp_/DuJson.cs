// ====================================================================================================================
//    FILENAME: DuJson.cs
//       BUILD: 20190913
//     PROJECT: Du (https://github.com/GitHubAccount/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Json data. Requires Json.NET.
 */
using Newtonsoft.Json;
using System.IO;

namespace Thaumaturge.Du
{
    public class DuJson
    {
        /// <summary>
        /// Loads the contents of a JSON-formatted file into a generic type object.
        /// </summary>
        /// <typeparam name="JsonObjectForDu">The generic type object.</typeparam>
        /// <param name="jsonDataPath">Ex: "/path/to/file".</param>
        /// <returns>JSON data in a generic type object.</returns>
        public static JsonObjectForDu Load<JsonObjectForDu>(string jsonDataPath)
        {
            /* I'm documenting this because I'm sure I'll forget how this works. This is a generic method that takes
             * a file that has JSON-formatted data, deserializes it, then passes it back as whatever object type was
             * passed to it.
             *
             *  var myThing = DuJson.Load<ThingObject>("/Path/To/File.json");
             */
            var configurationFileContents = File.ReadAllText(jsonDataPath);

            return JsonConvert.DeserializeObject<JsonObjectForDu>(configurationFileContents);
        }

        /// <summary>
        /// Saves the contents of a generic type JSON object to a file.
        /// </summary>
        /// <typeparam name="JsonObjectForDu">The generic type object.</typeparam>
        /// <param name="destPath">Ex: "/path/to/file/".</param>
        /// <param name="jsonObject">The generic type JSON object.</param>
        /// <param name="formatJson">[true/false]'</param>
        public static void Save<JsonObjectForDu>(string destPath, JsonObjectForDu jsonObject, bool formatJson)
        {
            var jsonString = formatJson
                ? JsonConvert.SerializeObject(jsonObject, Formatting.Indented)
                : JsonConvert.SerializeObject(jsonObject);

            File.WriteAllText(destPath, jsonString);
        }
    }
}