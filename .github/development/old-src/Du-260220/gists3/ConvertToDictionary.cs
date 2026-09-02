// Convert a string[] to a Dictionary<string, string>.
public static Dictionary<string, string> StringArrayToStringDictionary(string[] arrayToConvert, char delimiter)
{
  	var keyValuePair        = new string[1];
  	var convertedDictionary = new Dictionary<string, string>();
  
  	foreach (var element in arrayToConvert)
  	{
    	keyValuePair = element.Split(delimiter);
    	convertedDictionary.Add(keyValuePair[0], keyValuePair[1]);
  	}
  
  	return convertedDictionary;
}