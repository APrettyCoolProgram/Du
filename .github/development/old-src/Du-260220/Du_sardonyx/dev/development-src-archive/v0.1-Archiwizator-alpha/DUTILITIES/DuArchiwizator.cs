/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuArchiwizator.cs
 * UPDATED: 12-30-2020-8:43 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* This class is specific to Archiwizator (https://github.com/APrettyCoolProgram/Archiwizator), but the methods have
 * been written to be used for other non-Archiwizator applications that want to use more advanced 7-Zip functionalty.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Du
{
    public class DuArchiwizator
    {
        private static readonly Action EmptyDelegate = delegate { };

        public string DirectoriesNamed { get; set; }
        public bool ExtractRootArchives { get; set; }
        public bool ExtractTargetArchives { get; set; }
        public bool PostfixDateStamp { get; set; }

        // Disabled for current release
        //public bool RemoveDirectoriesThatStartWith { get; set; }
        // Disabled for current release
        //public string DirectoriesThatStartWith     { get; set; }
        public bool RemoveDirectoriesNamed { get; set; }

        public string SourcePath { get; set; }

        /// <summary>Create a new 7-Zip archive.</summary>
        /// <param name="archiwizator">       Contains details about this session of Archiwizator.</param>
        /// <param name="sevenZip">           Contains details about this session of 7-Zip.</param>
        /// <param name="lblProgressOverview">The progress overview label (optional).</param>
        /// <param name="lblProgressDetails"> The progress details label (optional).</param>
        public static void CreateArchive(DuArchiwizator archiwizator, DuSevenZip sevenZip, Label lblProgressOverview = null, Label lblProgressDetails = null)
        {
            List<string> targetDirectories  = DuDirectory.GetSubDirectoryNames(archiwizator.SourcePath);
            var numberOfTargetDirectories   = targetDirectories.Count;
            var currentTargetDirectoryCount = 1;

            List<string> namedDirectoriesToRemove = GetListOfDirectories(archiwizator.DirectoriesNamed);
            //List<string> matchingDirectoriesToRemove = GetListOfDirectories(archiwizator.DirectoriesMatching); // Feature

            foreach(var targetDirectory in targetDirectories)
            {
                var targetPath = $"{archiwizator.SourcePath}{targetDirectory}";
                //var destinationPath = "";

                if(namedDirectoriesToRemove != null)
                {
                    RemoveDirectory(lblProgressDetails, namedDirectoriesToRemove, targetPath);
                }

                // Matching sub-directory code goes here.

                // Extract root archive code goes here.

                if(archiwizator.ExtractTargetArchives)
                {
                    ExtractArchivesInTarget(lblProgressDetails, targetPath);
                }

                var destinationPath = CompleteDestinationPath(archiwizator, targetPath);

                var cmd = DuSevenZip.BuildCompressCommand(sevenZip.CompressionLevel, targetPath, destinationPath, sevenZip.DeleteSourceAfterCompression);

                if(lblProgressOverview != null && lblProgressDetails != null)
                {
                    UpdateProgressMessage(lblProgressOverview, lblProgressDetails, numberOfTargetDirectories, currentTargetDirectoryCount, targetDirectory, targetPath, destinationPath);
                }

                DuSevenZip.CreateFromDirectory(cmd);

                if(sevenZip.DeleteSourceAfterCompression)
                {
                    DuDirectory.Delete(targetPath);
                }

                currentTargetDirectoryCount++;
            }

            if(lblProgressOverview != null && lblProgressDetails != null)
            {
                DisplayCompletionMessage(lblProgressOverview, lblProgressDetails);
            }
        }

        /// <summary>Refresh the progress label.</summary>
        /// <param name="label">The progress label.</param>
        public static void Refresh(Label label)
        {
            label.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        /// <summary></summary>
        /// <param name="archiwizator"></param>
        /// <param name="targetPath">  </param>
        /// <returns></returns>
        private static string CompleteDestinationPath(DuArchiwizator archiwizator, string targetPath)
        {
            string destinationPath;
            if(archiwizator.PostfixDateStamp)
            {
                var dt = DateTime.Now.ToString("yyMMdd");

                destinationPath = $"{targetPath}-{dt}.7z";
            }
            else
            {
                destinationPath = $"{targetPath}.7z";
            }

            return destinationPath;
        }

        /// <summary></summary>
        /// <param name="lblProgressOverview"></param>
        /// <param name="lblProgressDetails"> </param>
        private static void DisplayCompletionMessage(Label lblProgressOverview, Label lblProgressDetails)
        {
            lblProgressOverview.Content = $"PROGRESS: COMPLETE!";
            lblProgressDetails.Content = "";
        }

        /// <summary></summary>
        /// <param name="lblProgressDetails"></param>
        /// <param name="targetPath">        </param>
        private static void ExtractArchivesInTarget(Label lblProgressDetails, string targetPath)
        {
            FileInfo[] files = DuDirectory.GetFileNames(targetPath);

            foreach(FileInfo file in files)
            {
                var fileExtension = file.Extension.ToLower();

                if(fileExtension == ".zip")
                {
                    lblProgressDetails.Content = $"Uncompressing file: {file.FullName}";
                    Refresh(lblProgressDetails);

                    var fi = Path.GetFileNameWithoutExtension(file.FullName);

                    var command = DuSevenZip.BuildXtractCommand(file.FullName, $"{targetPath}\\{fi}");

                    DuSevenZip.ExtractToDirectory(command);

                    DuFile.Delete(file.FullName);
                }
            }
        }

        /// <summary></summary>
        /// <param name="directoryList"></param>
        /// <returns></returns>
        private static List<string> GetListOfDirectories(string directoryList)
        {
            return directoryList != ""
                ? DuString.ToListAtDelimiter(directoryList, ',')
                : null;
        }

        /// <summary></summary>
        /// <param name="lblProgressDetails">               </param>
        /// <param name="namedSourceSubDirectoriesToRemove"></param>
        /// <param name="sourcePath">                       </param>
        private static void RemoveDirectory(Label lblProgressDetails, List<string> namedSourceSubDirectoriesToRemove, string sourcePath)
        {
            List<string> subSubDirectories = DuDirectory.GetSubDirectoryNames(sourcePath);

            foreach(var subsub in subSubDirectories)
            {
                if(namedSourceSubDirectoriesToRemove.Contains(subsub))
                {
                    lblProgressDetails.Content = $"DETAILS:\nRemoving directory: {sourcePath}\\{ subsub}";
                    Refresh(lblProgressDetails);

                    DuDirectory.Delete($"{sourcePath}\\{subsub}");
                }
            }
        }

        /// <summary></summary>
        /// <param name="lblProgressOverview">        </param>
        /// <param name="lblProgressDetails">         </param>
        /// <param name="numberOfTargetDirectories">  </param>
        /// <param name="currentTargetDirectoryCount"></param>
        /// <param name="targetDirectory">            </param>
        /// <param name="targetPath">                 </param>
        /// <param name="destinationPath">            </param>
        private static void UpdateProgressMessage(Label lblProgressOverview, Label lblProgressDetails, int numberOfTargetDirectories, int currentTargetDirectoryCount, string targetDirectory, string targetPath, string destinationPath)
        {
            lblProgressOverview.Content = $"PROGRESS: File {currentTargetDirectoryCount} of {numberOfTargetDirectories}: {targetDirectory}";
            Refresh(lblProgressOverview);

            lblProgressDetails.Content = $"DETAILS:\nCompressing source: {targetPath} \nCompression destination: {destinationPath}";
            Refresh(lblProgressDetails);
        }
    }
}