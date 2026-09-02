// 260711_code
// 260711_documentation

namespace Du;

/// <summary>Logic related to directories.</summary>
public static class DuDirectory
{
    //v1.0.0.0
    /// <summary>Force create a directory if it does not exist.</summary>
    /// <param name="directory">The path of the directory to create.</param>
    /// <example>
    /// <code>
    /// DuDirectory.ForceCreate("C:\\MyDirectory");
    /// </code>
    /// </example>
    public static void ForceCreate(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    //v1.0.0.0
    /// <summary>Force create a list of directories if they do not exist.</summary>
    /// <param name="directories">The list of directory paths to create.</param>
    /// <example>
    /// <code>
    /// DuDirectory.ForceCreate(new List<string> { "C:\\MyDirectory1", "C:\\MyDirectory2" });
    /// </code>
    /// </example>
    public static void ForceCreate(List<string> directories)
    {
        foreach (var directory in directories)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}