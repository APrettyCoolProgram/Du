// ===========================================================================================================  1:17 PM
//    FILENAME: DuArray.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for arrays.
 */
using System;
using System.Collections.Generic;

namespace Du
{
    public class DuArray
    {
         /// <summary>
        /// Converts an array to a dictionary.
        /// </summary>
        /// <param name="stringArray">The array to convert.</param>
        /// <param name="delimiter">Ex: '=', ',' (default: '=').</param>
        /// <returns>A dictionary with the array contents.</returns>
        public static Dictionary<string, string> DeDictionary(string[] stringArray, char delimiter = '=')
        {
            /* Takes a string[] with elements that look like this:
             *
             *  key1=value1
             *  key2=value2
             *  ...
             *
             * and converts it into a Dictionary<string, string> that looks like this:
             *
             *  {key1, value1}
             *  {key2, value2}
             *  ...
             */
            //var keyValuePair      = new string[1];
            var arrayAsDictionary = new Dictionary<string, string>();

            foreach (var element in stringArray)
            {
                var keyValuePair = element.Split(delimiter);
                arrayAsDictionary.Add(keyValuePair[0], keyValuePair[1]);
            }

            return arrayAsDictionary;
        }

        /// <summary>
        /// Convert an array to a string, with optional new lines.
        /// </summary>
        /// <param name="stringArray">The string array to convert.</param>
        /// <param name="insertNewLine">[true/false]</param>
        /// <returns>The array as a string.</returns>
        public static string DeString(string[] stringArray, bool insertNewLine = true)
        {
            /* Takes a string[] with elements that look like this:
             *
             *  key1=value1
             *  key2=value2
             *  ...
             *
             * and converts it into a string that looks like this:
             *
             *  key1=value1 key2=value2...
             *
             *
             *
             */
            var arrayAsString = string.Empty;

            foreach (var element in stringArray)
            {
                arrayAsString += insertNewLine
                    ? element + Environment.NewLine
                    : element + " ";
            }

            return arrayAsString;
        }

        /// <summary>
        /// Convert an array to a string.
        /// </summary>
        /// <param name="stringArray">The array to convert.</param>
        /// <param name="delimiter">Ex: "=".</param>
        /// <returns>The array as a string.</returns>
        public static string DeString(string[] stringArray, char delimiter)
        {
            var arrayAsString = string.Empty;

            foreach (var element in stringArray)
            {
                arrayAsString += element + delimiter;
            }

            return arrayAsString;
        }
    }
}