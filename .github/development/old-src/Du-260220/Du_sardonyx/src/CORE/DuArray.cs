/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuArray.cs
 * UPDATED: 6-23-2021-8:53 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;

namespace Du
{
    public class DuArray
    {
        /// <summary>Convert a string[] to a List<string>.</summary>
        /// <param name="stringArray">The string[] to convert.</param>\
        /// <returns>The string[] as a List<string>.</returns>
        public static List<string> ToList(string[] stringArray)
        {
            var workList = new List<string>();

            foreach(var arrayItem in stringArray)
            {
                workList.Add(arrayItem);
            }

            return workList;
        }
    }
}