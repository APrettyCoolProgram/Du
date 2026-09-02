/* A class for AO.cs that does various things with files.
 * v00.52.160927
 * http://aprettycoolprogram.com/ao
 */

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AO
{
    public class AOFile
    {
        /// <summary>Convert a file to an array.</summary>
        /// <param name="filePath">Name of file.</param>
        /// <param name="assembly">Name of the assembly (optional) [null, name_of_assembly]</param>
        /// <returns>The file as an array.</returns>
        /// <remarks>
        /// The file is originally converted to a list by AOFile.ReadExt, then converted to an array by this method.
        /// Passing asm as "null" indicates the file to be read is external, passing a string indicates it's embedded.
        /// </remarks>
        public static string[] AsArray(string filePath, string assembly)
        {
            return (assembly == null)
                ? ExternalAsList(filePath).ToArray()
                : EmbeddedAsList(filePath, assembly).ToArray();
        }

        /// <summary>Convert a file to a dictionary.</summary>
        /// <param name="filePath">path to file.</param>
        /// <param name="delim"></param>
        /// <returns>A dictionary.</returns>
        /// <remarks>
        /// The file is originally converted to a list by AOFile.ReadExt, then converted to a dictionary by this method.
        /// Passing asm as "null" indicates the file to be read is external, passing a string indicates it's embedded.
        /// </remarks>
        public static Dictionary<string, string> AsDictionary(string filePath, char delim, string assembly)
        {
            return AsArray(filePath, assembly).Select(l => l.Split(delim)).ToDictionary(a => a[0], a => a[1]); // ???
        }

        /// <returns>A dictionary with all of the settings from the files.</returns>
        /// <summary>Convert a list of files to a list of dictionaries.</summary>
        /// <param name="fileNames">The list of filenames.</param>
        /// <param name="delim">The delimiter that seperates key/value pairs [ex. "=", "-"]</param>
        /// <param name="assembly">The name of the assembly.</param>
        /// <returns>The file contents as a dictionary.</returns>
        /// <remarks>
        /// Each dictionary is sent to AOFile.AsDictionary to be converted to a dictionary, and that dictionary is then
        /// Added to the list of existing dictionary list.
        /// </remarks>
        public static List<Dictionary<string, string>> AsDictionaries(List<string> fileNames, char delim, string assembly)
        {
            var wrkList = new List<Dictionary<string, string>>();

            foreach (var fileName in fileNames)
            {
                wrkList.Add(AsDictionary(fileName, delim, assembly));
            }

            return wrkList;
        }

        /// <summary>Convert a file to a list.</summary>
        /// <param name="filePath">The path to the file.</param>
        /// <param name="ignorePhrase">If the line contains this phrase, it's ignored (optional).</param>
        /// <param name="clean">Flag to clean the data before counting.</param>
        /// <returns>A list.</returns>
        public static List<string> AsList(string filePath, string assembly)
        {
            return (assembly == null) ? ExternalAsList(filePath) : EmbeddedAsList(filePath, assembly);
        }

        /// <summary>Convert a file to a string.</summary>
        /// <param name="filePath">The file to convert.</param>
        /// <param name="assembly">The assembly name (optional).</param>
        /// <param name="clean">Flag to clean the data before counting.</param>
        /// <returns>A string.</returns>
        public static string AsString(string filePath, string assembly)
        {
            return (assembly == null)
                ? ExternalAsList(filePath).ToString()
                : EmbeddedAsList(filePath, assembly).ToString();
        }

        /// <summary>Delete a file if it exists.</summary>
        /// <param name="filePath">The filename to delete.</param>
        /// <remarks></remarks>
        public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>Puts the contents of an external file into a list.</summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>The file as a list</returns>
        /// <remarks>
        /// This function initializes a StreamReader object for an external file, then passes that object to AOFile.Read
        /// to do the heavy lifting of reading the file. It's important to note this method simply sets up the
        /// StreamReader object, and doesn't do any parsing or cleaning.
        /// </remarks>
        private static List<string> ExternalAsList(string filePath) // Combine w/below
        {
            var fileAsList = new List<string>();

            using (StreamReader fileToRead = new StreamReader(filePath))
            {
                fileAsList = Read(fileToRead);
            }

            return fileAsList;
        }

        /// <summary>Puts the contents of an embedded file into a list.</summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="assembly">The assembly name the file is a member of.</param>
        /// <returns>The file as a list</returns>
        /// <remarks>
        /// This function initializes a StreamReader object for an embedded file, then passes that object to AOFile.Read
        /// to do the heavy lifting of reading the file. It's important to note this method simply sets up the
        /// StreamReader object, and doesn't do any parsing or cleaning.
        /// </remarks>
        private static List<string> EmbeddedAsList(string filePath, string assembly)
        {
            var fileAsList = new List<string>();
            var fullPath = assembly + "." + filePath;

            using (StreamReader fileToRead = new StreamReader(Assembly.Load(assembly).GetManifestResourceStream((string)fullPath)))
            {
                fileAsList = Read(fileToRead);
            }

            return fileAsList;
        }

        /// <summary>Gets the next number in an extension range.</summary>
        /// <param name="directoryName">Directory to look at.</param>
        /// <param name="filePattern">The file name base to match.</param>
        /// <param name="startAt">What to start at.</param>
        /// <returns>A number for the next extension.</returns>
        /// <remarks>
        /// This is used when files in a directory have numeric extensions (i.e. "file.1", "file.2"...), and you want to
        /// find the next number (i.e. "file.3").
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
            nextNum++; // Need this to work correctly.

            return nextNum.ToString();
        }

        /// <summary>Reads a file into a list.</summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>The file as a list.</returns>
        /// <remarks>
        /// Does the heavy lifting when reading files. As long as the file is passed as a StreamReader type, it doesn't
        /// matter if the file is embedded, external, or whatever. It's important to note that this function simply
        /// returns the contents of a file as a list, without parsing or cleaning the contents.
        /// </remarks>
        private static List<string> Read(StreamReader filePath)
        {
            var fileAsList = new List<string>();
            var fileLine = string.Empty;

            while ((fileLine = filePath.ReadLine()) != null)
            {
                fileAsList.Add(fileLine);
            }

            return fileAsList;
        }
    }
}

/*
/// <summary>Append text to a file.</summary>
/// <param name="filePath">The file to append the text to.</param>
/// <param name="toAppend">The text to append.</param>
/// <remarks>If the file doesn't exist, it is created.</remarks>
public static void Append(string filePath, string toAppend)
{
    File.AppendAllText(filePath, toAppend + Environment.NewLine);
}

/// <summary>Count the number of characters or lines in a file.</summary>
/// <param name="filePath">The file to count the items of</param>
/// <param name="clean">Flag to clean the data before counting.</param>
/// <param name="itemType">What to count?</param>
/// <returns>The number of characters or lines in the file.</returns>
public static int Count(string filePath, bool clean, string itemType, string assembly)
{
    switch (itemType)
    {
        case "char":
            return AOArray.CountCharacters(AsArray(filePath, assembly)); // Move to list

        case "line":
            return AsArray(filePath, assembly).Length;

        default:
            return 0; // ERROR
    }
}

/// <summary>Get the extension of a filename.</summary>
/// <param name="fileName">The filename.</param>
/// <returns>The filename extension.</returns>
/// <remarks></remarks>
public static string GetExt(string fileName)
{
     return Path.GetExtension(fileName).Replace(".", "");
}

/// <summary>Get the name of a file without an extension.</summary>
/// <param name="fileName">The filename.</param>
/// <returns>The filename without the extension.</returns>
/// <remarks></remarks>
public static string GetName(string fileName)
{
    return Path.GetFileNameWithoutExtension(fileName);
}

/// <summary>Get a random line from an embedded file.</summary>
/// <param name="fileName">The name of the embedded file.</param>
/// <param name="asm">Name of the assembly</param>
/// <param name="lineToRead">The number of the line to read.</param>
/// <returns>A random line.</returns>
public static string RndLine(string fileName, int lineToRead, string assembly)
{
    return AsArray(fileName, assembly)[lineToRead - 1]; // ??? Look at this.
}

 */