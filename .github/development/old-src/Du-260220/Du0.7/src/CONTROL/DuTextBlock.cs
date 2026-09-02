// =====================================================================================================================
//    FILE: Du.DuTextBlock.cs
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
    /// <summary>Does things with WPF TextBox controls.</summary>
    public class DuTextBlock
    {
        private static readonly Action EmptyDelegate = delegate { };

        /// <summary>Refresh the content of a TextBlock control.</summary>
        /// <param name="textBlockToRefresh">The TextBlock control to refresh.</param>
        public static void RefreshContent(TextBlock textBlockToRefresh)
        {
            _ = textBlockToRefresh.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
