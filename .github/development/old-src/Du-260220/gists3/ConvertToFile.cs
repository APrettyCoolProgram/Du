// Convert a string[] to a text file.
public static void StringArrayToTextFile(string fileNameToWriteTo, string[] arrayToWrite)
{
    var contentToWrite = ContentAsString(arrayToWrite, true);

    File.WriteAllText(fileNameToWriteTo, contentToWrite);
}