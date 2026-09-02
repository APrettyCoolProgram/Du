/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuJson.cs
 * UPDATED: 1-27-2021-8:29 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  This class requires .NET 5. This will not work in the .NET Framework.
 *
 *  If you are using the .NET Framework, you are better off using Json.NET:
 *  https://www.newtonsoft.com/json
 */

using System;
using System.IO;
using System.Text.Json;

namespace Du
{
    /// <summary>Methods that work with JSON formatted data.</summary>
    public class DuJson
    {
        /// <summary>Serialize a file into a dynamic object.</summary>
        /// <param name="configFilePath">The path to the configuration file to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeFile<YourObject>(configFilePath)</c>
        /// </example>
        /// <returns>The contents of the configuration file as an object.</returns>
        public static T SerializeFile<T>(string jsonFormattedFilePath)
        {
            var jsonString = File.ReadAllText(jsonFormattedFilePath);
            T jsonObject = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

        /// <summary>Serialize a JSON string into a dynamic object.</summary>
        /// <param name="jsonString">The string to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeString<YourObject>(jsonString)</c>
        /// </example>
        /// <returns>The contents of the JSON string as an object.</returns>
        public static T SerializeString<T>(string jsonString)
        {
            T jsonObject = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }
    }
}
