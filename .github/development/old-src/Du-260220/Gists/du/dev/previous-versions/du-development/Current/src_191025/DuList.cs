// ===========================================================================================================  1:16 PM
//    FILENAME: DuList.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for Lists.
 */
using System;
using System.Collections.Generic;

namespace Du
{
    public class DuList
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static List<string> RemoveFirstItem(List<string> stringList)
        {
            stringList.RemoveAt(0);
            return stringList;
        }

        /// <summary>
        /// Converts a List<string> to a string
        /// </summary>
        /// <param name="listToConvert">The list that will be converted to a string.</param>
        /// <returns>The list as a string.</returns>
        public static string ToString(List<string> listToConvert)
        {
            var listAsString = "";

            foreach (var line in listToConvert)
            {
                listAsString += line + Environment.NewLine;
            }

            return listAsString;
        }


    }
}