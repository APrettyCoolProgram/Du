// ---------------------------------------------------------------------------------------------------------------------
// Name: DoString.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with strings.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;

namespace AO
{
    public class DoString
    {
        /// <summary>Convert a string to an array.</summary>
        /// <param name="toConvert">String to convert.</param>
        /// <returns>An array with the file contents.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string[] ContentAsArray(string toConvert)
        {
            var stringAsArray = toConvert.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            return stringAsArray;
        }

        /// <summary>Count characters or lines in a string.</summary>
        /// <param name="toParse">String to parse.</param>
        /// <param name="countWhat">What to count [characters/lines].</param>
        /// <returns>The number of characters or lines a the string.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static int Count(string toParse, string countWhat)
        {
            var numberOfThings = 0;

            switch (countWhat)
            {
                case "characters":
                    numberOfThings = toParse.Length;
                    break;

                case "lines":
                    numberOfThings = toParse.Split('\n').Length;
                    break;

                default:
                    numberOfThings = 001; //TODO Error trap
                    break;
            }

            return numberOfThings;
        }

        /// <summary>Remove line/newlines/nulls from a string.</summary>
        /// <param name="toParse">String to parse.</param>
        /// <param name="removeWhat">What to remove [line/newlines/nulls].</param>
        /// <param name="lineToRemove">Optional line to remove.</param>
        /// <returns>The string with the line/newlines/nulls removed.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string Remove(string toParse, string removeWhat, string lineToRemove)
        {
            var newString = string.Empty;
            StringReader stringToRead = new StringReader(toParse);

            while (stringToRead.ReadLine() != null)
            {
                switch (removeWhat)
                {
                    case "line":
                        if (stringToRead.ReadLine() != lineToRemove)
                        {
                            newString = newString + stringToRead.ReadLine();
                        }
                        break;

                    case "newlines":
                        if (stringToRead.ReadLine().EndsWith("\r\n"))
                        {
                            newString = newString + DoString.Replace(stringToRead.ReadLine(), "\r\n", "");
                        }
                        break;

                    case "nulls": // Currently not implemented
                        break;

                    default: //TODO Error trap
                        newString = "ERROR 001 - DoString.Remove: Invaild argument.";
                        break;
                }
            }

            return newString;
        }

        /// <summary>Replace a part of a string.</summary>
        /// <param name="toModify">String to parse.</param>
        /// <param name="replaceThis">The part of the string to replace.</param>
        /// <param name="withThis">The replacement.</param>
        /// <returns>The modified string.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string Replace(string toModify, string replaceThis, string withThis)
        {
            var modifiedString = toModify.Replace(replaceThis, withThis);

            return modifiedString;
        }

        /// <summary>Split a string at a delimiter.</summary>
        /// <param name="toSplit">The string to split.</param>
        /// <param name="delimiter">The delimiter to split at.</param>
        /// <returns>An array with the split values.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string[] Split(string toSplit, char delimiter)
        {
            var splitString = toSplit.Split(delimiter);

            return splitString;
        }

        /// <summary>Check to see if a string meets requirements.</summary>
        /// <param name="toProcess">String to check.</param>
        /// <param name="checkEmpty">Remove empty lines.</param>
        /// <param name="commentChar">Remove comments.</param>
        /// <param name="commentChar">Comment character.</param>
        /// <returns>Wether or not the string met requirements.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static bool Test(string toCheck, bool checkEmpty, char commentChar)
        {
            if ((toCheck == string.Empty && checkEmpty) ||
                 toCheck.StartsWith(commentChar.ToString()) && commentChar != ' ')                                            // If checking for empties, and the line is not empty OR if there is a comment char, and the line starts with that char
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Write a string to a file.</summary>
        /// <param name="filePath">The path of the file to write to.</param>
        /// <param name="toWrite">The string to write.</param>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static void Write(string filePath, string toWrite)
        {
            File.WriteAllText(filePath, toWrite);
        }
    }
}

// CHANGELOG
// =========
// 00.90.00.160717: Initial release
// 00.90.01.160731: Code and comment cleanup

// ROADMAP
// =======
// * Proper error handling

// NOTES
// =====