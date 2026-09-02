#region CLASS_HEADER
//   PROJECT: STMConvert
//  FILENAME: DuArray.cs
//   VERSION: 0.16.0-alpha
//     BUILD: 180228
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/STMConvert
#endregion

#region USING
using System;
#endregion

namespace Du
{
    public class DuArray
    {
        /// <summary>Convert an array to a string.</summary>
        /// <param name="arrayToConvert">The array to convert.</param>
        /// <param name="seperateElementsBy">What to seperate the elements by (Default: "none").</param>
        /// <param name="delimiter">The delimiter to use.</param>
        /// <returns>The array as a string.</returns>
        /// <remarks></remarks>
        /// <build>180228</build>
        public static string ToString(string[] arrayToConvert, string seperateElementsBy = "none", char? delimiter = null)
        {
            var wrkString = string.Empty;

            foreach (var element in arrayToConvert)
            {
                wrkString += element;

                switch (seperateElementsBy)
                {
                    case "delimiter":
                        wrkString += delimiter;

                        break;
                    case "newLine":
                        wrkString += Environment.NewLine;

                        break;
                    default:

                        // Don't add anything between elements.
                        break;
                }
            }

            return wrkString;
        }
    }
}