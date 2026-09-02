/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuBitmap.cs
 * UPDATED: 1-27-2021-8:27 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System;
using System.Windows.Media.Imaging;

namespace Du
{
    /// <summary>Does various things with Bitmap images.</summary>
    public class DuBitmap
    {
        /// <summary>Loads a bitmap image frrom a resource URI.</summary>
        /// <param name="assemblyName">The assembly name of the application.</param>
        /// <param name="imagePath">   The path to the image.</param>
        /// <returns>A bitmap image.</returns>
        /// <remarks>In order for this to work, your image has to be Content &gt; Copy Always.</remarks>
        public static BitmapImage FromUri(string assemblyName, string imagePath)
        {
            return new BitmapImage(new Uri($"pack://application:,,,/{assemblyName};component/{imagePath}"));
        }
    }
}