/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuLabel.cs
 * UPDATED: 1-27-2021-8:24 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Du
{
    /// <summary>Does things with WPF Label controls.</summary>
    public class DuLabel
    {
        private static readonly Action EmptyDelegate = delegate { };

        /// <summary>Refresh the content of a Lable control.</summary>
        /// <param name="labelToRefresh">The Label control to refresh.</param>
        public static void RefreshContent(Label labelToRefresh)
        {
            _ = labelToRefresh.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}