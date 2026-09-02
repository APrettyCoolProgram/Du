/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuFolderDialog.cs
 * UPDATED: 12-28-2020-12:19 PM
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
            var folderPath = "";

            if(folderDialog.ShowDialog() == true)
            {
                folderPath = $"{folderDialog.SelectedPath}\\";
            }

            return folderPath;
        }
    }
}