// ---------------------------------------------------------------------------------------------------------------------
// Name: DoDictionary.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with dictionaries.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace AO
{
    public class DoDictionary
    {
        /// <summary>Removes empties/comments/nulls from a dictionary.</summary>
        /// <param name="toClean">Dictionary to clean.</param>
        /// <param name="empty"> Flag to remove empty elements.</param>
        /// <param name="comment">Flag to remove comment elements.</param>
        /// <param name="nullVal">Flag to remove null values.</param>
        /// <returns>The cleaned dictionary</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static Dictionary<string, string> Clean(Dictionary<string, string> toClean, bool empty, char comment, bool nullVal)
        {
            var wrkDictionary = new Dictionary<string, string>();

            foreach (var item in toClean)
            {
                if (DoString.Test(item.Key, empty, comment) && (!nullVal && Convert.ToBoolean(item.Key != null)))
                {
                    wrkDictionary.Add(item.Key, item.Value);
                }
            }

            return wrkDictionary;
        }

        /// <summary>Extract keys for values from a dictionary.</summary>
        /// <param name="extractFrom"></param>
        /// <param name="extractType"></param>
        /// <returns>???</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static List<string> Extract(Dictionary<string, string> extractFrom, string extractType)
        {
            var wrkList = new List<string>();

            foreach (var item in extractFrom)
            {
                switch (extractType)
                {
                    case "keys":
                        wrkList.Add(item.Key);
                        break;

                    case "values":
                        wrkList.Add(item.Value);
                        break;

                    default:
                        break;
                }
            }

            return wrkList;
        }

        /// <summary>Merge a list of dictionaries.</summary>
        /// <param name="toJoin">The dictionaries to join.</param>
        /// <returns>A dictionary containing the values from all the dictionaries.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static Dictionary<string, string> Join(List<Dictionary<string, string>> toJoin)
        {
            var mergedDictionary = new Dictionary<string, string>();

            foreach (var currentDictionary in toJoin)
            {
                currentDictionary.ToList().ForEach(x => mergedDictionary[x.Key] = x.Value); //! Copied, not sure how this works
            }

            return mergedDictionary;
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