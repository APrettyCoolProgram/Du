#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuDirectory.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with directories.
#endregion

#region USING
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion

namespace Du
{
    public class DuDirectory
    {
        /// <summary></summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static bool CheckExist(string directoryName)
        {
            return Directory.Exists(directoryName);
        }

        /// <summary>Gets names of subdirectories in a directory.</summary>
        /// <param name="parent"> The parent directory.</param>
        /// <build>180225</build>
        /// <returns>A list of subdirectory names.</returns>
        /// <remarks></remarks>
        public static List<string> GetSubdirectoryNames(string parent)
        {
            var subdirectoryNames = new List<string>();

            foreach (var subdirectory in Directory.GetDirectories(parent))
            {
                var pathInfo = new DirectoryInfo(subdirectory);
                subdirectoryNames.Add(pathInfo.Name);
            }
            return subdirectoryNames;
        }

        /// <summary>Gets names of subdirectory paths in a directory.</summary>
        /// <param name="parent"> The parent directory.</param>
        /// <build>180225</build>
        /// <returns>A list of subdirectory paths.</returns>
        /// <remarks></remarks>
        public static List<string> GetSubdirectoryPaths(string parent)
        {
            return Directory.GetDirectories(parent).ToList();
        }

        /// <summary></summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static string[] GetFileNames(string directory)
        {
            return Directory.GetFiles(directory);
        }

        /// <summary></summary>
        /// <param name="directoryName"></param>
        /// <param name="addTrailingSlash"></param>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static void New(string directoryName, bool addTrailingSlash)
        {
            if (addTrailingSlash)
            {
                directoryName = directoryName + @"\";
            }

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        /// <summary></summary>
        /// <param name="rootPath"></param>
        /// <param name="directoryNames"></param>
        /// <param name="addTrailingSlash"></param>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static void New(string rootPath, List<string> directoryNames, bool addTrailingSlash)
        {
            foreach (var directoryName in directoryNames)
                New(directoryName, addTrailingSlash);
        }

        /// <summary>Gets the location of a special Windows directory.</summary>
        /// <param name="directory">The directory name.</param>
        /// <returns>The full path of the directory.</returns>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static string GetSpecial(string directory)
        {
            switch (directory.ToLower())
            {
                case "admintools":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.AdminTools);
                }

                case "applicationdata":
                case "appdata":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                }

                case "cdburning":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.CDBurning);
                }

                case "desktop":
                case "mydesktop":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }

                case "documents":
                case "mydocuments":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                case "favorites":
                case "myfavorites":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
                }

                case "fonts":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
                }

                case "music":
                case "myMusic":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                }

                case "pictures":
                case "photos":
                case "mypictures":
                case "myphotos":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                }

                case "programfiles":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                }

                case "startup":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                }

                case "user":
                case "userprofile":
                case "myuserprofile":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                }

                case "Windows":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                }

                case "videos":
                case "myvideos":
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                }

                default:
                {
                    return "ERROR: Directory does not exist.";
                }
            }
        }

    }
}