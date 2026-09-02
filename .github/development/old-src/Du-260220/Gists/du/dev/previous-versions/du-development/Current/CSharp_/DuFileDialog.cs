// ====================================================================================================================
//    FILENAME: DuFileDialog.cs
//       BUILD: 20190916
//     PROJECT: Du (https://github.com/GitHubAccount/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* FileDialog utilities.
 */

using Thaumaturge.Du;

namespace Avatool.Du
{
    public class DuFileDialog
    {
        public static string CsvFile(string title = "Choose .csv file", string initialDirectory = @"C:\", string filter = "Excel files (*.csv)|*.csv|All files (*.*)|*.*")
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Title            = title,
                InitialDirectory = initialDirectory,
                Filter           = filter,
                FilterIndex      = 1
            };

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            else
            {
                DuPopup.ErrorMessage("ERROR LOADING FILE", "There was an error trying to load:\n\n" + openFileDialog.FileName);
                return "ERROR LOADING FILE - There was an error trying to load:\n\n" + openFileDialog.FileName;
            }
        }
    }
}