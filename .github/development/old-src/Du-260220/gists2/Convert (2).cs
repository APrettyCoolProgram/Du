// Convert a string[] to a string, without spacing or seperation.
public static string ConvertStringArrayToString(string[] stringArray)
{
    var arrayAsString = "";
    
    foreach (var element in stringArray)
      arrayAsString += element;

    return arrayAsString;
}

// Convert a string[] to a string, and seperate each element with a delimiter
public static string ConvertStringArrayToStringAndSeperateElementsWithDelimiter(string[] stringArray, char delimiter)
{
    var arrayAsString = "";
    
    foreach (var element in stringArray)
      arrayAsString += element + delimiter;

    return arrayAsString;
}

// Convert a string[] to a string, and put a space between each element.
public static string ConvertStringArrayToStringAndSeperateElementsWithSpaces(string[] stringArray)
{
    var arrayAsString = "";
    
    foreach (var element in stringArray)
      arrayAsString += element + " ";

    return arrayAsString;
}

// Convert a string[] to a string, and put each element on its own line.
public static string ConvertStringArrayToStringWithElementsOnSeperateLines(string[] stringArray)
{
    var arrayAsString = "";
    
    foreach (var element in stringArray)
      arrayAsString += element + Environment.NewLine;

    return arrayAsString;
}
