#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuDictionary.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with dictionaries.
#endregion

#region USING
using System;
using System.Collections.Generic;
using System.IO;
#endregion

namespace Du
{
    public class DuDictionary
    {
        /// <summary>Converts a dictionary to a list.</summary>
        /// <param name="toConvert"> The dictionary to convert.</param>
        /// <returns>The dictionary as a list.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static List<string> ToList(Dictionary<string, string> toConvert)
        {
            var wrkList = new List<string>();

            foreach (var item in toConvert)
            {
                wrkList.Add(item.Key);
                wrkList.Add(item.Value);
            }
            return wrkList;
        }
    }
}