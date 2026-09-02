// =====================================================================================================================
//    FILE: Du.DuFont.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-26-2021-3:22 PM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

using System;
using System.Windows.Media;

namespace Du
{
    public class DuFont
    {
        /// <summary>
        /// Load a font so it can be used in an application
        /// </summary>
        /// <param name="fontFullName">The full name of the font (e.g., "Times New Roman Bold")</param>
        /// <remarks>
        /// For this to work:
        ///  1. Place a "font.tff" file in a folder that's part of your solution (e.g., "/resources/fonts/font.tff")
        ///  2. The properties of the file should be "Content" and "Copy always"
        ///  3. In your code, pass both the full name of the font, and its location:
        ///     <example>
        ///         myLabel.FontFamily = DuFont.Load("./Resources/Fonts/", "Times New Roman Bold");
        ///     </example>
        /// </remarks>
        /// <returns>A font family</returns>
        public static FontFamily Load(string fontLocation, string fontFullName)
        {
            return new FontFamily(new Uri("pack://application:,,,/"), $"{fontLocation}#{fontFullName}");
        }
    }
}
