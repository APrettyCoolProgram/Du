// Get the file name.
public static string GetFileName(string filePath)
{
    return Path.GetFileNameWithoutExtension(filePath);
}

// Get the file extension.
public static string GetFileExtension(string filePath)
{
    return Path.GetExtension(filePath).Replace(".", "");
}

// Get the file name and extension.
public static string GetFileNameAndExtension(string filePath)
{
    var components = filePath.Split('/');
    
    return components[components.Length - 1];
}