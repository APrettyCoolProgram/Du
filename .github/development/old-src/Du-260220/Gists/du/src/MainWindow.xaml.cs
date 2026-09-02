// =====================================================================================================================
//    FILE: Du.MainWindow.xaml.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-24-2021-2:04 PM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

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