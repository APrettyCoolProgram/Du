// Check to see if a directory exists, and create it if it doesn't.
public static void CreateDirectory(string sourceDirectory)
{
	if (!Exists(sourceDirectory))
    	Directory.CreateDirectory(sourceDirectory);
}
