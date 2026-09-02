// Get all files names in a directory.
public static List<string> GetFileNames(string sourceDirectory)
{
  return Directory.GetFiles(sourceDirectory).ToList();
}

// Get all file names in a directory with a specific extension.
public static List<string> GetFilesWithSpecificExtension(string sourceDirectory, string fileExtension)
{
  	return Directory.GetFiles(sourceDirectory, "*." + fileExtension, SearchOption.AllDirectories).ToList();
}

// Get all file names in a directory with specific extensions.
public static List<string> GetFilesWithSpecificExtensions(string sourceDirectory, List<string> fileExtensions)
{
    var listOfFiles = new List<string>();

    foreach (var extension in fileExtensions)
    {
        var extensionFiles = Directory.GetFiles(sourceDirectory, "*." + extension, SearchOption.AllDirectories).ToList();

        foreach (var extensionFile in extensionFiles)
            listOfFiles.Add(extensionFile);
    }

    return listOfFiles;
}  