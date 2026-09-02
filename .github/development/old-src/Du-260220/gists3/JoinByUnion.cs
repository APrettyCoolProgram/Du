// Join multiple string[] via union.
public static string[] JoinByUnion(List<string[]> arraysToJoin)
{
	var joinedArray = new string[0];

	foreach (var distinctArray in arraysToJoin)
	{
		Array.Resize(ref joinedArray, distinctArray.Length);
		joinedArray = joinedArray.Union(distinctArray).ToArray();
	}

	return joinedArray;
}