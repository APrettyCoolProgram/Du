// Recursively copy a directory.
public static void CopyDirectoryRecursive(string sourceDirectory, string destinationDirectory, bool overwriteFiles)
{
    if (Exists(sourceDirectory))
    {
        if (!Exists(destinationDirectory))
            Directory.CreateDirectory(destinationDirectory);

        var sourceDirectoryInfo = new DirectoryInfo(sourceDirectory);

        DirectoryInfo[] sourceDirectorySubDirectories    = sourceDirectoryInfo.GetDirectories();
        FileInfo[]      sourceDirectorySubDirectoryFiles = sourceDirectoryInfo.GetFiles();

        foreach (var sourceDirectorySubDirectoryFile in sourceDirectorySubDirectoryFiles)
        {
            var fileDestinationPath = Path.Combine(destinationDirectory, sourceDirectorySubDirectoryFile.Name);
            sourceDirectorySubDirectoryFile.CopyTo(fileDestinationPath, overwriteFiles);
        }

        foreach (var sourceDirectorySubDirectory in sourceDirectorySubDirectories)
        {
            var fileDestinationPath = Path.Combine(destinationDirectory, sourceDirectorySubDirectory.Name);
            CopyDirectoryRecursive(sourceDirectorySubDirectory.FullName, fileDestinationPath, overwriteFiles);
        }
    }
}