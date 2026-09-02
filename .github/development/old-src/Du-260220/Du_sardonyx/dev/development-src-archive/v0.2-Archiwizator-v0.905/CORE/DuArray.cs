/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuArray.cs
 * UPDATED: 12-31-2020-11:35 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  This is a work-in-progress, and some of these methods have not been extensively tested yet.
 */

using System.Collections.Generic;

namespace Du
{
    public class DuArray
    {
        /// <summary>Convert a string array to a List of strings.</summary>
        /// <param name="stringArray">The string array to convert.</param>
        /// <returns>The values in the stringArray as a list of string.</returns>
        public static List<string> ToList(string[] stringArray)
        {
            /* NOT TESTED */

            var listOfStrings = new List<string>();

            foreach(var stringItem in stringArray)
            {
                listOfStrings.Add(stringItem);
            }

            return listOfStrings;
        }

        public static string ToString(string[] stringArray)
        {
            /* NOT TESTED */

            return "";
        }
    }
}