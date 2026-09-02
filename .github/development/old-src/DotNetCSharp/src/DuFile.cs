// 260711_code
// 260711_documentation

namespace Du;

/// <summary>Logic related to directories.</summary>
public static class DuFile
{
    //v1.0.0.0
    /// <summary>Force create a file if it does not exist.</summary>
    /// <param name="fileName">The path of the file to create.</param>
    /// <example>
    /// <code>
    /// DuFile.ForceCreate("C:\\MyFile.txt");
    /// </code>
    /// </example>
    public static void ForceCreate(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Dispose();
        }
    }
}