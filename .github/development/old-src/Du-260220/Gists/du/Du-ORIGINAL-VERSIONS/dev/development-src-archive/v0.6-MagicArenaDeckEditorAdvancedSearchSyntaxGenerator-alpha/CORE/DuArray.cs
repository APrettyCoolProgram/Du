/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuArray.cs
 * UPDATED: 1-27-2021-8:24 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;

namespace Du
{
    /// <summary>Does various things with Arrays</summary>
    public class DuArray
    {
        /// <summary>Convert a string[] to a List<string>.</summary>
        /// <param name="stringArray">The string[] to convert.</param>
        /// <returns>The values in the string[] as a list of string.</returns>
        public static List<string> ToList(string[] stringArray)
        {
            // NOT TESTED
            var listOfStrings = new List<string>();

            foreach(var stringItem in stringArray)
            {
                listOfStrings.Add(stringItem);
            }

            return listOfStrings;
        }
    }
}