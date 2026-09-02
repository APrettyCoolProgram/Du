// ===========================================================================================================  1:13 PM
//    FILENAME: DuImage.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for images.
 */
using System.Windows.Controls;

namespace Du
{
    public class DuImage
    {
        public static Image FromResource(string imagePath)
        {
            return new Image
            {
                Source = DuBitmap.FromUri(imagePath)
            };
        }
    }
}