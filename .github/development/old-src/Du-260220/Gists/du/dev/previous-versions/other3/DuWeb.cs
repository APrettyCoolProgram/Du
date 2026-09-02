#region HEADER
//   PROJECT: Du
//  FILENAME: DuWeb.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with strings.
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace Du
{
    public class DuWeb
    {
        /// <summary>
        /// Get the HTML source of a random Wikipedia page.
        /// </summary>
        /// <returns> The HTML source code of a random Wikipedia page.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string GetRandomWikipediaPageSource()
        {
            return GetHTMLSource("http://en.wikipedia.org/wiki/Special:Random");
        }

        /// <summary>
        /// Search Google for a list of images and choose one at random.
        /// </summary>
        /// <param name="searchFor">The search terms (i.e. "bananna apple").</param>
        /// <param name="colorSetting">The type of color to look for [any/full/grey/transparent].</param>
        /// <returns>A random image from Goole Image Search.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static Image GetRandomGoogleImage(string searchFor, string colorSetting)
        {
            var googleImageSearchURL        = BuildGoogleImageSearchURL(searchFor, colorSetting);
            var googleImageSearchHTMLSource = GetHTMLSource(googleImageSearchURL);
            var listOfImageURLs             = GetImageURLs(googleImageSearchHTMLSource);

            if (listOfImageURLs.Count != 0)
            {
                var randomNumber      = new Random();
                var randomImageNumber = listOfImageURLs[randomNumber.Next(0, listOfImageURLs.Count)];
                var randomImage       = GetImage(randomImageNumber);

                using (var memoryStream = new MemoryStream(randomImage))
                {
                    return Image.FromStream(memoryStream);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Builds a string for a Google image search.
        /// </summary>
        /// <param name="searchFor">Search parameters (i.e. "bananna apple").</param>
        /// <param name="colorSetting">Color setting [any/full/grey/transparent].</param>
        /// <returns>A completed Google image search URL.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string BuildGoogleImageSearchURL(string searchFor, string colorSetting)
        {
            switch (colorSetting)
            {
                case "full":
                    return "https://www.google.com/search?q=" + searchFor + "&tbm=isch&tbs=ic:color";
                case "grey":
                    return "https://www.google.com/search?q=" + searchFor + "&tbm=isch&tbs=ic:gray";
                case "transparent":
                    return "https://www.google.com/search?q=" + searchFor + "&tbm=isch&tbs=ic:trans";
                default:
                    return "https://www.google.com/search?q=" + searchFor + "&tbm=isch&tbs=ic:color";
            }
        }

        /// <summary>
        /// Get the HTML source of a URL.
        /// </summary>
        /// <param name="sourceURL">The URL to get the source of (i.e. "http://whatever.com/thispage.html").</param>
        /// <returns>The HTML source.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string GetHTMLSource(string sourceURL)
        {
            var request       = (HttpWebRequest) WebRequest.Create(sourceURL);
            request.Accept    = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            var response      = (HttpWebResponse) request.GetResponse();
            var workString    = string.Empty;

            using (var dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                {
                    return string.Empty;
                }
                else
                {
                    using (var streamReader = new StreamReader(dataStream))
                    {
                        workString = streamReader.ReadToEnd();
                    }
                }
            }

            return workString;
        }

        /// <summary>
        /// Parse HTML source, and put any URLs into a list.
        /// /summary>
        /// <param name="html">The HTML to parse.</param>
        /// <returns>A list of URLs in the source.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static List<string> GetImageURLs(string html)
        {
            var listOfURLs = new List<string>();
            var ndx        = html.IndexOf("\"ou\"", StringComparison.Ordinal);

            while (ndx >= 0)
            {
                ndx      = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
                ndx++;
                var ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
                var url  = html.Substring(ndx, ndx2 - ndx);
                listOfURLs.Add(url);
                ndx      = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
            }

            return listOfURLs;
        }

        /// <summary>
        /// Get an image from a website.
        /// </summary>
        /// <param name="imageURL">URL of the image.</param>
        /// <returns>An image.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        private static byte[] GetImage(string imageURL)
        {
            var request  = (HttpWebRequest) WebRequest.Create(imageURL);
            var response = (HttpWebResponse) request.GetResponse();

            using (var dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                {
                    return null;
                }
                else
                {
                    using (var binaryReader = new BinaryReader(dataStream))
                    {
                        return binaryReader.ReadBytes(100000000);
                    }
                }
            }
        }
    }
}