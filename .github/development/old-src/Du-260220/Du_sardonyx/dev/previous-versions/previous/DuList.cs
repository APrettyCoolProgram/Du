#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuList.cs
//   VERSION: 0.17
//     BUILD: 180319
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with Lists.
#endregion

#region USING
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Du
{
    public class DuList
    {
        /// <summary>Splits a list into a dictionaries of multiple lists.</summary>
        /// <param name="masterList">   The master list.</param>
        /// <param name="subListStart"> The character that indicates a sublist is starting (i.e. "{").</param>
        /// <param name="subListEnd">   The character that indicates a sublist is ending (i.e. "}").</param>
        /// <returns>A dictionary of lists.</returns>
        /// <remarks>This is like a poor man's JSON, useful for simple lists. Most of the time, however, you'll be
        /// better off using JSON.Each of these lists is stored in a dictionary, and has a name("title"). If this item
        /// starts with the subListStart character, it's the title of a sublist so clear the current workList and strip
        /// the subListStart character from the item and store it as the subListTitle. If this item starts with the
        /// subListEnd character, then it's the end of the list, so add the title and the workList to the dictionary.
        /// Otherwise, build the workList.</remarks>
        /// <build>180227</build>
        public static Dictionary<string, List<string>> ToDictionaryOfLists(List<string> masterList, char subListStart, char subListEnd)
        {
            var masterDictionary = new Dictionary<string, List<string>>();
            var workList         = new List<string>();
            var subListTitle     = string.Empty;

            foreach (var item in masterList)
            {
                if (item.StartsWith(subListStart.ToString()))
                {
                    workList.Clear();
                    subListTitle = item.Substring(1);
                }
                else if (item.StartsWith(subListEnd.ToString()))
                {
                    // Needs to be "workList.ToList()" instead of "workList" since workList is a pointer.
                    masterDictionary.Add(subListTitle, workList.ToList());
                }
                else
                {
                    workList.Add(item);
                }
            }

            return masterDictionary;
        }

        /// <summary>List to a file.</summary>
        /// <param name="originalList"></param>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static void ToFile(List<string> originalList)
        {
            var yo = string.Empty;

            foreach (var item in originalList)
            {
                yo += item;
            }

            DuString.ToFile(@"./AppData/test1.ecps", yo);
        }

        /// <summary> Check to see if a list is empty.</summary>
        /// <param name="listToCheck">The list to check.</param>
        /// <returns>True/false</returns>
        /// <remarks></remarks>
        /// <build>180319</build>
        public static bool IsEmpty(List<string> listToCheck)
        {
            return listToCheck.Count == 0;

        }

        /// <summary>Remove items from a list that start with something.</summary>
        /// <param name="list">The name of the list.</param>
        /// <param name="character">The comment character (i.e. '#').</param>
        /// <returns>A list without comments.</returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static List<string> RemoveItemsThatStartWith(List<string> list, char character)
        {
            var wrkList = new List<string>();

            foreach (var item in list)
            {
                if (!item.StartsWith(character.ToString()))
                {
                    wrkList.Add(item);
                }
            }

            return wrkList;
        }

        /// <summary>Remove items from a list that start with something.</summary>
        /// <param name="list">The name of the list.</param>
        /// <param name="excludedChars"></param>
        /// <returns>A list without comments.</returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static List<string> RemoveItemsThatStartWith(List<string> list, List<string> excludedChars)
        {
            var wrkList = new List<string>();

            foreach (var item in list)
            {
                if (!excludedChars.Contains(item[0].ToString()))
                {
                    wrkList.Add(item);
                }
            }

            return wrkList;
        }

        /// <summary>Remove blank items from a list.</summary>
        /// <param name="list">The name of the list.</param>
        /// <returns>A list without blank items.</returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static List<string> RemoveBlanks(List<string> list)
        {
            return list.Where(item => item != "" && !string.IsNullOrEmpty(item)).ToList();
        }

        /// <summary>Convert a list to an array.</summary>
        /// <param name="list">        The list to convert.</param>
        /// <param name="delimiter"> The delimiter character (i.e. '=').</param>
        /// <param name="startAtZero"> Start the counter at zero [true/false].</param>
        /// <returns>The list as an array.</returns>
        /// <remarks>Converts a list to a string array. Generally you want to start the counter at "0", but if you need
        /// to skip the first item of the list, just pass "false" for "startAtZero".</remarks>
        /// <build>180227</build>
        public static List<string>[] ToArray(List<string> list, char delimiter, bool startAtZero)
        {
            var wrkArray = startAtZero
                ? new List<string>[list.Count]
                : new List<string>[list.Count + 1];

            var element = startAtZero
                ? 0
                : 1;

            foreach (var item in list)
            {
                wrkArray[element] = DuString.ToList(item, delimiter);
                element++;
            }

            return wrkArray;
        }
    }
}