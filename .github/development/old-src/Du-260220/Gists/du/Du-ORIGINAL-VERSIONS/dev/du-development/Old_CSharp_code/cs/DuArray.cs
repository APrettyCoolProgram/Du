//  PROJECT: Du
// FILENAME: DuArray.cs
//    BUILD: 170310
//
// Copyright 2017 A Pretty Cool Program
//
// Du is licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance
// with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations under the License.
//
// For more information about Du, please visit http://aprettycoolprogram.com/Du.
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace Du
{
    /*  This class does various things with arrays.
     */

    public class DuArray
    {
        public class Add
        {
            /// <summary>Add content to an array.</summary>
            /// <param name="contentToAdd">The content to add.</param>
            /// <param name="atElement">The location in the array to add the content.</param>
            /// <returns>The array with the added content.</returns>
            public static string[] AddContent(string contentToAdd, int atElement)
            {
                return new string[0];
            }
        }

        public class Check
        {
            /// <summary>Check to see if an array is empty.</summary>
            /// <param name="arrayToCheck">The array to check.</param>
            /// <returns>True/false.</returns>
            public static bool Empty(string[] arrayToCheck)
            {
                return false;
            }
        }

        public class Count
        {
            /// <summary>Count the number of an characters in an string array.</summary>
            /// <param name="arrayToParse">The array to parse.</param>
            /// <param name="characterToCount">The character to count.</param>
            /// <returns>Counts the number of characters in an array.</returns>
            public static int Characters(string[] arrayToParse, char characterToCount)
            {
                var totalCharacters = 0;

                /* If the characterToCount == null, count them all! */
                if (characterToCount == '\0')
                    totalCharacters = arrayToParse.Aggregate(totalCharacters, (current, item) => current + item.Length);

                return totalCharacters;
            }

            /// <summary>Count empties</summary>
            /// <returns></returns>
            public static int Empties()
            {
                // [Framework]
                return 0;
            }

            /// <summary>Count the number of elements in an array.</summary>
            /// <param name="arrayToParse">The array to parse.</param>
            /// <returns></returns>
            public static int Elements(string[] arrayToParse)
            {
                return arrayToParse.Length;
            }

            /// <summary>Count the number of nulls.</summary>
            /// <returns></returns>
            public static int Nulls()
            {
                return 0;
            }
        }

        public class Merge
        {
            /// <summary>Join multiple arrays as a single array.</summary>
            /// <param name="arraysToJoin">List of arrays to join.</param>
            /// <param name="joinType">Type of join.</param>
            /// <returns>The joined array.</returns>
            public static string[] AsArray(List<string[]> arraysToJoin, string joinType)
            {
                var wrkArray = new string[0];

                foreach (var array in arraysToJoin)
                {
                    /* Increase wrkArray size to fit the next array that will be joined. */
                    Array.Resize(ref wrkArray, array.Length);
                    wrkArray = joinType == "concat"
                        ? wrkArray.Concat(array).ToArray()
                        : wrkArray.Union(array).ToArray();
                }

                return wrkArray;
            }

            /// <summary>Joins as a dictionary.</summary>
            /// <returns></returns>
            public static Dictionary<string, string> AsDictionary()
            {
                return new Dictionary<string, string>();
            }

            /// <summary>Joins as a file.</summary>
            /// <returns></returns>
            public static void AsFile()
            {
            }

            /// <summary>Joins as a jagged array.</summary>
            /// <returns></returns>
            public static string[,] AsJaggedArray()
            {
                return new string[0, 0];
            }

            /// <summary>Joins as a list.</summary>
            /// <returns></returns>
            public static List<string> AsList()
            {
                return new List<string>();
            }

            /// <summary>Joins as a multidimensional array.</summary>
            /// <returns></returns>
            public static string[,] AsMultiDimentionalArray()
            {
                return new string[0, 0];
            }

            /// <summary>Joins as a string.</summary>
            /// <returns></returns>
            public static string AsString()
            {
                return "Framework";
            }
        }

        public class Remove
        {
            /// <summary>Removes content.</summary>
            /// <param name="arrayToRemoveFrom">The array to remove from.</param>
            /// <param name="itemTypeToRemove">The item type to remove.</param>
            /// <param name="commentCharacter">The comment character.</param>
            /// <returns></returns>
            public static string[] Content(string[] arrayToRemoveFrom, string itemTypeToRemove, char commentCharacter)
            {
                /*  This sort of works in reverse. Each of the elements of the array is checked to see if it is either
                 *  empty, a comment, or null, or all three, depending on what type of check we are doing. Then if the
                 *  element doesn't match the type of check, the element is added to the working list. For example, if
                 *  we are checking for empty elements, and the current element is empty (true), go to the next element.
                 *  If the current element is not empty (false), add it to the working list. Once the entire array has
                 *  been parsed, you will be left with a list containing all of the elements that didn't match the check
                 *  type.
                 */
                var wrkList = new List<string>();

                foreach (var element in arrayToRemoveFrom)
                    switch (itemTypeToRemove)
                    {
                        case "empties":
                            if (!DuString.Check.Empty(element, "all"))
                                wrkList.Add(element);
                            break;
                        case "comments":
                            if (!DuString.Check.Comment(element, commentCharacter))
                                wrkList.Add(element);
                            break;
                        case "nulls":
                            if (!DuString.Check.Null(element))
                                wrkList.Add(element);
                            break;
                        case "all":
                            if (!DuString.Check.Null(element) || !DuString.Check.Comment(element, commentCharacter) || !DuString.Check.Null(element))
                                wrkList.Add(element);
                            break;
                        default:
                            wrkList.Add("ERROR");
                            break;
                    }

                return wrkList.ToArray();
            }

            /// <summary>Removes an element.</summary>
            public static void Element()
            {
                // [Framework]
            }

            /// <summary>Removes all elements from an element on.</summary>
            public static void FromLocation()
            {
                // [Framework]
            }

            /// <summary>Removes all elements until an element.</summary>
            public static void ToLocation()
            {
                // [Framework]
            }
        }

        public class Replace
        {
            /// <summary></summary>
            public static void Content()
            {
                // [Framework]
            }

            /// <summary></summary>
            public static void Element()
            {
                // [Framework]
            }

            /// <summary></summary>
            public static void FromLocation()
            {
                // [Framework]
            }

            /// <summary></summary>
            public static void ToLocation()
            {
                // [Framework]
            }
        }

        public class Retrieve
        {
            /// <summary></summary>
            public static void ValueAtElement()
            {
                // [Framework]
            }

            /// <summary></summary>
            public static void ElementOfValue()
            {
                // [Framework]
            }

            /// <summary></summary>
            public static void RandomElement()
            {
                // [Framework]
            }
        }

        public class Transmorgify
        {
            /// <summary>Converts an array to a dictionary.</summary>
            /// <param name="arrayToConvert">The array to convert.</param>
            /// <param name="delimiter">The delimeter to use.</param>
            /// <returns>The array as a dictionary.</returns>
            public static Dictionary<string, string> ToDictionary(string[] arrayToConvert, char delimiter)
            {
                return arrayToConvert.ToDictionary(element => element.Split(delimiter)[0], element => element.Split(delimiter)[1]);
            }

            /// <summary>Convert an array to a file.</summary>
            /// <param name="arrayToConvert"></param>
            public static void ToFile(string[] arrayToConvert)
            {
                // [Framework]
            }

            /// <summary>Convert an array to a jagged array.</summary>
            /// <param name="arrayToConvert">The array to convert.</param>
            /// <returns>The array as a jagged array.</returns>
            public static string[,] ToJaggedArray(string[] arrayToConvert)
            {
                // [Framework]
                return new string[0, 0];
            }

            /// <summary>Convert an array to a list.</summary>
            /// <param name="arrayToConvert">The list to convert.</param>
            /// <returns>The array as a list.</returns>
            public static List<string> ToList(string[] arrayToConvert)
            {
                // [Framework]
                return new List<string>();
            }

            /// <summary>Convert an array to a multidimensional arrray.</summary>
            /// <param name="arrayToConvert">The array to convert.</param>
            /// <param name="delimiter">The delimiter to use.</param>
            /// <param name="innerArraySize">The size of the inner array.</param>
            /// <returns>The array as a multidimensional array.</returns>
            public static string[,] ToMultidimensionalArray(string[] arrayToConvert, char delimiter, int innerArraySize)
            {
                /*  This method is used when you have an single array where each element contains a string seperated by
                 *  a delimeter, and you want to seperate that string at the delimiter and put the results in individual
                 *  elements of a new array, then put all of those new arrays into a master array.
                 */
                var wrkArray = new string[arrayToConvert.Length, innerArraySize];
                var wrkArrayOuter = 0;
                string[] innerElements;

                foreach (var outerElement in arrayToConvert)
                {
                    innerElements = DuString.Morph.ToArray(outerElement, delimiter);
                    var wrkArrayInner = 0;

                    foreach (var innerElement in innerElements)
                    {
                        wrkArray[wrkArrayOuter, wrkArrayInner] = innerElement;
                        wrkArrayInner++;
                    }
                    wrkArrayOuter++;
                }

                return wrkArray;
            }


        }
    }
}