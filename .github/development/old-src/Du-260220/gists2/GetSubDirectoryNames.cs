// Get all subdirectory names.
public static List<string> GetSubDirectoryNames(string sourceDirectory)
{
    var subDirectoryNames = new List<string>();

    foreach (var subDirectoryName in Directory.GetDirectories(sourceDirectory))
    {
        var subDirectoryInfo = new DirectoryInfo(subDirectoryName);
        subDirectoryNames.Add(subDirectoryInfo.Name);
    }

    return subDirectoryNames;
}