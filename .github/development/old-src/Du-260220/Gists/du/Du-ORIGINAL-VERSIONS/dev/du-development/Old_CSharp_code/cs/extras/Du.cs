#region CLASS_HEADER
//   PROJECT: myAvatool
//  MODIFIED: 180729
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/myAvatool
#endregion

#region CLASS_REMARKS
// None.
#endregion

#region USING
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
#endregion

namespace myAvatool
{
    internal class Du
    {
        #region DIRECTORY ----------------------------------------------------------------------------------------------
        /// <summary></summary>
        /// <build>180727</build>
        public static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        #endregion DIRECTORY -------------------------------------------------------------------------------------------

        #region FILE ---------------------------------------------------------------------------------------------------
        /// <summary>Gets various file information via an OpenFileDialog control.</summary>
        /// <param name="openFileDialog">The OpenFileDialog control.</param>
        /// <returns>A dictionary with file information.</returns>
        /// <build>180727</build>
        public static Dictionary<string, string> GetFileInfo(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return new Dictionary<string, string>
                {
                    {"fileName", openFileDialog.FileName},
                    {"safeFileName", openFileDialog.SafeFileName}
                };
            }
            else
            {
                return null;
            }
        }
        #endregion FILE ------------------------------------------------------------------------------------------------

        #region HTML ---------------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the HTML source of a URL.
        /// </summary>
        /// <param name="sourceURL">The URL to get the source of (i.e. "http://whatever.com/thispage.html").</param>
        /// <returns>The HTML source.</returns>
        /// <build>180727</build>
        public static string GetHTMLSource(string sourceURL)
        {
            var request = (HttpWebRequest)WebRequest.Create(sourceURL);
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            var response = (HttpWebResponse)request.GetResponse();
            var workString = string.Empty;

            using (var dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                {
                    return string.Empty;
                }
                else
                {
                    using (var streamReader = new StreamReader(dataStream))
                    {
                        workString = streamReader.ReadToEnd();
                    }
                }
            }

            return workString;
        }
        #endregion HTML ------------------------------------------------------------------------------------------------

        #region LIST ---------------------------------------------------------------------------------------------------
        /// <summary>Converts a List<string> object to a string.</summary>
        /// <param name="toConvert"> The List<string> to convert.</param>
        /// <param name="addNewline">Flag to optionally add newlines.</param>
        /// <returns>A string.</returns>
        /// <build>180727</build>
        public static string ListToString(List<string> toConvert, bool addNewline = true)
        {
            var convertedString = string.Empty;

            foreach (var item in toConvert)
            {
                convertedString += addNewline
                    ? item + Environment.NewLine
                    : item;
            }

            return convertedString;
        }
        #endregion LIST ------------------------------------------------------------------------------------------------

        #region SYSTEM -------------------------------------------------------------------------------------------------
        /// <summary>Inserts a pause.</summary>
        /// <param name="milliseconds"> Number of milliseconds to pause.</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static void Pause(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
        #endregion SYSTEM ----------------------------------------------------------------------------------------------

        #region STREAMREADER -------------------------------------------------------------------------------------------
        /*  StreamReader methods
         *  =====================
         *  Methods in this class work that use StreamReader objects work with external files OR emedded resources, provided you
         *  pass the filePath as as a StreamReader object.
         *
         *  If the file is external, use the following code:
         *
         *      var filePath = new System.IO.StreamReader("path/to/file");
         *      Du.StreamReaderToList(filePath);
         *
         *  If the file is an embedded resource, use the following code:
         *
         *      var assemblyName = Assembly.GetExecutingAssembly();
         *      var filePath     = new System.IO.StreamReader(assemblyName.GetManifestResourceStream("path/to/file"));
         *      Du.StreamReaderToList(filePath);
         */
        /// <summary>Creates a StreamReader object.</summary>
        /// <param name="filename"></param>
        /// <returns>A StreamReader object.</returns>
        public static StreamReader CreateStreamReader(string filename)
        {
            return new StreamReader(filename);
        }

        /// <summary>Convert a file to a list.</summary>
        /// <param name="filePath"> Path of the file.</param>
        /// <returns>The file contents as a list.</returns>
        /// <remarks>
        /// Converts a file into a string List. Please see the  CLASS_REMARKS comments at the top of this file
        /// for instructions on creating the StreamReader class used to pass the file to this method.
        /// </remarks>
        public static List<string> StreamReaderToList(StreamReader filePath)
        {
            var wrkList = new List<string>();
            var line = string.Empty;

            using (filePath)
            {
                while ((line = filePath.ReadLine()) != null)
                {
                    wrkList.Add(line);
                }
            }

            return wrkList;
        }
        #endregion STREAMREADER ----------------------------------------------------------------------------------------

        #region STRING -------------------------------------------------------------------------------------------------
        /// <summary>Returns a substring.</summary>
        /// <param name="toCheck"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <build>180727</build>
        public static string GetSubstring(string toCheck, int start, int length)
        {
            return toCheck.Substring(start, length);
        }

        /// <summary>Returns a substring.</summary>
        /// <param name="toCheck"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <build>180727</build>
        public static string GetSubstring(string toCheck, char start, char end)
        {
            var starter = toCheck.IndexOf(start);
            var ender   = toCheck.IndexOf(end) - starter;
            return toCheck.Substring(starter, ender + 1);
        }

        /// <summary>Returns a substring between two characters.</summary>
        /// <param name="toCheck"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <build>180727</build>
        public static string GetSubstringBetween(string toCheck, char start, char end)
        {
            var starter = toCheck.IndexOf(start);
            var ender   = toCheck.IndexOf(end)      - starter;
            return toCheck.Substring(starter + 1, ender - 1);
        }

        /// <summary>Replaces part of a string with antother string.</summary>
        /// <param name="list"></param>
        /// <param name="replaceWith"></param>
        /// <returns></returns>
        /// <build>180729</build>
        public static string ReplaceStringWithString(string original, string replaceThis, string replaceWith)
        {
            //var test = original.Replace(replaceWith, replaceWith);
            return original.Replace(replaceThis, replaceWith);
        }

        /// <summary>Replaces part of a string with antother string.</summary>
        /// <param name="list"></param>
        /// <param name="replaceWith"></param>
        /// <returns></returns>
        /// <build>180727</build>
        public static string ReplaceStringWithString(string original, List<string> toReplace, string replaceWith)
        {
            var wrkString = original;

            foreach (var item in toReplace)
            {
                wrkString = wrkString.Replace(item, replaceWith);
            }

            return wrkString;
        }

        /// <summary>Removes specified content from the beginning of a string.</summary>
        /// <param name="toModify">The string to remove from.</param>
        /// <param name="content">The content to remove.</param>
        /// <returns>The string with the content removed from the beginning.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string RemoveLeadingContent(string toModify, int end)
        {
            return toModify.Substring(end);
        }

        /// <summary>Converts a string to a List<string>, splitting values at a delimiter.</summary>
        /// <param name="toConvert"> The string to convert.</param>
        /// <param name="delimiter"> The delimiter. </param>
        /// <returns>A string list. </returns>
        /// <build>180727</build>
        public static string[] StringToArray(string toConvert, char delimiter = '=')
        {
            return toConvert.Split(delimiter).ToArray();
        }

        /// <summary>Converts a string to a List<string>, splitting values at a delimiter.</summary>
        /// <param name="toConvert"> The string to convert.</param>
        /// <param name="delimiter"> The delimiter. </param>
        /// <returns>A string list. </returns>
        /// <build>180727</build>
        public static List<string> StringToList(string toConvert, char delimiter)
        {
            return toConvert.Split(delimiter).ToList();
        }

        /// <summary>Converts a string to a List<string>, splitting values at a delimiter.</summary>
        /// <param name="toConvert"> The string to convert.</param>
        /// <param name="delimiter"> The delimiter. </param>
        /// <returns>A string list. </returns>
        /// <build>180727</build>
        public static List<string> StringToList(string toConvert, string delimiter)
        {
            return toConvert.Split(new[] { delimiter, Environment.NewLine }, StringSplitOptions.None).ToList();
        }
        #endregion STRING ----------------------------------------------------------------------------------------------
    }
}

/* Version history
 * ===============
 * This can be removed in production environments.
 *
 * v180729
 * =======
 * [   FIXED] ReplaceStringWithString(string original, string replaceThis, string replaceWith)
 *            - Argument for replaceThis was incorrect.
 *
 * v180727
 * =======
 * [     NEW] GetSubstring(string toCheck, char start, char end)
 * [MODIFIED] StringToList(string toConvert, char delimiter)
 *            - Now requires the delimiter character.
 * [   FIXED] GetSubstring(string toCheck, int start, int length)
 *            - Argument for length of substring was incorrect.
 *
 * v180705
 * =======
 * [     NEW] ReplaceStringWithString(string original, string replaceWith)
 *
 * v180625
 * =======
 * [     NEW] ListToString(List<string> toConvert, bool newline = true)
 * [     NEW] GetFileInfo(OpenFileDialog openFileDialog)
 * [     NEW] CreateStreamReader(string filename)
 * [     NEW] ReplaceStringWithString(string original, List<string> toReplace, string replaceWith)
 * [     NEW] GetHTMLSource(string sourceURL)
 * [     NEW] Pause(int milliseconds)
 * [     NEW] StreamReaderToList(StreamReader filePath)
 * [     NEW] CreateDirectory(string directory)
 * [     NEW] StringToList(string toConvert, char delimiter = '\n')
 * [     NEW] StringToList(string toConvert, string delimiter)
 * [     NEW] StringToArray(string toConvert, char delimiter = '=')
 * [     NEW] GetSubstring(string toCheck, int start, int end)
 * [     NEW] RemoveLeadingContent(string toModify, int end)
 */
