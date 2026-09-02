/* A class for AO.cs that does various things with strings.
 * v00.52.03.161012
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AO
{
    public class AOString
    {
        /* Check to see if a string is empty.
         * ---
         * toCheck - the string to check.                                                                             */

        public static bool CheckEmpty(string toCheck, string additionalCheck)                               // TODO - Update documentation
        {
            var passed = false;
            var additionalCheckPassed = false;

            switch (additionalCheck)
            {
                case null:
                    break;

                case "emptyQuotes":
                    if (toCheck == "")
                    {
                        additionalCheckPassed = true;
                    }
                    break;

                case "spaceQuotes":
                    if (toCheck == " ")
                    {
                        additionalCheckPassed = true;
                    }
                    break;

                case "allQuotes":
                    if (toCheck == "" || toCheck == " ")
                    {
                        additionalCheckPassed = true;
                    }
                    break;

                default:
                    break;
            }


            if ((toCheck == string.Empty) || additionalCheckPassed)
            {
                passed = true;
            }

            return passed;
        }

        /* Check to see if a string is a comment.
         * ---
         * toCheck          - the string to check.
         * commentCharacter - the character that indicates a comment line                                             */

        public static bool CheckComment(string toCheck, char commentCharacter)
        {
            return (toCheck.StartsWith(commentCharacter.ToString()))
                ? true
                : false;
        }

        /* Check to see if a string is null.
         * ---
         * toCheck - the string to check.                                                                             */

        public static bool CheckNull(string toCheck)
        {
            return (toCheck == null)
                ? true
                : false;
        }

        /* Remove components from a string.
         * Removes one of the following type of item from a string:
         *      entireLine - a specific line from the string
         *      newline    - newline characters
         *      space      - spaces
         * ---
         * removeFrom  - the string to remove something from
         * itemType    - one of the items above
         * entireLine  - the line to remove (if the itemType is "entireLine")                                         */

        public static string Remove(string removeFrom, string itemType, string entireLine)                              // TODO - Add functionality for substrings.
        {
            var wrkString = string.Empty;
            var currentLine = string.Empty;
            StringReader stringToRead = new StringReader(removeFrom);

            /* Loop through each line of the passed string, and as long as it's not "null", check to see if it contains
             * the passed itemType. If the itemType is "entireLine", and the currentLine doesn't match, then build upon
             * the wrkString. Essentially this skips the line you want to remove. If itemType is "newline" or "space",
             * and the currentLine contains that itemType, replace it with nothing.                                   */
            while (true)
            {
                currentLine = stringToRead.ReadLine();

                if (currentLine == null)
                {
                    break;
                }

                switch (itemType)
                {
                    case "entireLine":
                        if (currentLine != entireLine)
                        {
                            return wrkString + currentLine;
                        }
                        break;

                    case "newline":
                        if (currentLine.EndsWith(Environment.NewLine))
                        {
                            return currentLine.Replace(Environment.NewLine, "");
                        }
                        break;

                    case "space":
                        return currentLine.Replace(" ", "");

                    default:
                        return "ERROR";
                }
            }

            return wrkString;
        }

        /* Convert a string to an array.
         * If a delimiter character is passed, split the string at the delimiter and put the
         *
         * Split the string at the desired location, and return the key/value in an array. Otherwise we'll
         * assume the delimiter is a newline, so split the string at the newline character, and return the key/value
         * pair in an array.
         * ---
         * toConvert - the string to convert
         * delimiter - the delimiter character, or ' ' for splitting at newlines                                      */

        public static string[] ToArray(string toConvert, char delimiter)
        {
            return (delimiter != ' ')
                ? toConvert.Split(delimiter)
                : toConvert.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }

        /* Convert a string to an list.
         * If a delimiter character is passed, split the string at the delimiter and put the
         *
         * Split the string at the desired location, and return the key/value in an array. Otherwise we'll
         * assume the delimiter is a newline, so split the string at the newline character, and return the key/value
         * pair in an array.
         * ---
         * toConvert - the string to convert
         * delimiter - the delimiter character, or ' ' for splitting at newlines                                      */

        public static List<string> ToList(string toConvert, char delimiter)                                             // TODO - Cleanup comments
        {
            return ToArray(toConvert, delimiter).ToList();
        }
    }
}