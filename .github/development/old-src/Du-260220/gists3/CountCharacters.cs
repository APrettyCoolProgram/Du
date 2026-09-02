// Count the number of characters in a string[].
public static int CountCharactersInArray(string[] arrayToCount)
{
    var totalCharacters = 0;

    foreach (var element in arrayToCount)
      	totalCharacters += element.Length;

    return totalCharacters;
}