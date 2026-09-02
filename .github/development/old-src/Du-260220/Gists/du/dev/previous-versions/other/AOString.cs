/* A class for AO.cs that does various things with strings.
 * v00.51.160926
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Drawing;
using System.IO;

namespace AO
{
    public class AOString
    {
        /// <summary>Check to see if a string meets requirements.</summary>
        /// <param name="toCheck">String to check.</param>
        /// <param name="checkIsEmpty">Check to see if the string is empty.</param>
        /// <param name="checkIsComment">Check to see if the string is a comment.</param>
        /// <param name="commentChar">The character that starts a comment line.</param>
        /// <returns>True or false, depending on if the string met the requirements.</returns>
        public static bool Check(string toCheck, bool checkIsEmpty, char commentChar)
        {
            return ((checkIsEmpty && toCheck == string.Empty) || (commentChar != ' ' && toCheck.StartsWith(commentChar.ToString()))) ? true : false;
        }

        /// <summary>Count a component of string.</summary>
        /// <param name="toCount">String to parse.</param>
        /// <param name="itemType">What to count ["characters", "lines"].</param>
        /// <returns>The number of specified components in the string.</returns>
        /// <remarks>Switch used so it's easier to add itemTypes in the future.</remarks>
        public static int Count(string toCount, string itemType)
        {
            switch (itemType)
            {
                case "character":
                    return toCount.Length;

                case "line":
                    return toCount.Split(Convert.ToChar(Environment.NewLine)).Length;

                default:
                    return 0;
            }
        }

        /// <summary>Remove components from a string.</summary>
        /// <param name="removeFrom">String to parse.</param>
        /// <param name="itemType">What to remove ["specificLine", "newLines"].</param>
        /// <param name="lineToRemove">Optional line to remove (or "null").</param>
        /// <returns>The string with the line/newlines removed.</returns>
        /// <remarks>Switch used so it's easier to add itemTypes in the future.</remarks>
        public static string Remove(string removeFrom, string itemType, string lineToRemove)
        {
            var wrkString = string.Empty;
            var currentLine = string.Empty;
            StringReader stringToRead = new StringReader(removeFrom);

            while (true)
            {
                currentLine = stringToRead.ReadLine();

                if (currentLine == null)
                {
                    break;
                }

                switch (itemType)
                {
                    case "specificLine":
                        if (currentLine != lineToRemove)
                        {
                            return wrkString + currentLine;
                        }
                        break;

                    case "newline":
                        if (currentLine.EndsWith(Environment.NewLine))
                        {
                            return wrkString + AOString.Replace(currentLine, Environment.NewLine, "");
                        }
                        break;

                    case "space":
                        return AOString.Replace(currentLine, " ", "");

                    default:
                        return "ERROR";
                }
            }

            return wrkString;
        }

        /// <summary>Replace a part of a string.</summary>
        /// <param name="toModify">String to parse.</param>
        /// <param name="toRemove">The part of the string to replace.</param>
        /// <param name="replaceWith">The replacement.</param>
        /// <returns>The modified string.</returns>
        public static string Replace(string toModify, string toRemove, string replaceWith)
        {
            return toModify.Replace(toRemove, replaceWith);
        }

        /// <summary>Used?</summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public static Color AsColor(string colorName)
        {
            return Color.FromName(colorName);
        }

        /// <summary>Convert a string with newlines to an array.</summary>
        /// <param name="toConvert">String to convert.</param>
        /// <param name="delimiter">The delimiter charactger ["\t",","].</param>
        /// <returns>An array with the file contents, split at newlines.</returns>
        public static string[] ToArray(string toConvert, char delimiter)
        {
            return (delimiter != ' ') ? toConvert.Split(delimiter) : toConvert.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }

        /// <summary>Write a string to a file.</summary>
        /// <param name="filePath">The path of the file to write to.</param>
        /// <param name="dataToWrite">The string to write.</param>
        public static void ToFile(string filePath, string dataToWrite)
        {
            File.WriteAllText(filePath, dataToWrite);
        }
    }
}