/* A class for AO.cs that does various things with dictionaries.
 * v00.51.160926
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AO
{
    public class AODictionary
    {
        /// <summary>Converts a the keys or values of a dictionary to a list.</summary>
        /// <param name="fileName">File name to write to.</param>
        /// <param name="dataToWrite">Data to write.</param>
        public static List<string> AsListOfKeysOrValues(Dictionary<string, string> dictionaryToConvert, string parseType)
        {
            return (parseType == "keys") ? dictionaryToConvert.Keys.ToList() : dictionaryToConvert.Values.ToList();
        }

        /// <summary>Converts a dictionary to a file.</summary>
        /// <param name="fileName">File name to write to.</param>
        /// <param name="dataToWrite">Data to write.</param>
        public static void AsFile(string fileName, Dictionary<string, string> dataToWrite)
        {
            File.WriteAllText(fileName, AsString(dataToWrite, '=', true));
        }

        /// <summary>Converts a dictionary to a string.</summary>
        /// <param name="dictionaryToConvert">The dictionary to convert.</param>
        /// <param name="delimiter">The marker that seperates key/value pairs ("=", "\t").</param>
        /// <param name="clean">Flag to clean comments, etc. [true/false]</param>
        /// <returns>A string with the dictionary data.</returns>
        public static string AsString(Dictionary<string, string> dictionaryToConvert, char delimiter, bool clean)
        {
            var wrkString = string.Empty;

            foreach (var item in dictionaryToConvert)
            {
                wrkString = wrkString + item.Key + delimiter.ToString() + item.Value + Environment.NewLine;
            }

            return wrkString;
        }

        /// <summary>Removes empties/comments/nulls from a dictionary.</summary>
        /// <param name="dictionaryToClean">Dictionary to clean.</param>
        /// <param name="checkIsEmpty">Flag to remove empty elements.[true/false]</param>
        /// <param name="checkIsComment">Flag to remove comments.[true/false]</param>
        /// <param name="commentCharacter">The character that indicates a comment line ("#", "//"). Use ' ' for none.</param>
        /// <param name="nullVal">Flag to remove null values.[true/false]</param>
        /// <returns>The cleaned dictionary</returns>
        public static Dictionary<string, string> Clean(Dictionary<string, string> dictionaryToClean, bool checkIsEmpty, bool checkIsComment, char commentChar, bool nullVal)
        {
            var wrkDictionary = new Dictionary<string, string>();
            var itemMeetsRequirements = false;
            var itemIsNull = false;

            foreach (var item in dictionaryToClean)
            {
                itemMeetsRequirements = AOString.Check(item.Key, checkIsEmpty, commentChar);
                itemIsNull = nullVal && Convert.ToBoolean(item.Key == null);

                if (itemMeetsRequirements && !itemIsNull)
                {
                    wrkDictionary.Add(item.Key, item.Value);
                }
            }

            return wrkDictionary;
        }

        /// <summary>Extract keys or values from a dictionary.</summary>
        /// <param name="dictionaryToExtractFrom">The dictionary to extract from.</param>
        /// <param name="keyOrValue">Flag looking for a key or value.</param>
        /// <returns>A list of keys or values from a dictionary.</returns>
        public static List<string> Extract(Dictionary<string, string> dictionaryToExtractFrom, string keyOrValue)
        {
            var wrkList = new List<string>();

            foreach (var item in dictionaryToExtractFrom)
            {
                wrkList.Add((keyOrValue == "key") ? item.Key : item.Value);
            }

            return wrkList;
        }

        /// <summary>Returns a specific key/value in a dictionary.</summary>
        /// <param name="fileName">File name to write to.</param>
        /// <param name="dataToWrite">Data to write.</param>
        /// <param name="location">Location of data.</param>
        public static string GetSpecificKeyOrValue(Dictionary<string, string> dictionaryToConvert, string parseType, int location)
        {
            return (parseType == "key") ? dictionaryToConvert.Keys.ToList()[location] : dictionaryToConvert.Values.ToList()[location];
        }

        /// <summary>Merge a list of dictionaries.</summary>
        /// <param name="dictionariesToJoin">The dictionaries to join.</param>
        /// <returns>A dictionary containing the values from all the dictionaries.</returns>
        public static Dictionary<string, string> Join(List<Dictionary<string, string>> dictionariesToJoin)
        {
            var wrkDictionary = new Dictionary<string, string>();

            foreach (var item in dictionariesToJoin)
            {
                item.ToList().ForEach(x => wrkDictionary[x.Key] = x.Value);
            }

            return wrkDictionary;
        }

        /// <summary></summary>
        /// <param name="dictionaryToFilter"></param>
        /// <param name="action">??</param>
        /// <param name="empty">[true/false]</param>
        /// <param name="commentCharacter">The character that indicates a comment line ("#", "//"). Use ' ' for none.</param>
        /// <returns></returns>
        public static Dictionary<string, string> Remove(Dictionary<string, string> dictionaryToFilter, bool empty, char commentChar)
        {
            var wrkDictionary = new Dictionary<string, string>();

            foreach (var item in dictionaryToFilter)
            {
                if (!AOString.Check(item.Key.ToString(), empty, commentChar))
                {
                    wrkDictionary.Add(item.Key, item.Value);
                }
            }

            return wrkDictionary;
        }
    }
}