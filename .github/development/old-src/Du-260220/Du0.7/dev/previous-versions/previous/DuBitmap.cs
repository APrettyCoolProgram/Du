// ===========================================================================================================  1:14 PM
//    FILENAME: DuBitmap.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for bitmaps.
 */
using System;
using System.Windows.Media.Imaging;

namespace Du
{
    public class DuBitmap
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static BitmapImage FromUri(string imagePath)
        {
            /* In order for this to work, your image has to be a Resource.
             */
            return new BitmapImage(new Uri("pack://application:,,,/Avatool;component/" + imagePath));
        }
    }
}