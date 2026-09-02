/* A class for AO.cs that does various things with files.
 * v00.53.04.161220
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AO
{
    public class AOFile
    {
        /// <summary>
        /// Counts the lines in a file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        /// <remarks>
        /// Verify.
        /// </remarks>
        public static long CountLines(string fileName, string assemblyName)
        {
            return ToList(fileName, assemblyName).Count;
        }

        /// <summary>
        /// Counts the characters.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        /// <remarks>
        /// Verify.
        /// </remarks>
        public static long CountCharacters(string fileName, string assemblyName)
        {
            return 0;
        }

        /// <summary>
        /// Randoms the line.
        /// </summary>
        /// <param name="lineNumber">The line number.</param>
        /// <returns></returns>
        /// <remarks>
        /// Verify
        /// </remarks>
        public static string RandomLine(int lineNumber)
        {
            //var test = ToList("Resources.Appdata.Generators.firstnames.gnr", "DUNGEON");
            //return "NONE";
        }

        /// <summary>
        /// Convert a file to an array.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        /// <remarks>
        /// None.
        /// </remarks>
        public static string[] ToArray(string filePath, string assemblyName)
        {
            return (assemblyName == null) ? ToList(filePath, null).ToArray() : ToList(filePath, assemblyName).ToArray();
        }

        /// <summary>
        /// Convert a file to a dictionary.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        /// <remarks>
        /// I'm not sure how this works, exactly!
        /// </remarks>
        public static Dictionary<string, string> ToDictionary(string filePath, string assemblyName, char delimiter)
        {
            return ToArray(filePath, assemblyName).Select(l => l.Split(delimiter)).ToDictionary(a => a[0], a => a[1]);
        }

        /// <summary>
        /// To the dictionaries.
        /// </summary>
        /// <param name="fileNames">The file names.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="delimeter">The delimeter.</param>
        /// <returns></returns>
        /// <remarks>
        /// None.
        /// </remarks>
        public static List<Dictionary<string, string>> ToDictionaries(List<string> fileNames, string assemblyName, char delimeter)
        {
            var wrkList = new List<Dictionary<string, string>>();

            foreach (var fileName in fileNames)
            {
                wrkList.Add(ToDictionary(fileName, assemblyName, delimeter));
            }

            return wrkList;
        }

        /// <summary>
        /// To the list.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        /// <remarks>
        /// [1] If the passed assembly name is "null", then the file is external. If an assembly name was passed, the
        ///     file is embedded.Either way, read the file into a list.
        /// </remarks>
        public static List<string> ToList(string filePath, string assembly)
        {
            var fileAsList = new List<string>();

            if (assembly == null)                                                                                       // [1]
            {
                using (StreamReader fileToRead = new StreamReader(filePath))
                {
                    fileAsList = ReadIntoList(fileToRead);
                }
            }
            else
            {
                using (StreamReader fileToRead = new StreamReader(Assembly.Load(assembly).GetManifestResourceStream((string)assembly + "." + filePath)))
                {
                    fileAsList = ReadIntoList(fileToRead);
                }
            }

            return fileAsList;
        }

        /* Convert a file into a string.
         * ---
         * filePath      - the full path of the file. If this is just the file name, we'll look in the local directory.
         * assemeblyName - optional assembly name, or "null" to indicate the file is external.                        */

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="cleaningRules">The cleaning rules.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <remarks>
        /// [1] If the passed assembly name is "null", then the file is external. If an assembly name was passed, the
        ///     file is embedded.Either way, read the file into a list.
        /// </remarks>
        public static string ToString(string filePath, string assembly, Dictionary<string, string> cleaningRules)
        {
            var fileAsString = string.Empty;

            if (assembly == null)                                                                                       // [1]
            {
                using (StreamReader fileToRead = new StreamReader(filePath))
                {
                    fileAsString = ReadIntoString(fileToRead, cleaningRules);
                }
            }
            else
            {
                using (StreamReader fileToRead = new StreamReader(Assembly.Load(assembly).GetManifestResourceStream((string)assembly + "." + filePath)))
                {
                    fileAsString = ReadIntoString(fileToRead, cleaningRules);
                }
            }

            return fileAsString;
        }

        /// <summary>
        /// Deletes the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <remarks>
        /// None.
        /// </remarks>
        /public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /* Gets the next number in an extension range.

         *

         * ---
         * directoryName -
         * filePattern   -
         * startAt       -
         */

        /// <summary>
        /// Gets the next ext number.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="filePattern">The file pattern.</param>
        /// <param name="startAt">The start at.</param>
        /// <returns></returns>
        /// <remarks>
        /// [*] This method is used in a very specific situation, when file have numeric extensions, and you want to
        ///     find the next number to use.For instance, if you have the following files in a directory...
        ///
        ///         "file.001", "file.002", "file.003"
        ///
        ///     ...this method will determine the next file should be "file.004".
        /// [1] This is needed to work correctly.
        /// </remarks>
        public static string GetNextExtNum(string directoryName, string filePattern, int startAt)
        {
            var nextNum = startAt;

            foreach (var fName in Directory.GetFiles(directoryName))
            {
                if (Path.GetFileNameWithoutExtension(fName) == filePattern)
                {
                    if (int.Parse(Path.GetFileNameWithoutExtension(fName)) > nextNum)
                    {
                        nextNum = int.Parse(Path.GetFileNameWithoutExtension(fName));
                    }
                }
            }
            nextNum++;                                                                                                  // [1]

            return nextNum.ToString();
        }

        /// <summary>
        /// Reads the into list.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// <remarks>
        /// [*] As long as the file is passed as a StreamReader type, it doesn't  matter if the file is embedded,
        ///     external, or whatever. It's important to note that this function simply returns the contents of a
        ///     file as a list, without parsing or cleaning the contents.
        /// [T] Fix this like ReadIntoString
        /// </remarks>
        private static List<string> ReadIntoList(StreamReader filePath)
        {
            var fileAsList = new List<string>();
            var fileLine = string.Empty;

            while ((fileLine = filePath.ReadLine()) != null)
            {
                fileAsList.Add(fileLine);
            }

            return fileAsList;
        }

        /// <summary>
        /// Reads the into string.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="cleaningRules">The cleaning rules.</param>
        /// <returns></returns>
        /// <remarks>
        /// [*] As long as the file is passed as a StreamReader type, it doesn't  matter if the file is embedded,
        /// external, or whatever. It's important to note that this function simply returns the contents of a file
        /// as a list, without parsing or cleaning the contents.
        /// [1] Loop through the passed file. With each pass, check the following:
        ///         - Are we checking for empty lines, and is the line empty?
        ///         - Are we checking for null lines, and is the line null?
        ///         - Are we checking for comments, and does the line start with the comment line?
        ///     As long as all three of those statements are false, add to line to the wrkString.If any of them are
        ///     false, then don't add the line to the wrkString.
        /// </remarks>
        private static string ReadIntoString(StreamReader filePath, Dictionary<string, string> cleaningRules)
        {
            var fileAsString = string.Empty;
            var fileLine = string.Empty;
            var emptyPassed = false;
            var nullPassed = false;
            var commentPassed = false;


            while ((fileLine = filePath.ReadLine()) != null)
            {
                emptyPassed = (cleaningRules["empties"] == "true" && AOString.CheckEmpty(fileLine, null))  ? false : true;
                nullPassed = (cleaningRules["nulls"] == "true" && AOString.CheckNull(fileLine)) ? false : true;
                commentPassed = (cleaningRules["commentChar"] != " " && AOString.CheckComment(fileLine, Convert.ToChar(cleaningRules["commentChar"]))) ? false : true;

                if (emptyPassed && nullPassed && commentPassed)
                {
                    fileAsString = fileAsString + fileLine + " ";
                }
            }

            return fileAsString;
        }
    }
}