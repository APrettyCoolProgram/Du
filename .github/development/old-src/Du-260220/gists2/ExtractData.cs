// Extract file data into a List<string>.
public static List<string> ExtractFileDataToStringList(string filePath, string startFlag, string endFlag)
{
    var extractedData = new List<string>();
    var recording     = false;
    var fileLines     = File.ReadAllLines(filePath).ToList();

    foreach (var fileLine in fileLines)
    {
        if (fileLine.StartsWith(startFlag))
        {
            recording = true;
            continue;
        }

        if ((recording) && (fileLine.StartsWith(endFlag)))
            break;

        if ((recording) && (fileLine != string.Empty))
            extractedData.Add(fileLine);
    }

    return extractedData;
}