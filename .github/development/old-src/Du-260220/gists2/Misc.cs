/// <summary>Gets the next number in an extension range.</summary>
/// <param name="directoryName">Directory to look at.</param>
/// <param name="filePattern">The file name base to match.</param>
/// <param name="startAt">What to start at.</param>
/// <returns>A number for the next extension.</returns>
/// <remarks>
/// This is used when files in a directory have numeric extensions (i.e. "file.1", "file.2"...), and you want to
/// find the next number (i.e. "file.3").
/// </remarks>
public static string GetNextExtNum(string directoryName, string filePattern, int startAt)
{
  var nextNum = startAt;

  foreach (var fName in Directory.GetFiles(directoryName))
  {
    if (Path.GetFileNameWithoutExtension(fName) == filePattern)
    {
      if (int.Parse(Path.GetFileNameWithoutExtension(fName)) > nextNum)
      {
        nextNum = int.Parse(Path.GetFileNameWithoutExtension(fName));
      }
    }
  }
  nextNum++; // Need this to work correctly.

  return nextNum.ToString();
}