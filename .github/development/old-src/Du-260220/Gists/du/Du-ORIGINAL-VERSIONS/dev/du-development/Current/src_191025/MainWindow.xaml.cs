// ===========================================================================================================  11:20 AM
//    FILENAME: MainWindow.xaml.cs
//       BUILD: 191023
//     PROJECT: Du (https://github.com/GitHubAccount/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License 2.0
// ====================================================================================================================

/* This is the main window/code of the project.
 */
using System.Windows;

namespace Du
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DevMode.LaunchThenQuit(false);
            DevMode.Testing(false);
            Setup();
            Start();
        }

        /// <summary>
        /// Applies customizations to the Main() window when the application launches.
        /// </summary>
        private void Setup()
        {
            SetupControls();
            SetupWindow();
        }

        /// <summary>
        ///
        /// </summary>
        private void SetupControls()
        {
            /* Any control customizations go here.
             */
        }

        /// <summary>
        /// Applies customizations to the Main() window when the application launches.
        /// </summary>
        private void SetupWindow()
        {
            /* Any window customizations go here.
             */
        }

        /// <summary>
        /// Initializes a project.
        /// </summary>
        private void Start()
        {
            Examples();
        }
    }
}