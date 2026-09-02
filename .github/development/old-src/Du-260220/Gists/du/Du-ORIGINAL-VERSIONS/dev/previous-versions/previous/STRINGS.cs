/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuString.cs
 * UPDATED: 12-31-2020-12:58 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  This is a work-in-progress, and some of these methods have not been extensively tested yet.
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Du
{
    public class DuString
    {
        public static bool DoesEndWith(string stringToCheck, string theString)
        {
            /* NOT TESTED */

            return stringToCheck.EndsWith(theString)
                ? true
                : false;
        }

        public static string AddStringToEnd(string stringToCheck, string theString)
        {
            /* NOT TESTED */

            return stringToCheck.EndsWith(theString)
                ? stringToCheck
                : (stringToCheck += theString);
        }

        public static string RemoveStringFromEnd(string stringToCheck, string theString)
        {
            /* NOT TESTED */

            return stringToCheck.EndsWith(theString)
                ? stringToCheck
                : stringToCheck.Replace(theString, "");
        }

        public static bool DoesStartWith(string stringToCheck, string theString)
        {
            /* NOT TESTED */

            return stringToCheck.StartsWith(theString)
                ? true
                : false;
        }

        public static string AddStringToStart(string stringToCheck, string theString)
        {
            /* NOT TESTED */

            return stringToCheck.StartsWith(theString)
                ? stringToCheck
                : (stringToCheck += theString);
        }

        public static string RemoveFrom(string stringToCheck, string theString)
        {
            /* NOT TESTED */

            return stringToCheck.StartsWith(theString)
                ? stringToCheck
                : stringToCheck.Replace(theString, "");
        }

        /// <summary>Determines if a string is null, empty, or whitespace.</summary>
        /// <param name="stringToCheck">The string to check.</param>
        /// <returns>If the string is null/empty/whitespace (true), or not (false).</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(string stringToCheck)
        {
            /* NOT TESTED */

            return (string.IsNullOrEmpty(stringToCheck) || string.IsNullOrWhiteSpace(stringToCheck))
                ? true
                : false;
        }

        /// <summary>Remove a line from a string.</summary>
        /// <param name="stringToCheck">The string to remove the line from.</param>
        /// <param name="lineToRemove"> The line to remove.</param>
        /// <returns>The original string without the specified line(s)</returns>
        /// <remarks>Removes lineToRemove wherever it appears in the string, even if it appears multiple times.</remarks>
        public static string RemoveLine(string stringToCheck, string lineToRemove)
        {
            /* NOT TESTED */

            var stringToRead   = new StringReader(stringToCheck);
            var modifiedString = "";

            while(true)
            {
                var currentLine = stringToRead.ReadLine();

                if(currentLine is null)
                {
                    break;
                }
                else if(currentLine != lineToRemove)
                {
                    modifiedString += stringToRead.ReadLine();
                }
            }

            return modifiedString;
        }

        /// <summary>Replaces any NewLines in a string with a space.</summary>
        /// <param name="stringToCheck">The string to replace NewLines in.</param>
        /// <returns>The original string with spaces instead of NewLines.</returns>
        public static string ReplaceNewLineWithSpace(string stringToCheck)
        {
            /* NOT TESTED */

            var stringToRead   = new StringReader(stringToCheck);
            var modifiedString = "";

            while(true)
            {
                var currentLine = stringToRead.ReadLine();

                if(currentLine is null)
                {
                    break;
                }
                else if(currentLine.EndsWith(Convert.ToChar(Environment.NewLine)))
                {
                    modifiedString += currentLine.Replace(Convert.ToChar(Environment.NewLine), ' ');
                }
            }

            return modifiedString;
        }

        // STARTS OR ENDS WITH

        /// <summary></summary>
        /// <param name="stringToCheck"></param>
        /// <param name="theString">    </param>
        /// <returns></returns>
        public static bool StartsWithString(string stringToCheck, string theString)
        {
            /* NOT TESTED */

            return stringToCheck.StartsWith(theString)
                ? true
                : false;
        }

        /// <summary>Converts a string to a string array using a delimiter.</summary>
        /// <param name="stringToCheck">The string to convert.</param>
        /// <param name="theDelimiter"> The delimiter to split at.</param>
        /// <returns>The string as a string array.</returns>
        /// <remarks>You can also pass escape characters as theDelimiter (i.e. '\t')</remarks>
        public static string[] ToArrayAtDelimiter(string stringToCheck, char theDelimiter)
        {
            /* NOT TESTED */

            return stringToCheck.Split(theDelimiter);
        }

        /// <summary>Converts a string to a string array using NewLines.</summary>
        /// <param name="stringToCheck">The string to convert.</param>
        /// <returns>The string as a string array.</returns>
        public static string[] ToArrayAtNewLine(string stringToCheck)
        {
            /* NOT TESTED */

            return stringToCheck.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        /// <summary>Converts a string to a list of strings using a delimiter.</summary>
        /// <param name="stringToCheck">The string to convert.</param>
        /// <param name="theDelimiter"> The delimiter to split at.</param>
        /// <returns>The string as a list of strings.</returns>
        /// <remarks>You can also pass escape characters as theDelimiter (i.e. '\t')</remarks>
        public static List<string> ToListAtDelimiter(string stringToCheck, char theDelimiter)
        {
            /* NOT TESTED */

            var stringArray = ToArrayAtDelimiter(stringToCheck, theDelimiter);

            return DuArray.ToList(stringArray);
        }

        /// <summary>Converts a string to a list of strings using NewLines.</summary>
        /// <param name="stringToCheck">The string to convert.</param>
        /// <returns>The string as a list of strings.</returns>
        public static List<string> ToListAtNewLine(string stringToCheck)
        {
            /* NOT TESTED */

            var stringArray = ToArrayAtNewLine(stringToCheck);

            return DuArray.ToList(stringArray);
        }
    }
}