// =====================================================================================================================
//    FILE: Du.DuFile.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-30-2021-11:29 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

using System.IO;

namespace Du
{
    /// <summary>Does various things with local files.</summary>
    public class DuFile
    {
        /// <summary>Deletes a file.</summary>
        /// <param name="filePath"></param>
        /// <remarks>
        /// * This will check to see if the file exists prior to attempting to delete.
        /// </remarks>
        public static void Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
