// ===========================================================================================================  1:12 PM
//    FILENAME: DuHtml.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for HTML.
 */
using System.IO;
using System.Net;

namespace Du
{
    public class DuHtml
    {
        /// <summary>
        /// Get the HTML source of a URL.
        /// </summary>
        /// <param name="url">Ex: "http://whatever.com/thispage.html".</param>
        /// <returns>The HTML source of URL.</returns>
        public static string GetSource(string url)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(url);
            webRequest.Accept    = "text/html, application/xhtml+xml, */*";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            var webResponse = (HttpWebResponse) webRequest.GetResponse();

            var htmlSource = "";

            using (var dataStream = webResponse.GetResponseStream())
            {
                if (dataStream != null)
                {
                    using (var streamReader = new StreamReader(dataStream))
                    {
                        htmlSource = streamReader.ReadToEnd();
                    }
                }
            }

            return htmlSource;
        }
    }
}