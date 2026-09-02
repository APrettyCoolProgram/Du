/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuSevenZip.cs
 * UPDATED: 1-27-2021-8:32 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  7-Zip (https://www.7-zip.org/)
 *  In order to use these methods, you will need the 7-Zip standalone console version: https://www.7-zip.org/a/7z1900-extra.7z
 */

namespace Du
{
    /// <summary>Methods that are used with 7-Zip.</summary>
    public class DuSevenZip
    {
        public string Action { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public string CompressionLevel { get; set; }
        public bool DeleteSourceAfterCompression { get; set; }

        /// <summary></summary>
        /// <param name="compressionLevel"></param>
        /// <param name="sourcePath">      </param>
        /// <param name="destinationPath"> </param>
        /// <param name="deleteFiles">     </param>
        /// <returns></returns>
        public static string BuildCompressCommand(string compressionLevel, string sourcePath, string destinationPath, bool deleteFiles)
        {
            var compressLevel   = GetCompressioLevelArgument(compressionLevel);
            var sevenZipCommand = $"a {compressLevel} \"{destinationPath}\" \"{sourcePath}\"\\* -bsp2";

            //TODO: This may not be necessary.
            if(deleteFiles)
            {
                sevenZipCommand += " -sdel";
            }

            return sevenZipCommand;
        }

        /// <summary></summary>
        /// <param name="sourcePath">     </param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static string BuildXtractCommand(string sourcePath, string destinationPath)
        {
            return $"x \"{sourcePath}\" -o\"{destinationPath}\"";
        }

        /// <summary></summary>
        /// <param name="command"></param>
        public static void CreateFromDirectory(string command)
        {
            var exePath = GetExePath();

            DuOperatingSystem.MSWindows.ExecuteCommand(exePath, command);
            //DuFile.Delete(archiveFilePath);
        }

        /// <summary></summary>
        /// <param name="command"></param>
        public static void ExtractToDirectory(string command)
        {
            var exePath = GetExePath();

            DuOperatingSystem.MSWindows.ExecuteCommand(exePath, command);
            //DuFile.Delete(archiveFilePath);
        }

        /// <summary></summary>
        /// <returns></returns>
        private static string GetExePath() => DuOperatingSystem.MSWindows.Is64Bit()
                ? @"./Resources/Du/Bin/7Zip/64bit/7za.exe"
                : @"./Resources/Du/Bin/7Zip/32bit/7za.exe";

        /// <summary></summary>
        /// <param name="compressLevel"></param>
        /// <returns></returns>
        private static string GetCompressioLevelArgument(string compressLevel)
        {
            return compressLevel switch
            {
                "Fastest" => "-mx1",
                "Fast" => "-mx3",
                "Normal" => "-mx5",
                "Maximum" => "-mx7",
                "Ultra" => "-mx9",
                _ => "-mx0",
            };
        }
    }
}