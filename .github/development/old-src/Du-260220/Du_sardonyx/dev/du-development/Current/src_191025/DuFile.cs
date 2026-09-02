// ===========================================================================================================  12:47 PM
//    FILENAME: DuFile.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for files.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace Du
{
    public class DuFile
    {
         /// <summary>
        /// Append a data string to a file.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file/".</param>
        /// <param name="dataToAppend">The data string to append.</param>
        public static void AppendData(string filePath, string dataToAppend)
        {
            DuFile.CreateIfNonExistant(filePath);

            using (var tester = new StreamWriter(filePath, true))
            {
                tester.WriteLine(dataToAppend);
            }

            //File.AppendAllText(filePath, dataToAppend);
        }

        /// <summary>
        /// Moves a file from one location to another, optionally appending a timestamp.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file".</param>
        /// <param name="backupDir">Ex: "/backup/directory/".</param>
        /// <param name="useTimestamp">[true/false]</param>
        public static void Backup(string filePath, string backupDir, bool useTimestamp)
        {
            if (File.Exists(filePath))
            {
                var timeStamp = "_" + DateTime.Now.ToString("yyMMdd-HHmmss");

                var backupFilePath = useTimestamp
                    ? backupDir + Path.GetFileName(filePath) + timeStamp
                    : backupDir + Path.GetFileName(filePath);

                File.Move(filePath, backupFilePath);
            }
            else
            {
                DuPopup.ErrorMessage("This application has encountered an error", "The source file cannot be found.");
            }
        }

        public static List<string> AsLines(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="overwrite"></param>
        /// <param name="logFileName"></param>
        public static void Copy(string source, string destination, bool overwrite, string logFileName = "")
        {
            if (source.Contains("%userprofile%"))
            {
                source = Environment.ExpandEnvironmentVariables(source);
            }

            if (!File.Exists(source))
            {
                DuPopup.ErrorMessage("This application has encountered an error", "The source file cannot be found.");

                if (logFileName != "")
                {
                    DuLog.AppendData(logFileName, "Source file does not exist or could not be found: " + source);
                    Environment.Exit(0);
                }
            }
            else
            {
                if ((!File.Exists(destination)) || (overwrite))
                {
                    File.Copy(source, destination, true);
                }
            }
        }

        /// <summary>
        /// Checks for the existance of a filePath, and creates it if necessary.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file/".</param>
        public static void CreateIfNonExistant(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        /// <summary>
        /// Delete a file, if it exists.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file"</param>
        public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Simple, non-GUI file downloader.
        /// </summary>
        /// <param name="url">Ex: "https://website.com/directory/file:"</param>
        /// <param name="filePath">Ex: "/path/to/file"</param>
        public static void Download(string url, string filePath)
        {
            var webClient = new WebClient();

            using (webClient)
            {
                webClient.DownloadFile(new Uri(url), filePath);
            }
        }

        ///<summary>
        /// Extract part of a file as a List<string>.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file/"</param>
        /// <param name="startFlag">Text that indicates the start of the data to extract (Ex: "!--start here")</param>
        /// <param name="endFlag">Text that indicates the end of the data to extract (Ex: "end here--")</param>
        /// <returns>The extracted portion as a List<string>.</returns>
        public static List<string> ExtractData(string filePath, string startFlag, string endFlag)
        {
            var extractedData = new List<string>();
            var recording = false;
            var fileLines = DuFile.ToList(filePath);

            foreach (var line in fileLines)
            {
                if (line.StartsWith(startFlag))
                {
                    recording = true;
                    continue;
                }

                if ((recording) && (line.StartsWith(endFlag)))
                {
                    break;
                }

                if ((recording) && (line != string.Empty))
                {
                    extractedData.Add(line);
                }
            }

            return extractedData;
        }

        /// <summary>
        /// Extract items from a compressed file.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file"</param>
        /// <param name="targetDirectory">Ex: "/target/directory/"</param>
        public static void Uncompress(string filePath, string targetDirectory)
        {
            ZipFile.ExtractToDirectory(filePath, targetDirectory);
        }

        /// <summary>
        /// Get the name and extension of a filePath.
        /// </summary>
        /// <param name="filePath">Ex. "/path/to/file" </param>
        /// <returns></returns>
        public static string GetNameAndExtension(string filePath)
        {
            var components = filePath.Split('/');
            return components[components.Length - 1];
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void Move(string source, string destination)
        {
            if (File.Exists(source))
            {
                Delete(destination);
                File.Move(source, destination);
            }
        }

        /// <summary>
        /// Convert the contents of a file to a List<string>.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file"</param>
        /// <returns>The file as a List<string></returns>
        public static List<string> ToList(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileContent"></param>
        public static void WriteAllText(string filePath, string fileContent)
        {
            CreateIfNonExistant(filePath);
            File.WriteAllText(filePath, fileContent);
        }

    }
}