// Convert a List<string> to a string.
public static string ToString(List<string> listToConvert)
{
    var listAsString = "";

    foreach (var line in listToConvert)
        listAsString += line + Environment.NewLine;

    return listAsString;
}