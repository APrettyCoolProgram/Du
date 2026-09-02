/* A class for AO.cs that does various things with lists.
 * v00.53.04.161220
 * http://aprettycoolprogram.com/ao
 */

using System.Collections.Generic;

namespace AO
{
    public class AOList
    {
        /* Convert a list to an array.
         * ---
         * toConvert - the list to convert                                                                            */

        /// <summary>
        /// To the array.
        /// </summary>
        /// <param name="toConvert">To convert.</param>
        /// <returns></returns>
        public static string[] ToArray(List<string> toConvert)
        {
            var element = 0;
            var wrkArray = new string[toConvert.Count];

            /* Loop through the list and add each item to the wrkArray, incrementing the element each time.           */
            foreach (var item in toConvert)
            {
                wrkArray[element] = item;
                element++;
            }

            return wrkArray;
        }

        /* Extracts a dictionary from a list of dictionaries.
         * You'll need to know the location of the dictionary you want to extract.
         * ---
         * extractFrom      - the list of dictionaries to extract from
         * dictionaryNumber - the dictionary to extract                                                               */

        public static Dictionary<string, string> ExtractDictionary(List<Dictionary<string, string>> extractFrom, int dictionaryNumber)
        {
            Dictionary<string, string> wrkDictionary = new Dictionary<string, string>();

            // Loop through each key/value pair in the specific dictionary, and add them to the wrkDictionary.        */
            foreach (var keyValuePair in extractFrom[dictionaryNumber])
            {
                wrkDictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return wrkDictionary;
        }

        /* Merge two lists.
         * ---
         * firstList  - the first list
         * secondList - the second list                                                                               */
        public static List<string> Merge(List<string> firstList, List<string> secondList)
        {
            /* Loop through the items in the second list, and add it to the first list.                               */
            foreach (var item in secondList)
            {
                firstList.Add(item);
            }

            return firstList;
        }

        /* Remove something from a list.
         * ---
         * toClean     - the list to clean
         * checkEmpty  - flag to check if the item is empty
         * commentChar - the character that starts a comment line                                                     */
        public static List<string> Clean(List<string> toClean, bool checkEmpty, char commentChar)                       // TODO - Maybe combine this with below?
        {                                                                                                               // TODO - Fix to use CleaningRules
            var wrkList = new List<string>();

            foreach (var item in toClean)
            {
                if ((checkEmpty && !AOString.CheckEmpty(item, null)) || (commentChar != ' ' && !AOString.CheckComment(item, commentChar)))
                {
                    wrkList.Add(item);
                }
            }

            return wrkList;
        }

        /* Remove null values from an list.
         * ---
         * removeFrom - the string to remove nulls from                                                               */
        public static List<string> RemoveNulls(List<string> removeFrom)                                                 // TODO - Additional comments
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

        /* Returns a specific section of a list.
         * ---
         * toWork       -
         * sectionChar  -
         * sectionDelim -                                                                                             */
        public static List<string> SectionAsList(List<string> toWork, string sectionChar, string sectionDelim)          // TODO - Additional comments
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

        /* Splits a list into multiple sections.
         * ---
         * toConvert    -
         * sectionChar  -
         * sectionDelim -                                                                                             */
        public static List<List<string>> SectionsAsLists(List<string> toConvert, string sectionChar, string sectionDelim) // TODO - Additional comments
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