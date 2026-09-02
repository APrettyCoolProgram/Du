// Convert a string[] to a string[,].
public static string[,] StringArrayToMultiStringArray(string[] arrayToConvert, char delimiter, int numberOfElements)
{
    var currentRank   		= 0;
    var currentElement 		= 0;
    var convertedMultiArray = new string[arrayToConvert.Length, numberOfElements];
  
    string[] splitArray;

    foreach (var element in arrayToConvert)
    {
        splitArray = DoString.Split(element, delimiter);
        currentElement = 0;

        foreach (var item in splitArray)
        {
            convertedMultiArray[currentRank, currentElement] = item;
            currentElement++;
        }
        currentRank++;
    }

    return convertedMultiArray;
}
