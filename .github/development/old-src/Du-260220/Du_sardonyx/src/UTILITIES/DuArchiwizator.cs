// =====================================================================================================================
//    FILE: Du.DuArchiwizator.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-1-2021-11:19 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

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
    /// <summary>Methods that are designed to work with Archiwizator, but can be used elsewhere.</summary>
    public class DuArchiwizator
    {
        private static readonly Action EmptyDelegate = delegate { };

        public string DirectoriesNamed { get; set; }
        public bool ExtractRootArchives { get; set; }
        public bool ExtractTargetArchives { get; set; }
        public bool PostfixDateStamp { get; set; }

        //public bool RemoveDirectoriesThatStartWith { get; set; }
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
            List<string> targetDirectories = DuDirectory.GetSubDirectoryNames(archiwizator.SourcePath);

            var numberOfTargetDirectories   = targetDirectories.Count;
            var currentTargetDirectoryCount = 1;

            List<string> namedDirectoriesToRemove = GetListOfDirectories(archiwizator.DirectoriesNamed);

            foreach(var targetDirectory in targetDirectories)
            {
                var targetPath = $"{archiwizator.SourcePath}{targetDirectory}";

                if(namedDirectoriesToRemove is not null)
                {
                    RemoveDirectory(lblProgressDetails, namedDirectoriesToRemove, targetPath);
                }

                if(archiwizator.ExtractTargetArchives)
                {
                    ExtractArchivesInTarget(lblProgressDetails, targetPath);
                }

                var destinationPath = CompleteDestinationPath(archiwizator, targetPath);

                var cmd = DuSevenZip.BuildCompressCommand(sevenZip.CompressionLevel, targetPath, destinationPath, sevenZip.DeleteSourceAfterCompression);

                if(lblProgressOverview is not null && lblProgressDetails is not null)
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

            if(lblProgressOverview is not null && lblProgressDetails is not null)
            {
                DisplayCompletionMessage(lblProgressOverview, lblProgressDetails);
            }
        }

        /// <summary>Refresh the progress label.</summary>
        /// <param name="progressLabel">The progress label.</param>
        public static void RefreshProgressDisplay(Label progressLabel)
        {
            // Use DuLabel.RefreshContent()
            _ = progressLabel.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        /// <summary></summary>
        /// <param name="archiwizator"></param>
        /// <param name="targetPath">  </param>
        /// <returns></returns>
        private static string CompleteDestinationPath(DuArchiwizator archiwizator, string targetPath)
        {
            return archiwizator.PostfixDateStamp
? $"{targetPath}-{DateTime.Now.ToString("yyMMdd")}.7z"
: $"{targetPath}.7z";
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
                if(file.Extension.ToLower() == ".zip")
                {
                    lblProgressDetails.Content = $"Uncompressing file: {file.FullName}";
                    RefreshProgressDisplay(lblProgressDetails);

                    var fileName = Path.GetFileNameWithoutExtension(file.FullName);
                    var command  = DuSevenZip.BuildXtractCommand(file.FullName, $"{targetPath}\\{fileName}");

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
                    RefreshProgressDisplay(lblProgressDetails);

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
            RefreshProgressDisplay(lblProgressOverview);

            lblProgressDetails.Content = $"DETAILS:\nCompressing source: {targetPath} \nCompression destination: {destinationPath}";
            RefreshProgressDisplay(lblProgressDetails);
        }
    }
}