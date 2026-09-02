// Extract data from a compressed file.
public static void ExtractCompressedData(string filePath, string destinationPath)
{
    ZipFile.ExtractToDirectory(filePath, destinationPath);
}