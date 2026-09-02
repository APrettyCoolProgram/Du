// Count the number of elements in a string[].
public static int CountElementsInArray(string[] arrayToCount)
{
    var totalCharacters = 0;

    foreach (var element in arrayToCount)
      	totalCharacters += element.Length;

    return totalCharacters;
}