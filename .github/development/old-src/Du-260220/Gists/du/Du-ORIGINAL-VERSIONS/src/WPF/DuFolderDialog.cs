// =====================================================================================================================
//    FILE: Du.DuFolderDialog.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-1-2021-11:20 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

using Ookii.Dialogs.Wpf;

namespace Du
{
    /// <summary>Methods for use with folder dialogs.</summary>
    public class DuFolderDialog
    {
        /// <summary>Prompts a user for a folder path.</summary>
        /// <returns>A folder path.</returns>
        /// <remarks>Uses Ookii.Dialogs.Wpf</remarks>
        public static string GetFolderPath()
        {
            var folderDialog = new VistaFolderBrowserDialog();

            return folderDialog.ShowDialog() is true
                ? $"{folderDialog.SelectedPath}\\"
                : "";
        }
    }
}