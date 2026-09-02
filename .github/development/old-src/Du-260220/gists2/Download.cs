// Download a file from a URL.
public static void DownloadFileFromUrl(string urlPath, string destinationPath)
{
    var webClient = new WebClient();

    using (webClient)
        webClient.DownloadFile(new Uri(urlPath), destinationPath);
}