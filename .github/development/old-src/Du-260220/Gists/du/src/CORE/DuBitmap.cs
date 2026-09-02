/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuBitmap.cs
 * UPDATED: 6-23-2021-11:42 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System;
using System.Windows.Media.Imaging;

namespace Du
{
    public class DuBitmap
    {
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
        /// - You can get the assemblyName by using Du.GetAssemblyName()
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
    }
}