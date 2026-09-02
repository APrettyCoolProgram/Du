#region HEADER
//   PROJECT: Du
//  FILENAME: DuString.cs
//   VERSION: 0.17.0
//     BUILD: 180819
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with strings.
#endregion


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Du
{
    public class DuString
    {
        /// <summary>Converts a string to a List<string>, splitting values at a delimiter.</summary>
        /// <param name="toConvert"> The string to convert.</param>
        /// <param name="delimiter"> The delimiter. </param>
        /// <returns>A string list. </returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static List<string> Create(string toConvert, char delimiter)
        {
            return toConvert.Split(delimiter).ToList();
        }

        /// <summary>Checks to see if a string is blank.</summary>
        /// <param name="toCheck"> The string to check.</param>
        /// <returns>If the string is blank [true/false].</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static bool IsBlank(string toCheck)
        {
            return toCheck == "" || toCheck == " " || String.IsNullOrEmpty(toCheck);
        }

        /// <summary>Returns a substring.</summary>
        /// <param name="toCheck"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <build>180319</build>
        public static string GetSubstring(string toCheck, int start, int end)
        {

            return toCheck.Substring(start, end);
        }


        /// <summary>Checks to see if a string starts with a specific character.</summary>
        /// <param name="toCheck">   The string to check.</param>
        /// <param name="character"> The character that starts a comment string.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static bool StartsWith(string toCheck, char character)
        {
            return toCheck.StartsWith(character.ToString());
        }



        /// <summary>Converts a string to a file.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stringToWrite"></param>
        /// <remarks></remarks>
        /// <build>180225</build>
        // TODO Replace w/StringWriter or something?
        public static void ToFile(string fileName, string stringToWrite)
        {
            File.WriteAllText(fileName, stringToWrite);
        }

        /// <summary>Checks if a specfic character exists at a specific location</summary>
        /// <param name="stringToCheck">The string to check</param>
        /// <param name="location">The loation to check</param>
        /// <param name="character">The character to check for</param>
        /// <returns>True/false</returns>
        /// <remarks></remarks>
        /// <build>180319</build>
        public static bool NthCharacterIs(string stringToCheck, int location, char character)
        {
            return stringToCheck.ToCharArray()[location] == character;
        }

        /// <summary>Converts a string to a file.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stringToWrite"></param>
        /// <remarks></remarks>
        /// <build>180225</build>
        // TODO Replace w/StringWriter or something?
        public static void ToFile(string fileName, string fileExtension, string stringToWrite)
        {
            File.WriteAllText(fileName + fileExtension, stringToWrite);
        }

        /// <summary>Add content to the beginning of a string</summary>
        /// <param name="stringToAddTo">The string to add to.</param>
        /// <param name="contentToAdd">The content to add.</param>
        /// <returns>A new string with the content at the beginning.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string Prepend(string contentToAdd, string stringToAddTo)
        {
            return contentToAdd + stringToAddTo;
        }

        /// <summary>Removes specified content from the beginning of a string.</summary>
        /// <param name="toModify">The string to remove from.</param>
        /// <param name="content">The content to remove.</param>
        /// <returns>The string with the content removed from the beginning.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveLeadingContent(string toModify, string content)
        {
            return toModify.Substring(content.Length);
        }

        /// <summary>Removes leading and trailing whitespace from a string.</summary>
        /// <param name="toModify">The string to modify.</param>
        /// <returns>The string without leading or trailin whitespace.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveBookendWhitespace(string toModify)
        {
            return toModify.Trim();
        }

        /// <summary> Removes empty lines.</summary>
        /// <param name="toModify">The string to modify.</param>
        /// <returns>The string without leading or trailin whitespace.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveBlanks(string toModify)
        {
            var asList = ToList(toModify, null);
            var withoutBlanks = String.Empty;

            foreach (var item in asList)
            {
                if (!String.IsNullOrWhiteSpace(item))
                {
                    withoutBlanks = withoutBlanks + item + Environment.NewLine;
                }
            }

            return withoutBlanks;
        }

        /// <summary>Removes empty lines.</summary>
        /// <param name="toModify">The string to modify.</param>
        /// <returns>The string without leading or trailin whitespace.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveLinesThatStartWith(string toModify, string startsWith)
        {
            var asList        = ToList(toModify, null);
            var newString = String.Empty;

            foreach (var item in asList)
            {
                if (!item.StartsWith(startsWith))
                {
                    newString = newString + item + Environment.NewLine;
                }
            }

            return newString;
        }

        /// <summary>Removes empty lines.</summary>
        /// <param name="toModify">The string to modify.</param>
        /// <returns>The string without leading or trailin whitespace.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveLinesThatStartWith(string toModify, List<string> excludedLines)
        {
            var asList    = ToList(toModify, null);
            var newString = String.Empty;

            foreach (var item in asList)
            {
                foreach (var excludedLine in excludedLines)
                {
                    if (!item.StartsWith(excludedLine))
                    {
                        newString = newString + item + Environment.NewLine;
                    }
                }
            }

            return newString;
        }

        /// <summary>Removes leading whitespace from a string.</summary>
        /// <param name="toModify"> The string to modify.</param>
        /// <returns>The string without leading whitespace.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveLeadingWhitespace(string toModify)
        {
            return toModify.TrimStart();
        }

        /// <summary>Removes trailing whitespace from a string.</summary>
        /// <param name="stringToModify">The string to modify.</param>
        /// <returns>The string without trailing whitespace.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveTrailingWhitespace(string stringToModify)
        {
            return stringToModify.TrimEnd();
        }
    }
}