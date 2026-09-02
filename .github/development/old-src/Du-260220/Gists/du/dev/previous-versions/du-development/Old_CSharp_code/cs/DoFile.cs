// ---------------------------------------------------------------------------------------------------------------------
// Name: DoFile.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with files.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AO
{
    public class DoFile
    {
        /// <summary>Append text to a file. If the file doesn't exist, it's created.</summary>
        /// <param name="filePath">The file to append the text to.</param>
        /// <param name="toAppend">The text to append.</param>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static void Append(string filePath, string toAppend)
        {
            File.AppendAllText(filePath, toAppend + Environment.NewLine);                                                     //? Need to append a newline?
        }

        /// <summary>Convert a file to an array.</summary>
        /// <param name="filePath">Name of file.</param>
        /// <param name="assemblyName">Assembly name (optional).</param>
        /// <returns>The file as an array.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string[] ContentAsArray(string filePath, string assemblyName, bool clean)
        {
            var fileAsList = new List<string>();
            var fileLine = string.Empty;

            if (assemblyName == null)
            {
                //TODO Local code will go here
            }
            else
            { // Embedded data
                var assemblyFile = assemblyName + "." + filePath;

                using (StreamReader fileToRead = new StreamReader(Assembly.Load(assemblyName).GetManifestResourceStream(assemblyFile)))
                {
                    while ((fileLine = fileToRead.ReadLine()) != null)
                    {
                        fileAsList.Add(fileLine);
                    }
                }
            }

            var fileAsArray = fileAsList.ToArray();

            if (clean) // Optionally remove empty/comment/null lines
            {
                return DoArray.RemoveComponent(fileAsArray, "all", '#');
            }

            return fileAsArray;
        }

        /// <summary>Convert a file to a dictionary.</summary>
        /// <param name="filePath">path to file.</param>
        /// <param name="assemblyName">Name of assembly (optional).</param>
        /// <returns></returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static Dictionary<string, string> ContentAsDictionary(string filePath, string assemblyName, bool clean, char delimiter)
        {
            var fileAsDictionary = ContentAsArray(filePath, assemblyName, clean).Select(l => l.Split(delimiter)).ToDictionary(a => a[0], a => a[1]);           // Return key/values of file -> array split at delim - HOW WORKS?

            return fileAsDictionary;
        }

        /// <summary>Convert a file to a list.</summary>
        /// <param name="fPath">The path to the file.</param>
        /// <param name="assemblyName">The assembly name (optional).</param>
        /// <param name="clean">Flag to clean the data before counting.</param>
        /// <returns></returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static List<string> ContentAsList(string fPath, string assemblyName, bool clean)
        {
            return ContentAsArray(fPath, assemblyName, clean).ToList();
        }

        /// <summary>Convert a file to a string.</summary>
        /// <param name="fPath">The file to convert.</param>
        /// <param name="assemblyName">The assembly name (optional).</param>
        /// <param name="clean">Flag to clean the data before counting.</param>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string ContentAsString(string fPath, string assemblyName, bool clean)
        {
            return ContentAsArray(fPath, assemblyName, clean).ToString();
        }

        /// <summary>Convert a list of files to a list of dictionaries.</summary>
        /// <param name="fPaths">The list of filenames.</param>
        /// <returns>A dictionary with all of the settings from the files.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static List<Dictionary<string, string>> ContentsAsDictionaries(List<string> fPaths, string assemblyName, bool clean, char delim)
        {
            var listOfDictionaries = new List<Dictionary<string, string>>();

            foreach (var item in fPaths)
            {
                listOfDictionaries.Add(ContentAsDictionary(item, assemblyName, clean, delim));                                          // Assembly name must be the same for all dictionaries.
            }

            return listOfDictionaries;
        }

        /// <summary>Count the number of characters or lines in a file.</summary>
        /// <param name="fPath">The file to count the items of</param>
        /// <param name="assemblyName">The name of the assembly (optional).</param>
        /// <param name="clean">Flag to clean the data before counting.</param>
        /// <param name="action">What to count?</param>
        /// <returns>The number of characters or lines in the file.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static int Count(string fPath, string assemblyName, bool clean, string action)
        {
            var toCount = ContentAsArray(fPath, assemblyName, clean);

            switch (action)
            {
                case "char":
                    return DoArray.CountComponent(toCount, "char");

                case "line":
                    return DoArray.CountComponent(toCount, "line");

                default:
                    return 0;
            }
        }

        /// <summary>Delete a file if it exists.</summary>
        /// <param name="fPath">The filename to delete.</param>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static void Delete(string fPath)
        {
            if (File.Exists(fPath))
            {
                File.Delete(fPath);
            }
        }

        /// <summary>Get the extension of a filename.</summary>
        /// <param name="fileName">The filename.</param>
        /// <returns>The filename extension.</returns>
        /// <remarks>None</remarks>
        /// <build>160725</build>
        public static string GetExtension(string fileName)
        {
            return Path.GetExtension(fileName).Replace(".", "");
        }

        /// <summary>Get the name of a file without an extension.</summary>
        /// <param name="fileName">The filename.</param>
        /// <returns>The filename without the extension.</returns>
        /// <remarks>None</remarks>
        /// <build>160725</build>
        public static string GetNameOnly(string fileName)
        {
            return Path.GetFileNameWithoutExtension(fileName);
        }

        /// <summary>Gets the next number in an extension range.</summary>
        /// <param name="directoryName">Directory to look at.</param>
        /// <param name="fileNameBase">The file name base to match.</param>
        /// <returns>A number for the next extension.</returns>
        /// <remarks>
        /// This is used when files in a directory have numeric extensions (i.e. "file.1", "file.2"...), and you want to
        /// find the next number (i.e. "file.3"
        /// </remarks>
        /// <build>160727</build>
        public static string GetNextExtensionNumber(string directoryName, string fileNameBase, int startAt)
        {
            var nextNumber = startAt; // Start at a predetermined location

            // Loop through all files in the directory, and increment the number if the base name matches and the
            // extension is less than the current number.
            foreach (var fileName in DoDirectory.GetFileNames(directoryName))
            {
                if (DoFile.GetNameOnly(fileName) == fileNameBase)
                {
                    if (int.Parse(DoFile.GetExtension(fileName)) > nextNumber)
                    {
                        nextNumber = int.Parse(DoFile.GetExtension(fileName));
                    }
                }
            }
            nextNumber++; // Increment so we use the next number.

            return nextNumber.ToString();
        }

        /// <summary>Get a random line from a file.</summary>
        /// <param name="fPath">The file to append the text to.</param>
        /// <returns></returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string RandomLine(string fPath, string assemblyName, int lineToRead)
        {
            if (assemblyName == null) // Filesystem
            {
                return "ERROR: This code does not exist"; //! LOCAL FILESYSTEM CODE
            }
            else // Embedded
            {
                var liner = lineToRead - 1;
                return DoFile.ContentAsArray(fPath, assemblyName, false)[liner];
                //return File.ReadLines(asm + "." + path).Skip(liner).Take(1).First();                                          //? Needed?
            }
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