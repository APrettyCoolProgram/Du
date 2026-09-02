// ====================================================================================================================
//    FILENAME: DuImage.cs
//       BUILD: 20190916
//     PROJECT: Du (https://github.com/GitHubAccount/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* DuImage utilities.
 */
using System.Windows.Controls;

namespace Avatool.Du
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