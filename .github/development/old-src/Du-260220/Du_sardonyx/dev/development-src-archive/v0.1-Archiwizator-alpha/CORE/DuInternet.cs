/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuInternet.cs
 * UPDATED: 12-28-2020-12:29 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

namespace Du
{
    public class DuInternet
    {
        /// <summary>Downloads a file from a website.</summary>
        /// <param name="fileUrl">The file URL</param>
        /// <param name="savePath">The path to save the file.</param>
        public static void DownloadFile(string fileUrl, string savePath)
        {
            var webClient = new System.Net.WebClient();
            webClient.DownloadFile(fileUrl, savePath);
        }
    }
}