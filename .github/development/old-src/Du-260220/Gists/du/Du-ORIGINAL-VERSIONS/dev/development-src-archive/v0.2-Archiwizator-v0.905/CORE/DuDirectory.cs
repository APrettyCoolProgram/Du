/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuDirectory.cs
 * UPDATED: 12-28-2020-12:26 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.IO;

namespace Du
{
    public class DuDirectory
    {
        /// <summary>Create a single directory.</summary>
        /// <param name="directoryPath">The path of the directory to create.</param>
        /// <remarks>
        /// * The path will be created as it is defined, so make sure you are sending the absolute path if it is needed,
        ///   or any trailing slashes, etc.
        /// * This will check to see if the directory exists prior to attempting to create.
        /// </remarks>
        public static void Create(string directoryPath)
        {
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Create a list of directories.</summary>
        /// <param name="directoryPaths">A list of directory paths to create.</param>
        public static void Create(List<string> directoryPaths)
        {
            foreach(var directoryPath in directoryPaths)
            {
                DuDirectory.Create(directoryPath);
            }
        }

        /// <summary>Get the sub-directory names of a directory.</summary>
        /// <param name="targetDirectory">The directory to get the sub-directory names of.</param>
        public static List<string> GetSubDirectoryNames(string targetDirectory)
        {
            var subDirectoryNames = new List<string>();

            foreach(var subdirectory in Directory.GetDirectories(targetDirectory))
            {
                var pathInfo = new DirectoryInfo(subdirectory);
                subDirectoryNames.Add(pathInfo.Name);
            }

            return subDirectoryNames;
        }

        /// <summary>Delete all files in a directory.</summary>
        /// <param name="targetDirectory">The directory to delete the files from.</param>
        public static void DeleteFiles(string targetDirectory)
        {
            FileInfo[] fileNames = GetFileNames(targetDirectory);

            foreach(FileInfo fileName in fileNames)
            {
                DuFile.Delete(fileName.ToString());
            }
        }

        /// <summary>Delete a directory.</summary>
        /// <param name="directoryPath">The directory to delete.</param>
        /// <remarks>
        /// This will check to see if the directory exists prior to attempting to delete.
        /// </remarks>
        public static void Delete(string directoryPath)
        {
            if(Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        /// <summary>Get the file names in a directory.</summary>
        /// <param name="targetDirectory">The directory to get the file names from</param>
        /// <returns>A list of file names.</returns>
        public static FileInfo[] GetFileNames(string targetDirectory)
        {
            var directory = new DirectoryInfo(targetDirectory);

            return directory.GetFiles();
        }
    }
}
