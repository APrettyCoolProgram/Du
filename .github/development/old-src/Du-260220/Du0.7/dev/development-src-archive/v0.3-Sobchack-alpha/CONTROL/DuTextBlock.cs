/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuTextBlock.cs
 * UPDATED: 1-27-2021-8:24 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

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
