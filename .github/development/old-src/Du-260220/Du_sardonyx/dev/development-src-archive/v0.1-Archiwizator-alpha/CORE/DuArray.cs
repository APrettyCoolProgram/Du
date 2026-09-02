/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuArray.cs
 * UPDATED: 12-30-2020-8:48 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;

namespace Du
{
    public class DuArray
    {
        /// <summary>Convert a string[] to a List<string>.</summary>
        /// <param name="workArray">The array[] to convert.</param>
        /// <returns>The string[] as a List<string>.</returns>
        public static List<string> ToList(string[] workArray)
        {
            var arrayAsList = new List<string>();

            foreach(var item in workArray)
            {
                arrayAsList.Add(item);
            }

            return arrayAsList;
        }
    }
}