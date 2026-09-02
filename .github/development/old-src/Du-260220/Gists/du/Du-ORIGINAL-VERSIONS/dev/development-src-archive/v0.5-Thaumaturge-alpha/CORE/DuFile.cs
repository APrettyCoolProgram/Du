/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuFile.cs
 * UPDATED: 1-27-2021-8:28 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

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
