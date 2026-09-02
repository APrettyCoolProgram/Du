// ===========================================================================================================  1:19 PM
//    FILENAME: DuDownload.xaml.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Media;

namespace Du
{
    /// <summary>
    /// Interaction logic for DuDownload.xaml
    /// </summary>
    public partial class DuDownload : Window
    {
        /// <summary>
        /// Default contstructor - not used.
        /// </summary>
        public DuDownload()
        {
            /* Not used.
             */
            InitializeComponent();
        }

         /// <summary>
         /// Standard constructor.
         /// </summary>
        /// <param name="downloadManifest">Information about the download.</param>
        public DuDownload(Dictionary<string, string> downloadManifest)
        {
            InitializeComponent();

            /*  If the downloadManifest includes an entry for "fontDirectory", we'll assume there are some
             *  customizations that need to be done. Otherwise we'll use the default fonts, etc.
             */
            if (downloadManifest.ContainsKey("fontDirectory"))
            {
                SetupWindow(downloadManifest);
            }

            var test = 0;

            Download(downloadManifest);
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <param name="destination"></param>
        public static void Download(string url, string destination)
        {
            var downloadManifest = new Dictionary<string, string>
            {
                {"url",         url},
                {"destination", destination}
            };

            var downloader = new DuDownload(downloadManifest);
            downloader.ShowDialog();
        }



        /// <summary>
        /// Customize the look/feel of the download window
        /// </summary>
        /// <param name="downloadManifest">Information about the download.</param>
        private void SetupWindow(Dictionary<string, string> downloadManifest)
        {
            var fontDirectory = downloadManifest["fontDirectory"];
            var fontName = downloadManifest["fontName"];

            DownloadMessage.FontFamily = new FontFamily(new Uri(fontDirectory), fontName);
        }

        /// <summary>
        /// Download a file from a URL.
        /// </summary>
        /// <param name="downloadManifest">Information about the download.</param>
        private void Download(Dictionary<string, string> downloadManifest)
        {
            var url = downloadManifest["url"];
            var destination = downloadManifest["destination"];

            /*  Let's get the filename so we can display it instead of an entire URL.
             */
            var fileName = DuFile.GetNameAndExtension(url);

            DownloadMessage.Content = "Downloading " + fileName;

            var webClient = new WebClient();

            using (webClient)
            {
                webClient.DownloadProgressChanged += DownloadProgressChanged;
                webClient.DownloadFileCompleted += DownloadCompleted;
                webClient.DownloadFileAsync(new Uri(url), destination);
            }
        }

        /// <summary>
        /// Update the download progress bar.
        /// </summary>
        private void DownloadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DownloadProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// What to do when the download is complete.
        /// </summary>
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            /*  Eventually we'll handle cancellations and errors, but for now I'm going to comment this section.
             */
            //if (e.Cancelled)
            //{
            //    DownloadMessage.Content = "The download has been cancelled";
            //    return;
            //}

            //if (e.Error != null)
            //{
            //    DownloadMessage.Content = "An error occured when downloading the file.";
            //    return;
            //}

            DownloadMessage.Content = "The download has completed";
            Close();
        }
    }
}