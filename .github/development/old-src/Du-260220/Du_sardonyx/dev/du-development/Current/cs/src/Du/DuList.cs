// =============================================================================
//        FILE: DuList.cs
// DESCRIPTION: Common methods for doing things with Lists
//     PROJECT: Du.cs
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: 2019 A Pretty Cool Program.com
//     LICENSE: Apache License, Version 2.0
//        MORE: https://github.com/APrettyCoolProgram/Du
// ===================================================================================================================== 

using System;
using System.Collections.Generic;

namespace Du
{
    public class DuList
    {
        /// <summary>Converts a List<string> to a string</summary>
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
