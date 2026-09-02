/* A class for AO.cs that does various things with arrays.
 * v00.52.160928
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace AO
{
    public class AOArray
    {
        /// <summary>Convert an array to a dictionary.</summary>
        /// <param name="arrayToConvert">Array to convert.</param>
        /// <param name="delimiter">Delimiter used to seperate keys and values (i.e. "=", "\t").</param>
        /// <returns>Dictionary with the array contents.</returns>
        public static Dictionary<string, string> AsDictionary(string[] arrayToConvert, char delimiter)
        {
            /* In order for this to work, each element must contain a key/value pair seperated by a delimiter. */

            var keyValuePair = new string[1];
            var wrkDictionary = new Dictionary<string, string>();

            foreach (var element in arrayToConvert)
            {
                keyValuePair = element.Split(delimiter);
                wrkDictionary.Add(keyValuePair[0], keyValuePair[1]);
            }

            return wrkDictionary;
        }

        /// <summary>Convert the contents of single array into a multi-dimentional array.</summary>
        /// <param name="arrayToConvert">Array to convert.</param>
        /// <param name="delimiter">Delimiter used to seperate keys and values (example: ",", "\t").</param>
        /// <param name="innerArraySize">Number of elements in the inner arrays.</param>
        /// <returns>Multi-dimentional array with the array contents.</returns>
        public static string[,] AsMultiDimentionalArray(string[] arrayToConvert, char delimiter, int innerArraySize)
        {
            /* This method is used when you have an single array in which each element contains a string seperated by a
             * delimeter(i.e. "one,two,three,four,five"), and you want to seperate that string at the delimiter and put
             * the results in individual elements of a new array, then put all of those new arrays into a master array.
             */

            // Initialize the master array to have a rank equal to the number of elements the passed array has, and an
            // element size equal to whatever is passed - Why is this hard-coded?
            var wrkMasterArray = new string[arrayToConvert.Length, innerArraySize];

            // Init the master array rank ("outer") and element ("inner") values so they will start at the very
            // beginning, and init the inner array.
            var masterArrayOuter = 0; // Rank
            var masterArrayInner = 0; // Element
            string[] innerElements;

            // Loop through each element of the passed (outer) array
            foreach (var outerElement in arrayToConvert)
            {
                // Split the current element at the delimiter
                innerElements = AOString.ToArray(outerElement, delimiter);
                // Reset the inner array number since this is a new inner array
                masterArrayInner = 0;

                // Loop through the items
                foreach (var innerElement in innerElements)
                {
                    // Put them in a new (eventually inner) array.
                    wrkMasterArray[masterArrayOuter, masterArrayInner] = innerElement;
                    // Increment
                    masterArrayInner++;
                }
                // Increment
                masterArrayOuter++;
            }

            return wrkMasterArray;
        }


        /// <summary>Count the number of an characters in an array.</summary>
        /// <param name="arrayToCount">Array to count.</param>
        /// <returns>Number of characters in the array.</returns>
        public static int CountCharacters(string[] arrayToCount)
        {
            /* Eventually this will also handle counting a specific character, not just all characters */

            var totalCharacters = 0;

            foreach (var element in arrayToCount)
            {
                totalCharacters = totalCharacters + element.Length;
            }

            return totalCharacters;
        }

        /// <summary>Join multiple arrays using concat or union.</summary>
        /// <param name="arraysToJoin">List of arrays to join.</param>
        /// <param name="joinType">Type of join [concat/union].</param>
        /// <returns>Joined arrays.</returns>
        public static string[] Join(List<string[]> arraysToJoin, string joinType)
        {
            var wrkArray = new string[0];

            foreach (var item in arraysToJoin)
            {
                // Resize the array to hold the array being worked on.
                Array.Resize(ref wrkArray, item.Length);
                // Concat handles duplicates, union does not.
                wrkArray = (joinType == "concat")
                    ? wrkArray.Concat(item).ToArray()
                    : wrkArray.Union(item).ToArray();
            }

            return wrkArray;
        }

        /// <summary>Remove an item type from an array.</summary>
        /// <param name="arrayToRemoveFrom">The array to remove the specified item type from.</param>
        /// <param name="itemTypeToRemove">The type of item to remove [empty/comment/null/all].</param>
        /// <param name="commentCharacter">The character that indicates a comment line ("#", "//"). Use ' ' for none.</param>
        /// <returns>The array with the item types specified removed.</returns>
        public static string[] Remove(string[] arrayToRemoveFrom, string itemTypeToRemove, char commentCharacter)
        {
            var wrkList = new List<string>();

            foreach (var element in arrayToRemoveFrom)
            {
                switch (itemTypeToRemove)
                {
                    case "empties":
                        if (!AOString.Check(element, true, ' '))
                        {
                            wrkList.Add(element);
                        }
                        break;

                    case "comments":
                        if (!AOString.Check(element, false, commentCharacter))
                        {
                            wrkList.Add(element);
                        }
                        break;

                    case "nulls":
                        if (element != null)
                        {
                            wrkList.Add(element);
                        }
                        break;

                    case "all":
                        if (element == null)
                        {
                            break;
                        }
                        else
                        {
                            if (!AOString.Check(element, true, commentCharacter))
                            {
                                wrkList.Add(element);
                            }
                        }
                        break;

                    default:
                        wrkList.Add("ERROR");
                        break;
                }
            }

            return wrkList.ToArray();
        }
    }
}

/*

/// <summary>Write the contents of an array to a file.</summary>
/// <param name="fileName">Name of the file to write to.</param>
/// <param name="dataToWrite">Array that contains the data to write.</param>
public static void AsFile(string fileName, string[] dataToWrite)
{
    File.WriteAllText(fileName, AsString(dataToWrite, true));
}

/// <summary>Converts an array to a list.</summary>
/// <param name="toConvert">The array to convert.</param>
/// <returns>A list with the array contents.</returns>
public static List<string> AsList(string[] ArrayToConvert)
{
    return ArrayToConvert.ToList();
}

/// <summary>Count the number of an characters in an array.</summary>
/// <param name="arrayToCount">Array to count.</param>
/// <returns>Number of the specified somethings in the array.</returns>
public static int Count(string[] arrayToCount, string itemTypeToCount)
{
    var totalItems = 0;

    switch (itemTypeToCount)
    {
        case "characters": // Add the length of all elements
            foreach (var element in arrayToCount)
            {
                totalItems = totalItems + element.Length;
            }
            return totalItems;

        case "elements": // Just the length of the array
            return arrayToCount.Length;

        default:
            return 0;
    }
}

/// <summary>Resizes an array.</summary>
/// <param name="arrayToResize">The array to resize.</param>
/// <param name="newSize">The length to resize to.</param>
/// <returns>The resized array.</returns>
public static string[] Resize(string[] arrayToResize, int newSize)
{
    Array.Resize(ref arrayToResize, newSize);
    return arrayToResize;
}

*/