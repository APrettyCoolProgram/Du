/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuCompression.cs
 * UPDATED: 12-28-2020-12:24 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  This class uses the Windows built-in Zip compression.
 *
 *  Please see DUTILITIES.DuSevenZip.cs for 7-Zip compatible compression.
 */

using System.IO.Compression;

namespace Du
{
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