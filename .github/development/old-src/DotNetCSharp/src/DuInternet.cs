// 260711_code
// 260711_documentation;

namespace Du;

/// <summary>Logic related to internet operations.</summary>
public static class DuInternet
{
    // v1.0.0.0
    /// <summary>Download a file from a URL to a local path.</summary>
    /// <remarks>
    /// This method downloads a file without any message indicating success or failure.<br/>
    /// <br/>
    /// If you want to download a file and receive a message indicating success or failure, use the overloaded method <see cref="DownloadUrl(string, string, string)"/>.
    /// </remarks>
    /// <param name="url">The URL of the file to download.</param>
    /// <param name="localPath">The local path where the file will be saved.</param>
    /// <example>
    /// <code>
    /// DuInternet.DownloadUrlToLocalFile("https://example.com/file.txt", "C:\\path\\to\\file.txt");
    /// </code>
    /// </example>
    public static void DownloadUrl(string url, string localPath)
    {
        var client   = new HttpClient();
        var response = client.GetAsync(url).Result;

        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsByteArrayAsync().Result;
            File.WriteAllBytes(localPath, content);
        }
    }

    // v1.0.0.0
    /// <summary>Download a file from a URL to a local path with a message indicating success or failure.</summary>
    /// <remarks>
    /// This method downloads a file and returns a message indicating whether the download was successful or not.<br/>
    /// <br/>
    /// If you want to download a file without any message, use the <see cref="DownloadUrl(string, string)"/>.
    /// </remarks>
    /// <param name="url">The URL of the file to download.</param>
    /// <param name="localPath">The local path where the file will be saved.</param>
    /// <param name="msg">The message to include in the result.</param>
    /// <example>
    /// <code>
    /// string result = DuInternet.DownloadUrlToLocalFile("https://example.com/file.txt", "C:\\path\\to\\file.txt", "Download");
    /// Console.WriteLine(result);
    /// </code>
    /// </example>
    /// <returns>A message indicating success or failure.</returns>
    public static string DownloadUrl(string url, string localPath, string msg)
    {
        var client   = new HttpClient();
        var response = client.GetAsync(url).Result;

        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsByteArrayAsync().Result;

            File.WriteAllBytes(localPath, content);

            return $"{msg}successful";
        }
        else
        {
            return $"{msg}failed: {response.StatusCode}";
        }
    }
}