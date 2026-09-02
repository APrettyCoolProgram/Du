// Move a file from the source to the destination.
public static void MoveFile(string sourcePath, string destinationPath)
{
    if (File.Exists(sourcePath))
        File.Move(sourcePath, destinationPath);
}

// Move a file from the source to the destination, and append a timestamp.
public static void MoveFileWithTimestamp(string sourcePath, string destinationPath)
{
    if (File.Exists(sourcePath))
        File.Move(sourcePath, destinationPath + "-" + DateTime.Now.ToString("yyMMdd-HHmmss");
}
                  
// Move a file from the source to the destination, but do not overwrite existing files.
public static void MoveFileDoNotOverwrite(string sourcePath, string destinationPath)
{
    if (File.Exists(sourcePath)  && !File.Exists(destinationPath))
        File.Move(sourcePath, destinationPath;
}