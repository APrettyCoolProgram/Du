/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuTextBox.cs
 * UPDATED: 1-27-2021-8:24 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Du
{
    /// <summary>Does various things with WPF TextBox controls.</summary>
    public class DuTextBox
    {
        private static readonly Action EmptyDelegate = delegate { };

        /// <summary>Refresh the content of a TextBox controls.</summary>
        /// <param name="textBoxToRefresh">The TextBox control to refresh.</param>
        public static void RefreshContent(TextBox textBoxToRefresh)
        {
            _ = textBoxToRefresh.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }


        /// <summary>Saves the text of a TextBox, then clears the TextBox.</summary>
        /// <param name="theTextBox">The TextBox.</param>
        public static void SaveTextAndClear(TextBox theTextBox)
        {
            theTextBox.Tag = theTextBox.Text;
            theTextBox.Text = "";
        }
    }
}