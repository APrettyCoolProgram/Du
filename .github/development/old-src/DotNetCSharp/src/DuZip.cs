// 260711_code
// 260711_documentation;

namespace Du;

/// <summary>Logic related to zip files.</summary>
public static class DuZip
{
    //v1.0.0.0
    /// <summary>Unzips a zip file to a specified directory. If the directory does not exist, it will be created.</summary>
    /// <param name="zipFilePath">The path of the zip file to unzip.</param>
    /// <param name="extractPath">The path of the directory to extract the zip file to.</param>
    /// <example>
    /// <code>
    /// DuZip.UnzipFile("C:\\MyZipFile.zip", "C:\\MyExtractedFiles");
    /// </code>
    /// </example>
    public static void UnzipFile(string zipFilePath, string extractPath)
    {
        DuDirectory.ForceCreate(extractPath);

        System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractPath, true);
    }

    //v1.0.0.0
    /// <summary>Unzips a zip file to a specified directory. If the directory does not exist, it will be created.</summary>
    /// <param name="zipFilePath">The path of the zip file to unzip.</param>
    /// <param name="extractPath">The path of the directory to extract the zip file to.</param>
    /// <example>
    /// <code>
    /// DuZip.UnzipFile("C:\\MyZipFile.zip", "C:\\MyExtractedFiles");
    /// </code>
    /// </example>
    public static string UnzipFile(string zipFilePath, string extractPath, string msg)
    {
        DuDirectory.ForceCreate(extractPath);

        try
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractPath, true);

            return $"{msg}success";
        }
        catch (Exception e)
        {
            return $"{msg}failed: {e.Message}";
        }
    }
}