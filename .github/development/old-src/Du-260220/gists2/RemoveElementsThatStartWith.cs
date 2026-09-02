// Remove elements that start with a specific character.
public static string[] RemoveElementsThatStartWith(string[] arrayToRemoveFrom, char startingCharacter)
{
	var workingList = new List<string>();

	foreach (var element in arrayToRemoveFrom)
	{
		if (!element.StartsWith(startingCharacter))
			workingList.Add(element);
	}

	return workingList.ToArray();
}