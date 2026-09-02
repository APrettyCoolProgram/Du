// =====================================================================================================================
//    FILE: Du.DuZip.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-1-2021-11:19 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

/*  This class uses the Windows built-in Zip compression.
 *
 *  Please see UTILITIES.DuSevenZip.cs for 7-Zip compatible compression.
 */

using System.IO.Compression;

namespace Du
{
    /// <summary>Methods that do things with the Windows built-in compression tools.</summary>
    public class DuZip
    {
        /// <summary>Archive the contents of a directory into a .zip file.</summary>
        /// <param name="sourceDirectory">The directory to archive.</param>
        /// <param name="archiveFilePath">The archyive filename.</param>
        /// <param name="compressionLevel">Compression level (default: "optimal").</param>
        /// <param name="includeBaseDirectory">Include the directory name, or just the files (default: false).</param>
        public static void CreateFromDirectory(string sourceDirectory, string archiveFilePath, CompressionLevel compressionLevel = CompressionLevel.Optimal, bool includeBaseDirectory = false)
        {
            DuFile.Delete(archiveFilePath);
            ZipFile.CreateFromDirectory(sourceDirectory, archiveFilePath, compressionLevel, includeBaseDirectory);
        }
    }
}