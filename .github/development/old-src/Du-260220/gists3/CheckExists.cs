// Check to see if a directory exists.
public static bool Exists(string sourceDirectory)
{
    var directoryInfo = new DirectoryInfo(sourceDirectory);

    return directoryInfo.Exists;
}