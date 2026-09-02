// Check to see if a file exists, and create it if it does not.
public static void CreateFile(string filePath)
{
    if (!File.Exists(filePath))
        File.Create(filePath);
}