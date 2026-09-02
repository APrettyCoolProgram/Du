// =====================================================================================================================
//    FILE: Du.DuInternet.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-1-2021-11:19 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

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