// Join multiple string[] via concatenation.
public static string[] JoinByConcat(List<string[]> arraysToJoin)
{
	var joinedArray = new string[0];

	foreach (var distinctArray in arraysToJoin)
	{
		Array.Resize(ref joinedArray, distinctArray.Length);
		joinedArray = joinedArray.Concat(distinctArray).ToArray();
	}

	return joinedArray;
}