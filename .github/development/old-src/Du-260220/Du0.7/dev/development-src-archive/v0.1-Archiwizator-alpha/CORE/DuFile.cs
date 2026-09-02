/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuFile.cs
 * UPDATED: 12-28-2020-12:28 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.IO;

namespace Du
{
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
