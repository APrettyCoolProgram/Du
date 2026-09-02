// Convert an external text file to a string.
public static string ConvertExternalTextFileToString(string filePath)
{
    return File.ReadAllLines(filePath).ToList().ToString()
}

// Convert an embedded text file to a string.
public static string ConvertEmbeddedTextFileToString(string filePath, string assemblyName)
{
    var fileAsList = new List<string>();
    var fullPath   = assembly + "." + filePath;

    using (StreamReader fileToRead = new StreamReader(Assembly.Load(assembly).GetManifestResourceStream((string)fullPath)))
        fileAsList = Read(fileToRead);
  
    return fileAsList.ToString();
}

// Convert an external text file to a Dictionary<string, string>.
public static Dictionary<string, string> ConvertExternalTextFileToStringDictionary(string filePath, char delimiter)
{
    // TBD
}

// Convert an embedded text file to a Dictionary<string, string>.
public static Dictionary<string, string> ConvertEmbeddedTextFileToStringDictionary(string filePath, char delimiter, string assemblyName)
{
    // TBD
}

// Convert external text files to a List<Dictionary<string, string>>.
public static List<Dictionary<string, string>> ConvertExternalTextFilesToListOfStringDictionaries(List<string> filePaths, char delim, string assemblyName)
{
    var listOfStringDictionaries = new List<Dictionary<string, string>>();
    var fileAsDictionary 	     = new Dictionary<string, string>();
      
    foreach (var filePath in filePaths)
    {
        fileAsDictionary = ConvertExternalTextFileToStringDictionary() // See above   
        listOfStringDictionaries.Add(fileAsDictionary(filePath, delimiter));
    }

    return listOfStringDictionaries;
}

// Convert embedded text files to a List<Dictionary<string, string>>.
public static List<Dictionary<string, string>> ConvertEmbeddedTextFilesToListOfStringDictionaries(List<string> filePaths, char delim, string assemblyName)
{
    var listOfStringDictionaries = new List<Dictionary<string, string>>();
    var fileAsDictionary 	     = new Dictionary<string, string>();
  
    foreach (var filePath in filePaths)
    {
        fileAsDictionary = ConvertExternalTextFileToStringDictionary() // See above  
        listOfStringDictionaries.Add(fileAsDictionary(filePath, delimiter, assemblyName));
    }

    return listOfStringDictionaries;
}

// Convert a text file to a List<string> - apparently doesn't matter if external or embedded?
private static List<string> Read(StreamReader filePath)
{
    var fileAsList = new List<string>();
    var fileLine = string.Empty;

    while ((fileLine = filePath.ReadLine()) != null)
    {
        fileAsList.Add(fileLine);
    }

    return fileAsList;
}

// Convert an external text file to a List<string>.
public static List<string> ConvertExternalTextFileToStringList(string filePath)
{
  	return File.ReadAllLines(filePath).ToList();
}

// Convert an embedded text file to a List<string>.
private static List<string> ConvertEmbeddedTextFileToStringList(string filePath, string assembly)
{
    var fileAsList = new List<string>();
    var fullPath   = assembly + "." + filePath;

    using (StreamReader fileToRead = new StreamReader(Assembly.Load(assembly).GetManifestResourceStream((string)fullPath)))
        fileAsList = Read(fileToRead);

    return fileAsList;
}

// Convert an external text file to a string[]
public static string[] ConvertExternalTextFileToStringArray(string filePath)
{
    return File.ReadAllLines(filePath).ToList().ToArray();
}

// Convert an embedded text file to a string[]
public static string[] ConvertEmbeddedTextFileToStringArray(string filePath, string assembly)
{
    var fileAsList = new List<string>();
    var fullPath   = assembly + "." + filePath;

    using (StreamReader fileToRead = new StreamReader(Assembly.Load(assembly).GetManifestResourceStream((string)fullPath)))
        fileAsList = Read(fileToRead);

    return fileAsList.ToArray();
}