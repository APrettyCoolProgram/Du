// Checks to see if a file exists, and delete it if it does.
public static void DeleteFile(string filePath)
{
    if(File.Exists(filePath))
    	File.Delete(filePath);
}