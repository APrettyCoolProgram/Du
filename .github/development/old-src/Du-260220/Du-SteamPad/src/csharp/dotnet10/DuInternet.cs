// 251231_code
// 251231_documentation

namespace Du;

public class DuInternet
{
    public static void DownloadFileFromUrl(string fileUrl, string targetPath)
    {
        using var client = new HttpClient();
        using var response = client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult();
        response.EnsureSuccessStatusCode();
        using var stream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
        using var fileStream = System.IO.File.Create(targetPath);
        stream.CopyTo(fileStream);
    }
}