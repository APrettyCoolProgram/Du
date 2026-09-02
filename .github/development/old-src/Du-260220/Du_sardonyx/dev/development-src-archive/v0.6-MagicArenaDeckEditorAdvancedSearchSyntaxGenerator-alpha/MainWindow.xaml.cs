/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.MainWindow.xaml.cs
 * UPDATED: 1-27-2021-8:33 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Windows;

namespace Du
{
    /// <summary></summary>
    public partial class MainWindow : Window
    {
        /// <summary>Default constructor.</summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTestPing_Click(object sender, RouteDeventArgs e)
        {
            System.Tuple<int, int> result = DuOperatingSystem.MSWindows.PingIpAddress("google.com", 10);

            txbkTestResults.Text = "estc";
        }
    }
}