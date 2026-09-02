// Convert a string[] to a string, no spacing or seperation.
public static string StringArrayToString(string[] stringArray)
{
    var arrayAsString = "";

    foreach (var element in stringArray)
      	arrayAsString += element;

    return arrayAsString;
}

// Convert a string[] to a string, seperate each element with a delimiter.
public static string StringArrayToStringElementsSeperatedByDelimiter(string[] stringArray, char delimiter)
{
    var arrayAsString = "";

    foreach (var element in stringArray)
      	arrayAsString += element + delimiter;

    return arrayAsString;
}

// Convert a string[] to a string, put a space between each element
public static string StringArrayToStringElementsSeperatedBySpaces(string[] stringArray)
{
    var arrayAsString = "";

    foreach (var element in stringArray)
      	arrayAsString += element + " ";

    return arrayAsString;
}

// Convert a string[] to a string, each element on its own line.
public static string StringArrayToStringElementsSeperatedByNewlines(string[] stringArray)
{
    var arrayAsString = "";

    foreach (var element in stringArray)
      	arrayAsString += element + Environment.NewLine;

    return arrayAsString;
}