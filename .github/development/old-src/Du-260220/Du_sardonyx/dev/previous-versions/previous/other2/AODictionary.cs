/* A class for AO.cs that does various things with dictionaries.
 * v00.53.03.161219
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace AO
{
    /// <summary>Does various things with dictionaries.</summary>
    public class AODictionary
    {
        /// <summary>
        /// Builds a dictionary of cleaning rules. [1/2]
        /// </summary>
        /// <param name="empties"> Flag to indicate that empties are cleaned or not [true/false].</param>
        /// <param name="nulls">   Flag to indicate that nulls are cleaned or not [true/false].</param>
        /// <param name="comments">Comment character, or ' ' (i.e. '#').</param>
        /// <returns>A dictionary with cleaning rules.</returns>
        /// <remarks>
        /// [*] By building a dictionary of cleaning rules, we can easily send a standard to various methods, and
        ///     allows for the expansion of variables in the future.This version of the method builds the actual
        ///     dictionary from the individual rule settings.Unless you need to clean comments that don't start
        ///     with "#", you should use the second version of this method.
        /// [*] If a character is passed in the comments parameter, lines that start with that character will be
        ///     cleaned. Passing ' ' means comments will not be cleaned.
        /// </remarks>
        public static Dictionary<string, string> BuildCleaningRules(bool empties, bool nulls, char comments)
        {
            var wrkDictionary = new Dictionary<string, string>();

            wrkDictionary["empties"] = empties.ToString();
            wrkDictionary["nulls"] = nulls.ToString();
            wrkDictionary["commentChar"] = comments.ToString();

            return wrkDictionary;
        }

        /// <summary>
        /// Builds a dictionary of cleaning rules. [2/2]
        /// </summary>
        /// <param name="cleanType">The type of cleaning to do [none/all/empties/nulls/comments/emptiesAndNulls/emptiesAndComments].</param>
        /// <returns>A dictionary with cleaning rules.</returns>
        /// <remarks>
        /// [*] By building a dictionary of cleaning rules, we can easily send a standard to various methods, and
        ///     allows for the expansion of variables in the future.This version of the method builds the actual
        ///     dictionary from the individual rule settings.Unless you need to clean comments that don't start
        ///     with "#", you should use the second version of this method.
        /// [*] Since most cleaning requests will fall within a number of defaults, this version of the method takes
        ///     a single argument, then builds the cleaning rules dictionary by expanding on that.It's important to
        ///     note that when using this version of the method, the comment character that is used is always "#".
        ///     The options are:
        ///         none - no cleaning
        ///         all - empties, nulls, and comments that start with "#"
        ///         empties - just empties
        ///         nulls - just nulls
        ///         comments - just comments that start with "#"
        ///         emptiesAndNulls - empties and nulls
        ///         emptiesAndComments - empties and comments that start with "#"
        /// </remarks>
        public static Dictionary<string, string> BuildCleaningRules(string cleanType)
        {
            var wrkDictionary = new Dictionary<string, string>();

            switch (cleanType)
            {
                case "none":
                    return BuildCleaningRules(false, false, ' ');

                case "all":
                    return BuildCleaningRules(true, true, '#');

                case "empties":
                    return BuildCleaningRules(true, false, ' ');

                case "nulls":
                    return BuildCleaningRules(false, true, ' ');

                case "comments":
                    return BuildCleaningRules(true, true, '#');

                case "emptiesAndNulls":
                    return BuildCleaningRules(true, true, ' ');

                case "emptiesAndComments":
                    return BuildCleaningRules(true, false, '#');

                case "nullsAndComments":
                    return BuildCleaningRules(false, true, '#');

                default:
                    return wrkDictionary;
            }
        }

        /// <summary>
        /// Removes empties, comments, and/or nulls from a dictionary.
        /// </summary>
        /// <param name="dictionaryToClean">Dictionary to clean.</param>
        /// <param name="cleaningRules">    Dictionary with cleaning rules.</param>
        /// <returns>The cleaned dictionary.</returns>
        /// <remarks>
        /// [1] Loop through each item in the dictionary. With each pass, check the following:
        ///         Are we checking for empty keys, and is the key empty?
        ///         Are we checking for null keys, and is the key null?
        ///         Are we checking for comments, and does the key start with the comment line?
        /// [2] As long as all three of those statements are false, add to line to the wrkDictionary. If any of them
        ///     are false, then don't add the line to the wrkDictionary.
        /// </remarks>
        public static Dictionary<string, string> Clean(Dictionary<string, string> dictionaryToClean, Dictionary<string, string> cleaningRules)
        {
            var wrkDictionary = new Dictionary<string, string>();
            var emptyPassed = false;
            var nullPassed = false;
            var commentPassed = false;

            foreach (var item in dictionaryToClean)                                                                     // [1]
            {
                emptyPassed = ((cleaningRules["empties"] == "true") && (AOString.CheckEmpty(item.Key, null))) ? false : true;
                nullPassed = ((cleaningRules["nulls"] == "true") && (AOString.CheckNull(item.Key))) ? false : true;
                commentPassed = ((cleaningRules["commentChar"] != " " && AOString.CheckComment(item.Key, Convert.ToChar(cleaningRules["commentChar"])))) ? false : true;

                if ((emptyPassed) && (nullPassed) && (commentPassed))                                                   // [2]
                {
                    wrkDictionary.Add(item.Key, item.Value);
                }
            }

            return wrkDictionary;
        }

        /// <summary>
        /// Join a list of dictionaries.
        /// </summary>
        /// <param name="dictionariesToJoin">List of dictionaries to join.</param>
        /// <returns>The joined dictionaries.</returns>
        /// <remarks>
        /// None.
        /// </remarks>
        public static Dictionary<string, string> Join(List<Dictionary<string, string>> dictionariesToJoin)
        {
            var wrkDictionary = new Dictionary<string, string>();

            foreach (var item in dictionariesToJoin)
            {
                item.ToList().ForEach(x => wrkDictionary[x.Key] = x.Value);
            }

            return wrkDictionary;
        }

        /// <summary>
        /// Converts a dictionary to a string.
        /// </summary>
        /// <param name="dictionaryToConvert">Dictionary that will be converted.</param>
        /// <param name="betweenItem">        What is between the elements.</param>
        /// <param name="betweenDelimiter">   Seperates items in the string.</param>
        /// <param name="delimiter">          The delimiter.</param>
        /// <returns>The dictionary as a string.</returns>
        /// <remarks>
        /// [*] The betweenItem value must be one of the following:
        ///         nothing         : don't add anything, just create one giant string
        ///         betweenDelimiter: add a single character, i.e. '=', '\t'
        ///         newLine         : add a newline character
        /// [*] The betweenDelimiter sperates items in the string, either a single character (i.e. '=', '\t'),
        ///     or ' ' if a delimiter is not be used. This paramater may not always be used, but it's required.
        /// [*] The delimiter must be either a single character (i.e. '=', '\t'), or ' ' if a delimiter is not be used.
        /// [1] At a minimum, each item's key/value pair will be added to the string, using the delimiter to seperate
        /// the two. If the betweenItem paramater contains a valid non-"nothing" value, add that as well.
        ///
        /// </remarks>
        public static string ToString(Dictionary<string, string> dictionaryToConvert, string betweenItem, char betweenDelimiter, char delimiter)
        {
            var wrkString = string.Empty;

            foreach (var item in dictionaryToConvert)                                                                   // [1]
            {
                wrkString = wrkString + item.Key + delimiter.ToString() + item.Value;

                switch (betweenItem)
                {
                    case "beteenDelimiter":
                        wrkString = wrkString + betweenDelimiter;
                        break;

                    case "newLine":
                        wrkString = wrkString + Convert.ToChar(Environment.NewLine);
                        break;

                    default: // ERROR
                        break;
                }
            }

            return wrkString;
        }
    }
}