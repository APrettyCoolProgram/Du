// =====================================================================================================================
//    FILE: Du.DuLabel.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 3-30-2021-9:58 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

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