/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuString.cs
 * UPDATED: 12-28-2020-12:32 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Du
{
    public class DuString
    {
        /// <summary></summary>
        /// <param name="workString"></param>
        /// <param name="trailingCharacter"></param>
        /// <returns></returns>
        public static string AddTrailingCharacter(string workString, char trailingCharacter)
        {
            if(!workString.EndsWith(trailingCharacter))
            {
                workString += trailingCharacter;
            }

            return workString;
        }

        /// <summary></summary>
        /// <param name="workString"></param>
        /// <param name="lineToRemove"></param>
        /// <returns></returns>
        public static string RemoveLine(string workString, string lineToRemove)
        {
            var stringToRead = new StringReader(workString);
            var newString = "";

            while(true)
            {
                var currentLine = stringToRead.ReadLine();

                if(currentLine == null)
                {
                    break;
                }
                else if(currentLine != lineToRemove)
                {
                    newString += stringToRead.ReadLine();
                }
            }

            return newString;
        }

        /// <summary></summary>
        /// <param name="workString"></param>
        /// <returns></returns>
        public static string ReplaceNewLineWithSpace(string workString)
        {
            var stringToRead = new StringReader(workString);
            var newString = "";

            while(true)
            {
                var currentLine = stringToRead.ReadLine();

                if(currentLine == null)
                {
                    break;
                }
                else if(currentLine.EndsWith(Convert.ToChar(Environment.NewLine)))
                {
                    newString += currentLine.Replace(Convert.ToChar(Environment.NewLine), ' ');
                }
            }

            return newString;
        }

        /// <summary></summary>
        /// <param name="workString"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string[] ToArrayAtDelimiter(string workString, char delimiter)
        {
            return workString.Split(delimiter);
        }

        /// <summary></summary>
        /// <param name="workString"></param>
        /// <returns></returns>
        public static string[] ToArrayAtNewLine(string workString)
        {
            return workString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        /// <summary></summary>
        /// <param name="workString"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static List<string> ToListAtDelimiter(string workString, char delimiter)
        {
            var stringAsArray = ToArrayAtDelimiter(workString, delimiter);
            //var stringAsList  = new List<string>();

            return DuArray.ToList(stringAsArray);
        }

        /// <summary></summary>
        /// <param name="workString"></param>
        /// <returns></returns>
        public static List<string> ToListAtNewLine(string workString)
        {
            var stringAsArray = ToArrayAtNewLine(workString);
            //var stringAsList  = new List<string>();

            return DuArray.ToList(stringAsArray);
        }
    }
}
