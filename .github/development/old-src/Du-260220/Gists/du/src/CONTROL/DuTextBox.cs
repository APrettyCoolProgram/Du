// =====================================================================================================================
//    FILE: Du.DuTextBox.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 3-30-2021-9:59 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

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