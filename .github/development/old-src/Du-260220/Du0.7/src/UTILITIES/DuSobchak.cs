// =====================================================================================================================
//    FILE: Du.DuSobchak.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-1-2021-11:20 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

/* This class is specific to Sobchak (https://github.com/APrettyCoolProgram/Sobchak), but the methods have
 * been written to be used for other non-Archiwizator applications that want to use more advanced 7-Zip functionalty.
 */

using System.IO;

namespace Du
{
    /// <summary>Methods designed to be used with Sobchak, but can be used elsewhere.</summary>
    public class DuSobchak
    {
        public static void CreateSobchaks(string sourcePath)
        {
            DuDirectory.Create($"{sourcePath}/.sobchak");

            FileInfo[] files = Du.DuDirectory.GetFileNames(sourcePath);

            foreach(FileInfo file in files)
            {
                DuSha256.WriteHashValueAsContent(file.FullName, $"{sourcePath}/.sobchak/{file.Name}.sobchak");
            }
        }
    }
}
