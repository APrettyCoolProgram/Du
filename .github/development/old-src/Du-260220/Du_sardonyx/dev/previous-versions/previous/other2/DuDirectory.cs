// ===========================================================================================================  12:36 PM
//    FILENAME: DuDirectory.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for Dictionaries.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Du
{
    public class DuDirectory
    {

        /// <summary>
        /// Copy the contents of a source directory to a destination directory.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="overwrite"></param>
        public static void Copy(string source, string destination, bool overwrite, string logFileName = "")
        {
            if ((!Exists(source)) && (logFileName != ""))
            {
                /*  This doesn't exit gracefully. There should be a message to the user that something went wrong.
                 */
                DuLog.AppendData(logFileName, "Source directory does not exist or could not be found: " + source);
                Environment.Exit(0);
            }

            Create(destination);

            var sourceDirectory = new DirectoryInfo(source);
            DirectoryInfo[] sourceDirSubDirs = sourceDirectory.GetDirectories();
            FileInfo[] files = sourceDirectory.GetFiles();

            foreach (var file in files)
            {
                var tempPath = Path.Combine(destination, file.Name);
                file.CopyTo(tempPath, overwrite);
            }

            foreach (var subdir in sourceDirSubDirs)
            {
                var tempPath = Path.Combine(destination, subdir.Name);
                Copy(subdir.FullName, tempPath, overwrite, logFileName);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="target"></param>
        public static void Create(string target)
        {
            if (!Exists(target))
            {
                Directory.CreateDirectory(target);
            }
        }

        /// <summary>
        /// Delete all files in the target directory.
        /// </summary>
        /// <param name="target">Ex: "/target/directory/"</param>
        public static void DeleteFiles(string target)
        {
            var directoryFiles = Directory.GetFiles(target);

            foreach (var file in directoryFiles)
            {
                File.Delete(file);
            }
        }

        /// <summary>
        /// Delete all files in the target directory that are not in the toKeep list.
        /// </summary>
        /// <param name="target">Ex: "/target/directory/"</param>
        /// <param name="keep">A list of files to keep.</param>
        public static void DeleteFiles(string target, List<string> keep)
        {
            var directoryFiles = Directory.GetFiles(target);

            foreach (var file in directoryFiles.Where(file => !keep.Contains(Path.GetFileName(file))))
            {
                File.Delete(file);
            }
        }

        public static List<string> GetFilesWithSpecificExtension(string filePath, string extension)
        {
            return Directory.GetFiles(filePath, "*." + extension, SearchOption.AllDirectories).ToList();
        }

        public static List<string> GetFilesWithSpecificExtensions(string filePath, List<string> extensions)
        {
            var fileList = new List<string>();

            foreach (var extension in extensions)
            {
                var extensionFiles = DuDirectory.GetFilesWithSpecificExtension(filePath, extension);

                foreach (var extensionFile in extensionFiles)
                {
                    fileList.Add(extensionFile);
                }
            }

            return fileList;
        }

        /// <summary>
        /// Get the file names in a directory.
        /// </summary>
        /// <param name="target">Ex: "/target/directory/"</param>
        /// <returns>The directory file names as a List<string>.</returns>
        public static List<string> GetFileNames(string target)
        {
            return Directory.GetFiles(target).ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool Exists(string target)
        {
            var directoryInfo = new DirectoryInfo(target);

            return directoryInfo.Exists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<string> GetSubDirectoryNames(string target)
        {
            var subdirectoryNames = new List<string>();

            foreach (var subdirectory in Directory.GetDirectories(target))
            {
                var pathInfo = new DirectoryInfo(subdirectory);
                subdirectoryNames.Add(pathInfo.Name);
            }

            return subdirectoryNames;
        }
    }
}