/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuFolderDialog.cs
 * UPDATED: 12-31-2020-1:26 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using Ookii.Dialogs.Wpf;

namespace Du
{
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