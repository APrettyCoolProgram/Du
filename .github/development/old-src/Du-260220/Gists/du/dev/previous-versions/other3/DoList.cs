// ---------------------------------------------------------------------------------------------------------------------
// Name: DoList.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with lists.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace AO
{
    public class DoList
    {
        /// <summary>Convert list to array</summary>
        /// <param name="toConvert"></param>
        /// <returns></returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string[] ContentAsArray(List<string> toConvert)
        {
            var elementCount = 0;
            var stringArray = new string[toConvert.Count];

            foreach (var item in toConvert)
            {
                stringArray[elementCount] = item;
                elementCount++;
            }
            return stringArray;
        }

        public static Dictionary<string, string> ContentAsDictionary(List<string> toConvert, char delim)
        {
            return DoArray.ContentAsDictionary(ContentAsArray(toConvert), delim);
        }

        /// <summary>Extracts a dictionary from a list of dictionaries.</summary>
        /// <param name="extractFrom">The list of dictionaries to extract from.</param>
        /// <param name="dictionaryToExtract">The dictionary to extract.</param>
        /// <returns>The extracted dictionary.</returns>
        /// <remarks>None</remarks>
        /// <build>160719</build>
        public static Dictionary<string, string> ExtractDictionary(List<Dictionary<string, string>> extractFrom, int dictionaryToExtract)
        {
            Dictionary<string, string> wrkDictionary = new Dictionary<string, string>();

            foreach (var item in extractFrom[dictionaryToExtract])
            {
                wrkDictionary.Add(item.Key, item.Value);
            }

            return wrkDictionary;
        }

        /// <summary>QUICK</summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static List<string> Merge(List<string> first, List<string> second)
        {
            foreach (var item in second)
            {
                first.Add(item);
            }
            return first;
        }

        /// <summary> </summary>
        /// <param name="listToFilter"></param>
        /// <param name="rmEmpty"></param>
        /// <param name="rmComment"></param>
        /// <param name="commentChar"></param>
        /// <returns></returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static List<string> Remove(List<string> toProcess, bool rmEmpty, char commentChar)
        {
            var wrkList = new List<string>(); // List to return

            // Add element to list if it passes audit
            foreach (var element in toProcess)
            {
                if (DoString.Test(element, rmEmpty, commentChar))
                {
                    wrkList.Add(element);
                }
            }
            return wrkList;
        }

        /// <summary>Remove null values from an list</summary>
        /// <param name="removeFrom">The list to remove nulls from</param>
        /// <returns>An array without null values</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static List<string> RemoveNulls(List<string> removeFrom)
        {
            var wrkList = new List<string>(); // List to return

            foreach (var item in removeFrom)
            {
                if (item != null)
                {
                    wrkList.Add(item);
                }
            }
            return wrkList;
        }


        public static List<string> SectionAsList(List<string> toWork, string sectionChar, string sectionDelim)
        {
            List<string> sectionList = new List<string>();
            bool recording = false;

            foreach (var item in toWork)
            {
                if (recording && item.StartsWith(sectionChar))
                {
                    recording = false;
                    break;
                }
                if (recording)
                {
                    sectionList.Add(item);
                }
                if (item == sectionDelim)
                {
                    recording = true;
                }
            }
            return sectionList;
        }

        public static List<List<string>> SectionsAsListOfLists(List<string> toWork, string sectionChar, string sectionDelim)
        {
            List<string> sectionList = new List<string>();
            List<List<string>> sectionsListOfLists = new List<List<string>>();
            bool recording = false;

            foreach (var item in toWork)
            {
                if (recording && item.StartsWith(sectionChar))
                {
                    recording = false;
                    //break;
                }
                if (recording)
                {
                    sectionList.Add(item);
                }
                if (item == sectionDelim)
                {
                    recording = true;
                }
            }
            return sectionsListOfLists;
        }

    }
}

// CHANGELOG
// =========
// 00.90.00.160717: Initial release
// 00.90.01.160731: Code and comment cleanup; added "ExtractDictionary" function

// ROADMAP
// =======
// * Proper error handling

// NOTES
// =====