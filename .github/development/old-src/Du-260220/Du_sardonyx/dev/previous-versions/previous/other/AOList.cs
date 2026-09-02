/* A class for AO.cs that does various things with lists.
 * v00.51.160926
 * http://aprettycoolprogram.com/ao
 */

using System.Collections.Generic;

namespace AO
{
    public class AOList
    {
        /// <summary>Convert list to array</summary>
        /// <param name="toConvert">The list to convert.</param>
        /// <returns>The list as an array.</returns>
        public static string[] ToArray(List<string> toConvert)
        {
            var element = 0;
            var wrkArray = new string[toConvert.Count];

            foreach (var item in toConvert)
            {
                wrkArray[element] = item;
                element++;
            }

            return wrkArray;
        }

        /// <summary>Converts a list to a dictionary.</summary>
        /// <param name="toConvert">The list to convert.</param>
        /// <param name="delimiter">The delimiter to use.</param>
        /// <returns>The list as a dictionary.</returns>
        public static Dictionary<string, string> ToDictionary(List<string> toConvert, char delimiter)
        {
            return AOArray.AsDictionary(ToArray(toConvert), delimiter);
        }

        /// <summary>Extracts a dictionary from a list of dictionaries.</summary>
        /// <param name="extractFrom">The list of dictionaries to extract from.</param>
        /// <param name="dictionaryNumber">The dictionary to extract.</param>
        /// <returns>The extracted dictionary.</returns>
        public static Dictionary<string, string> ExtractDictionary(List<Dictionary<string, string>> extractFrom, int dictionaryNumber)
        {
            Dictionary<string, string> wrkDictionary = new Dictionary<string, string>();

            foreach (var keyValuePair in extractFrom[dictionaryNumber])
            {
                wrkDictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return wrkDictionary;
        }

        /// <summary>Merge two lists.</summary>
        /// <param name="firstList">The first list.</param>
        /// <param name="secondList">The second list.</param>
        /// <returns>The two lists merged as one.</returns>
        public static List<string> Merge(List<string> firstList, List<string> secondList)
        {
            foreach (var item in secondList)
            {
                firstList.Add(item);
            }

            return firstList;
        }

        /// <summary>Remove something from a list.</summary>
        /// <param name="toFilter"></param>
        /// <param name="action"></param>
        /// <param name="empty"></param>
        /// <param name="commentChar"></param>
        /// <returns></returns>
        public static List<string> Remove(List<string> toFilter, bool empty, char commentChar)
        {
            var wrkList = new List<string>();

            foreach (var item in toFilter)
            {
                if (!AOString.Check(item, empty, commentChar))
                {
                    wrkList.Add(item);
                }
            }

            return wrkList;
        }

        /// <summary>Remove null values from an list</summary>
        /// <param name="removeFrom">The list to remove nulls from</param>
        /// <returns>An array without null values</returns>
        public static List<string> RemoveNulls(List<string> removeFrom) // Add to "Remove"?
        {
            var wrkList = new List<string>();

            foreach (var item in removeFrom)
            {
                if (item != null)
                {
                    wrkList.Add(item);
                }
            }

            return wrkList;
        }

        /// <summary>Returns a specific section of a list.</summary>
        /// <param name="toWork">The list to work with</param>
        /// <param name="sectionChar">The character that indicates a section ["%"]</param>
        /// <param name="sectionDelim">The section we are looking for ["%SECTION"] "</param>
        /// <returns>The section of a list, as a list.</returns>
        public static List<string> SectionAsList(List<string> toWork, string sectionChar, string sectionDelim)
        {
            List<string> sectionList = new List<string>();
            bool record = false;

            foreach (var item in toWork)
            {
                if (record && item.StartsWith(sectionChar))
                {
                    record = false;
                    break;
                }

                if (record)
                {
                    sectionList.Add(item);
                }

                if (!record && item == sectionDelim)
                {
                    record = true;
                }
            }

            return sectionList;
        }

        /// <summary>Splits a list into multiple sections.</summary>
        /// <param name="toConvert">The list to split.</param>
        /// <param name="sectionChar">The character to split at ["%"]</param>
        /// <param name="sectionDelim">The string to split at ["%"]</param>
        /// <returns>A list of lists of sections.</returns>
        public static List<List<string>> SectionsAsLists(List<string> toConvert, string sectionChar, string sectionDelim)
        {
            var innerList = new List<string>();
            var outerList = new List<List<string>>();
            var record = false;

            foreach (var item in toConvert)
            {
                if (record && !item.StartsWith(sectionChar))
                {
                    innerList.Add(item);
                }

                if (item.StartsWith(sectionChar))
                {
                    if (record)
                    {
                        outerList.Add(innerList);
                        innerList = new List<string>();
                    }
                    else
                    {
                        record = true;
                    }
                }
            }

            return outerList;
        }
    }
}