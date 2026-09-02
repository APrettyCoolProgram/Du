// Verifies that a string ends with a specific character. [b201215]
public static bool EndsWithTrailingCharacter(string workString, char trailingCharacter)
{
    return workString.EndsWith(trailingCharacter);
}

// Get the number of characters in a string. [b201215]
public static int GetNumberOfCharacters(string workString)
{
     return workString.Length;
}

// Get the number of lines in a string. [b201215]
public static int GetNumberOfLines(string workString)
{
    return workString.Split(Environment.NewLine).Length;
}

// Check to see if a line begins with a specific character. [b201215]
public static bool StartsWithCharacter(string workString, char commentChar)
{
    return workString.StartsWith(commentChar.ToString())
}

// Check to see if a line is empty. [b201215]
public static bool IsEmpty(string workString)
{
    return workString.Empty;
}

// Replace part of a string with a string. [b201215]
public static string ReplaceThisWithThis(string workString, string replaceThis, string withThis)
{
    return workString.Replace(replaceThis, withThis);
}

// Convert a string to an array, splitting at a specific delimiter. [b201215]
public static string[] AsArrayAtDelimiter(string workString, char delimiter)
{
    return workString.Split(delimiter);
}

// Convert a string to an array, splitting at newlines. [b201215]
public static string[] AsArrayAtNewLine(string workString)
{
    return workString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
}

// Convert a string to an List<string>, splitting at a specific delimiter. [b201215]
public static List<string> ToListAtDelimiter(string workString, char delimiter)
{
    return workString.Split(delimiter).ToList();
}

// Convert a string to an List<string>, splitting at newlines. [b201215]
public static List<string> ToListAtNewLine(string workString)
{
    return workString.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
}


