// Remove elements in a string[] that are null, whitespace, or blank. 
public static string[] RemoveNullsOrWhitespaceElements(string[] arrayToRemoveFrom)
{
	var workingList = new List<string>();

	foreach (var element in arrayToRemoveFrom)
	{
		if (element != null)
			workingList.Add(element);
	}

	return workingList.ToArray();
}