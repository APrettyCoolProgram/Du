/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuTextBox.cs
 * UPDATED: 12-29-2020-4:52 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Windows.Controls;

namespace Du
{
    public class DuTextBox
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txbx"></param>
        /// <param name="isEnabled"></param>
        public static void SetIsEnabled(TextBox txbx, bool isEnabled)
        {
            txbx.IsEnabled = isEnabled;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txbx"></param>
        public static void SaveTextAndClear(TextBox txbx)
        {
            txbx.Tag = txbx.Text;
            txbx.Text = "";
        }
    }
}
