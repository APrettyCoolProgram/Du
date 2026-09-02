using System;
using System.Windows.Media.Imaging;

/// <summary>
/// Loads a bitmap image from a resource URI.
/// </summary>
/// <param name="assemblyName">The assembly name of the application.</param>
/// <param name="imagePath">   The path to the image.</param>
/// <example>
/// <code>
/// imgControl.Source = DuBitmap.FromUri(%assemblyName%, %resourcePath%);
/// </code>
/// </example>
/// <remarks>
/// - To get the assemblyName:
/// <code>
/// Assembly.GetEntryAssembly().GetName().Name
/// </code>
/// - The imagePath should look like this: "relative/path/to/the/%imageFile%"
/// - The image must have the following properties:
///     - "Build Action: Content"
///     - "Copy to Output Directory: Copied always"
/// </remarks>
/// <returns> A bitmap image to be used Image control .Source property.</returns>
public static BitmapImage FromUri(string entryAssemblyName, string imagePath)
{
    return new BitmapImage(new Uri($"pack://application:,,,/{entryAssemblyName};component/{imagePath}"));
}