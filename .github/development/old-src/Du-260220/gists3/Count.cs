// Count the number of lines in a file.
public static int CountLines(StreamReader filePath)
{
    return ToList(filePath).Count;
}

// Count the number of empty lines
public static int CountEmptyLines(StreamReader filePath)
{
    var lineEmptyCount = 0;

    foreach (var line in File.ReadAllLines(filePath).ToList())
    {
        if (string.IsNullOrWhitespace(line))
            lineEmptyCount++;
    }

    return lineEmptyCount;
}

// Count the number of lines that start with a specific character.
public static int CountLinesThatStartWith(StreamReader filePath, char character)
{
    var lines     = File.ReadAllLines(filePath).ToList();
    var lineCount = 0;

    foreach (var line in File.ReadAllLines(filePath).ToList())
        if (string.StartsWith(character))
            lineCount++;

    return lineCount;
}