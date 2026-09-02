/* A class for AO.cs that does various things with arrays.
 * v00.53.02.161018
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace AO
{
    public class AOArray
    {
        /// <summary>
        /// Count the number of an characters in an array.
        /// </summary>
        /// <param name="arrayToCount">Array to count.</param>
        /// <returns>Counts the number of characters in an array.</returns>
        /// <remarks>
        /// TODO - Allow this method to count a specific character
        /// </remarks>
        public static int CountChars(string[] arrayToCount)
        {
            var totalChars = 0;

            foreach (var element in arrayToCount)
            {
                totalChars = totalChars + element.Length;
            }

            return totalChars;
        }

        /// <summary>
        /// Count the number of elements in an array.
        /// </summary>
        /// <param name="arrayToCount">Array to count.</param>
        /// <returns>Counts the number of elements in an array.</returns>
        /// <remarks>
        /// COMING SOON!
        /// </remarks>
        public static int CountElements(string[] arrayToCount)
        {
            return 0;
        }

        /// <summary>
        /// Join multiple arrays.
        /// </summary>
        /// <param name="arraysToJoin">List of arrays to join.</param>
        /// <param name="joinType">Type of join.</param>
        /// <returns>The joined array.</returns>
        /// <remarks>
        /// [*] The two types of joins are "concat" (which handles duplicates), and "union" (which does not).
        /// [1] Increase wrkArray size to fit the next array that will be joined.
        /// </remarks>
        public static string[] Join(List<string[]> arraysToJoin, string joinType)
        {
            var wrkArray = new string[0];

            foreach (var item in arraysToJoin)
            {
                Array.Resize(ref wrkArray, item.Length);                                                                // [1]
                wrkArray = (joinType == "concat") ? wrkArray.Concat(item).ToArray() : wrkArray.Union(item).ToArray();
            }

            return wrkArray;
        }

        /// <summary>
        /// Remove an item type from an array.
        /// </summary>
        /// <param name="arrayToRemoveFrom">Array to remove from.</param>
        /// <param name="itemTypeToRemove">Item to remove [empties/nulls/comments/all].</param>
        /// <param name="commentChar">Character that starts a comment line</param>
        /// <returns>The number of items.</returns>
        /// <remarks>
        /// [*] Initially all of the work is done with a list, which is then converted to an Array prior to returning.
        /// [1] Loop through each of the array elements, and check to see if they DO NOT match the itemTypeToRemove. If
        ///     there is no match, add the element to the wrkList.For instance, if you're removing empty elements, and
        ///     the current element IS NOT empty, add it to the list.Notice that when removing all item types, we first
        ///     check to see if the element is null (don't add to wrkList), and if it's not we check to see if the
        ///     element is either empty OR a comment, and if it is neither, we add it to the list.
        /// [2] If the itemTypeToRemove is "comments", the commentCharacter must be a single character(i.e. '#'),
        ///     otherwise it should be ' '. This parameter is required!
        /// </remarks>
        public static string[] RemoveItem(string[] arrayToRemoveFrom, string itemTypeToRemove, char commentChar)
        {
            var isEmpty = false;
            var isComment = false;
            var isNull = false;
            var wrkList = new List<string>();

            foreach (var element in arrayToRemoveFrom)                                                                  // [1]
            {
                isEmpty = AOString.CheckEmpty(element, "allQuotes");
                isNull = AOString.CheckNull(element);
                isComment = AOString.CheckComment(element, '#');

                switch (itemTypeToRemove)
                {
                    case "empties":
                        if (!isEmpty)
                        {
                            wrkList.Add(element);
                        }
                        break;

                    case "comments":                                                                                    // [2]
                        if (!isComment)
                        {
                            wrkList.Add(element);
                        }
                        break;

                    case "nulls":
                        if (!isNull)
                        {
                            wrkList.Add(element);
                        }
                        break;

                    case "all":
                        if (!isNull)
                        {
                            break;
                        }
                        else
                        {
                            if (!isEmpty && !isComment)
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

        /// <summary>
        /// Convers an array to a dictionary.
        /// </summary>
        /// <param name="arrayToConvert"></param>
        /// <param name="delimiter"></param>
        /// <returns>A dictionary as an array.</returns>
        /// <remarks>
        /// [*] In order for this to work, the array elements must contain a key/value pair seperated by a delimiter,
        ///     and the delimiter must be a single character (i.e. "=" or "\t").
        /// </remarks>
        public static Dictionary<string, string> ToDictionary(string[] arrayToConvert, char delimiter)
        {
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
        /// <param name="arrayToConvert"></param>
        /// <param name="delimiter">must be a single character, i.e. '=', '\t'.</param>
        /// <param name="innerArraySize"></param>
        /// <remarks>
        /// [*] This method is used when you have an single array where each element contains a string seperated by a
        ///     delimeter, i.e.:
        ///         anArray[0] = "one, two, three"
        ///         anArray[1] = "red, white, blue"
        ///         ...
        ///     and you want to seperate that string at the delimiter and put the results in individual elements of a
        ///     new array, then put all of those new arrays into a master array, i.e.:
        ///         masterArray[0, 0] = "one"
        ///         masterArray[0, 1] = "two"
        ///         masterArray[0, 2] = "three"
        ///         masterArray[1, 0] = "red"
        ///         masterArray[1, 1] = "white"
        ///         masterArray[1, 2] = "blue"
        ///         ...
        /// [1] In order to hold all of the necessary data, the masterArray needs to be as long as the passed array, so
        ///     set the number of ranks the masterArray has to the number of elements the passed array has. Finally,
        ///     since we're creating a brand new masterArray, init the rank/element so we start at the beginning. Also,
        ///     innerArraySize is currently hardcoded via the passed innerArraySize parameter,which means that the
        ///     passed variable needs to be >= to the largest innerArray size.If each inner array needs to be a
        ///     different size, use AOArray.ToJagged().
        /// [2] Loop through the passed array elements. Each element contains a string that will be split at the
        ///     delimiter, and placed into a temporary "innerElements" array.Since each iteration of this outer foreach
        ///     loop will create a new "inner" array, reset "masterArrayInner" every new loop.
        /// [3] Loop through each of the elements in the newly created "innerElements" array, and put each of those
        ///     items in seperate elements of the current rank of the masterArray.When this inner foreach loop is
        ///     complete, increment the masterArray rank so the outer foreach loop adds to the next rank.
        ///
        ///
        /// </remarks>
        /// <returns>A dictionary.</returns>
        public static string[,] ToMultiArray(string[] arrayToConvert, char delimiter, int innerArraySize)
        {
            var wrkMasterArray = new string[arrayToConvert.Length, innerArraySize];                                     // [1]
            var masterArrayOuter = 0;
            var masterArrayInner = 0;
            string[] innerElements;

            foreach (var outerElement in arrayToConvert)                                                                // [2]
            {
                innerElements = AOString.ToArray(outerElement, delimiter);
                masterArrayInner = 0;

                foreach (var innerElement in innerElements)                                                             // [3]
                {
                    wrkMasterArray[masterArrayOuter, masterArrayInner] = innerElement;
                    masterArrayInner++;
                }
                masterArrayOuter++;
            }

            return wrkMasterArray;
        }

    }
}