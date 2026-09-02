public static string[] Resize(string[] arrayToResize, int newSize)
{
    Array.Resize(ref arrayToResize, newSize);
    return arrayToResize;
}