#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuFile.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with files.
#endregion

#region CLASS_REMARKS
//  Methods in this class work with external files OR emedded resources, provided you pass the filePath as as a
//  StringReader object.
//
//  If the file is external, use the following code:
//
//      var filePath = new System.IO.StreamReader("path/to/file");
//      DuFile.ToStringDictionary(filePath);
//
//  If the file is an embedded resource, use the following code:
//
//      var assemblyName = Assembly.GetExecutingAssembly();
//      var filePath     = new System.IO.StreamReader(assemblyName.GetManifestResourceStream("path/to/file"));
//      DuFile.ToStringDictionary(filePath);
#endregion

#region USING
using System.Collections.Generic;
using System.IO;
#endregion

namespace Du
{
    public class DuFile
    {
        /// <summary>Get the number of lines in a file.</summary>
        /// <param name="filePath"> The path to the file.</param>
        /// <returns>The number of lines in the file.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static int CountLines(StreamReader filePath)
        {
            return ToList(filePath).Count;
        }

        /// <summary>Get the number of lines that start with a specific character.</summary>
        /// <param name="filePath"> The path to the file.</param>
        /// <returns>The number of empty lines in the file.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static int CountLinesThatStartWith(StreamReader filePath, char character)
        {
            var lines     = ToList(filePath);
            var lineCount = 0;

            foreach (var line in lines)
                if (DuString.StartsWith(line, character))
                    lineCount++;

            return lineCount;
        }

        /// <summary>Converts a file to a string.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The file as a string.</returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static string ToString(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        /// <summary>Get the number of empty lines in a file.</summary>
        /// <param name="filePath"> The path to the file.</param>
        /// <returns>The number of empty lines in the file.</returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static int CountEmptyLines(StreamReader filePath)
        {
            var lines          = ToList(filePath);
            var lineEmptyCount = 0;

            foreach (var line in lines)
            {
                if (DuString.IsBlank(line))
                {
                    lineEmptyCount++;
                }
            }

            return lineEmptyCount;
        }

        /// <summary>Delete a file, if it exists.</summary>
        /// <param name="filePath"> Path of the file.</param>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>Check if a file exists.</summary>
        /// <param name="filePath"> Path of the file.</param>
        /// <remarks></remarks>
        /// <returns>True/false.</returns>
        public static bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>Convert a file to a string Dictionary.</summary>
        /// <param name="filePath">  Path of the file.</param>
        /// <param name="delimiter"> The delimiter character that seperates the key/value pair.</param>
        /// <returns>The contents of a file as a dictionary of strings.</returns>
        /// <build>180227</build>
        /// <remarks> Converts a file into a string Dictionary. If a delimiter character is passed, each line will be
        /// split at that delimiter.If a delimiter is not passed, line pairs will be used. Please see the  CLASS_REMARKS
        /// at the top of this file for instructions on creating the StreamReader class used to pass the file to this
        /// method.</remarks>
        public static Dictionary<string, string> ToDictionary(StreamReader filePath, char delimiter)
        {
            var wrkDictionary = new Dictionary<string, string>();
            var keyValuePair  = new string[2];
            var key           = string.Empty;
            var value         = string.Empty;

            var wrkList = ToList(filePath);

            foreach (var item in wrkList)
            {
                if (delimiter != ' ')
                {
                    if (item.Contains(delimiter.ToString()))
                    {
                        keyValuePair = DuString.ToArray(item, delimiter);
                        wrkDictionary.Add(keyValuePair[0], keyValuePair[1]);
                    }
                }
                else
                {
                    if (key == string.Empty)
                    {
                        key = item;
                    }
                    else if (key != string.Empty)
                    {
                        value = item;
                        wrkDictionary.Add(key, value);
                        key = string.Empty;
                    }
                }
            }

            return wrkDictionary;
        }

        /// <summary>Convert a file to a string Dictionary.</summary>
        /// <param name="filePath">  Path of the file.</param>
        /// <param name="delimiter"> The delimiter character that seperates the key/value pair.</param>
        /// <returns>The contents of a file as a dictionary of strings.</returns>
        /// <build>180227</build>
        /// <remarks>Converts a file into a string Dictionary where lines are either keys or values. Please see the
        /// CLASS_REMARKS comments at the top of this file for instructions on creating the StreamReader class used to
        /// pass the file to this method. </remarks>
        public static Dictionary<string, string> ToDictionary(StreamReader filePath, string keyString, string valueString)
        {
            var wrkDictionary = new Dictionary<string, string>();
            var key           = string.Empty;
            var value         = string.Empty;

            var wrkList = ToList(filePath);

            var iskey     = false;
            var haveKey   = false;
            var haveValue = false;

            foreach (var item in wrkList)
            {
                if (item.StartsWith(keyString))
                {
                    if (haveValue)
                    {
                        wrkDictionary.Add(key, value);
                        haveValue = false;
                        key = string.Empty;
                    }

                    iskey   = true;
                    value   = string.Empty;
                }
                else if (item.StartsWith(valueString))
                {
                    iskey     = false;
                    haveValue = true;

                }

                if (iskey)
                {
                    key += item;
                }
                else
                {
                    value += item;
                }


            }

            return wrkDictionary;
        }

        /// <summary> Convert a file to a string Dictionary. </summary>
        /// <param name="filePath">  Path of the file.</param>
        /// <param name="delimiter"> The delimiter character that seperates the key/value pair.</param>
        /// <returns> The contents of a file as a dictionary of strings. </returns>
        /// <build>180227</build>
        /// <remarks>Converts a file into a string Dictionary where lines are either keys or values. Please see the
        /// CLASS_REMARKS comments at the top of this file for instructions on creating the StreamReader class used to
        /// pass the file to this method.</remarks>
        public static Dictionary<string, string> ToDictionary(StreamReader filePath, List<string> validKeyStrings, List<string> validValueStrings)
        {
            var wrkDictionary = new Dictionary<string, string>();
            var key = string.Empty;
            var value = string.Empty;

            var wrkList = ToList(filePath);

            var iskey = false;
            var haveKey = false;
            var haveValue = false;

            foreach (var item in wrkList)
            {
                foreach (var validKeyString in validKeyStrings)
                {
                    if (item.StartsWith(validKeyString))
                    {
                        if (haveValue)
                        {
                            wrkDictionary.Add(key, value);
                            haveValue = false;
                            key       = string.Empty;
                        }

                        iskey = true;
                        value = string.Empty;
                    }
                }

                foreach (var validValueString in validValueStrings)
                {
                    if (item.StartsWith(validValueString))
                    {
                        iskey     = false;
                        haveValue = true;

                    }
                }

                if (iskey)
                {
                    key += item;
                }
                else
                {
                    value += item;
                }


            }

            return wrkDictionary;
        }

        /// <summary>Convert a file to a list.</summary>
        /// <param name="filePath"> Path of the file.</param>
        /// <returns>The file contents as a list.</returns>
        /// <build>180227</build>
        /// <remarks>Converts a file into a string List. Please see the  CLASS_REMARKS comments at the top of this file
        /// for instructions on creating the StreamReader class used to pass the file to this method.</remarks>
        public static List<string> ToList(StreamReader filePath)
        {
            var wrkList = new List<string>();
            var line    = string.Empty;

            using (filePath)
            {
                while ((line = filePath.ReadLine()) != null)
                {
                    wrkList.Add(line);
                }
            }

            return wrkList;
        }
    }
}