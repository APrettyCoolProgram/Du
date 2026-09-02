// Check to see if a directory ends with a trailing slash. [b201215]
public static bool CheckForTrailingSlash(string directoryPath)
{
    return directoryPath.EndsWith('\\');
}

// Get the absolute path of a directory. [b201215]
public static string GetAbsolutePath(string relativePath)
{
    return AppDomain.CurrentDomain.BaseDirectory + relativePath;
}