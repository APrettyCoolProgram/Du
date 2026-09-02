using System;
using System.Collections.Generic;
using System.ComponentModel;
/* A class for AO.cs that interacts with the web in a variety of ways.
 * v00.52.04.161113
 * http://aprettycoolprogram.com/ao
 */

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AO
{
    public class AOWeb
    {
        public static void DownloadFile(string URL, string fileName)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                webClient.DownloadFile(URL, fileName);
            }
        }

        private static void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangeDeventArgs e)
        {
            throw new NotImplementedException();
        }




    }
}



 

//WebClient client = new WebClient();
//Uri ur = new Uri("http://remoteserver.do/images/img.jpg");
//client.Credentials = new NetworkCredential("username", "password");
//client.DownloadProgressChanged += WebClientDownloadProgressChanged;
//client.DownloadDataCompleted += WebClientDownloadCompleted;
//client.DownloadFileAsync(ur, @"C:\path\newImage.jpg");

//And her it is the implementation of the callbacks:
//void WebClientDownloadProgressChanged(object sender, DownloadProgressChangeDeventArgs e)
//{
//    Console.WriteLine("Download status: {0}%.", e.ProgressPercentage);
//}

//void WebClientDownloadCompleted(object sender, DownloadDataCompleteDeventArgs e)
//{
//    Console.WriteLine("Download finished!");
//}
