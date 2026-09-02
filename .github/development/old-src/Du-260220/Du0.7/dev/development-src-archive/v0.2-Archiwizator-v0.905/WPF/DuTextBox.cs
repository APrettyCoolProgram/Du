/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuTextBox.cs
 * UPDATED: 12-31-2020-1:22 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Windows.Controls;

namespace Du
{
    /// <summary>Does various things with WPF TextBox controls.</summary>
    public class DuTextBox
    {
        /// <summary>Saves the text of a TextBox, then clears the TextBox.</summary>
        /// <param name="theTextBox">The TextBox.</param>
        public static void SaveTextAndClear(TextBox theTextBox)
        {
            theTextBox.Tag = theTextBox.Text;
            theTextBox.Text = "";
        }
    }
}