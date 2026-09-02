// Delete all files in a directory.
public static void DeleteFiles(string sourceDirectory)
{
	var directoryFiles = Directory.GetFiles(sourceDirectory);

	foreach (var directoryFile in directoryFiles)
		File.Delete(directoryFile);
}

// Delete all files in a directory that are not in a list of files to keep.
public static void DeleteFilesButKeepSome(string sourceDirectory, List<string> filesToKeep)
{
	var directoryFiles = Directory.GetFiles(sourceDirectory);

	foreach (var directoryFile in directoryFiles.Where(file => !filesToKeep.Contains(Path.GetFileName(file))))
		File.Delete(directoryFile);
}