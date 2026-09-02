// ===========================================================================================================  9:10 AM
//    FILENAME: Du.cs
//       BUILD: 20190916
//     PROJECT: Avatool (https://github.com/APrettyCoolProgram/Avatool)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Du is a collection of common methods for C# .NET WPF solutions. Du consists of the following classes:
 *
 *  - Du            Testing, development, and examples
 *  - DuDir         Directories
 *  - DuDownload    A WPF window for downloading data from the internet
 *  - DuFile        Files
 *  - DuJson        JSON data
 *  - DuLog         Logfiles
 *  - DuPopup       A WPF popup window
 *  - DuSplash      A WPF splash screen
 */
using System.Windows;
using System.Windows.Media;

namespace Thaumaturge.Du
{
    public class Du
    {
        public static void DuTest()
        {
            ExamplePopupStandard();
            ExamplePopupFancy();
            ExamplePopupErrorMessage();
        }

        #region DuPopup Examples
        /* DuPopup has the following built-in layouts:
         *
         *  - ErrorMessage : A simple error message with an "OK" button.
         *
         * You can create an instance of the built-in layouts with the following code:
         *
         *  DuPopup.ErrorMessage("Your title text", "Your message Text")
         *
         * You can also create custom DuPopup windows by using the following code:
         *
         *  var startScreen = new DuPopup
         *  {
         *      ContentTitleText         = "Welcome to the app!",
         *      MessageBodyText          = "I hope you have fun! Press "Continue" when you are ready!",
         *      ActionButton02Visibility = Visibility.Visible,
         *      ActionButton02Content    = "Continue",
         *  };
         *  startScreen.ShowDialog();
         *
         * That will create the simplest DuPopup window. You can make more complex DuPopups by adding additional
         * properties (see the "PopupFancy()" method below).
         * Keep in mind that DuPopup needs at least one ActionButton with a valid action as it's
         * context (i.e. "OK", "Exit").
         */
        public static void ExamplePopupStandard()
        {
            var messagePopupTest = new DuPopup
            {
                PopupTitle = "Welcome",
                ContentTitleText = "Welcome to The Application",
                ContentBodyText = "We hope you enjoy using The Application. Have a nice day!",
                ActionButton01Visibility = Visibility.Visible,
                ActionButton01Content = "OK",
            };
            messagePopupTest.ShowDialog();
        }

        /* There are a number of other properties you can set when you create a DuPopup window, but:
         *
         *  - The minimum height is 300, and the minimum width is 500. DuPopup windows smaller than this will not
         *    display correctly.
         */
        public static void ExamplePopupFancy()
        {
            var messagePopupTest = new DuPopup
            {
                PopupHeight = 800,
                PopupWidth = 800,
                PopupTitle = "Welcome",
                OuterBorderBackground = new SolidColorBrush(Colors.CadetBlue),
                InnerBorderBackground = new SolidColorBrush(Colors.Azure),
                ContentTitleText = "Welcome to The Application",
                ContentTitleForeground = new SolidColorBrush(Colors.Chocolate),
                ContentBodyText = "This is the Fancy Popup example.\n\nWe hope you enjoy using The Application. Have a nice day!",
                ContentBodyForeground = new SolidColorBrush(Colors.Purple),
                ActionButton01Visibility = Visibility.Visible,
                ActionButton01Content = "Exit",
                ActionButton01Background = new SolidColorBrush(Colors.GhostWhite),
                ActionButton01Foreground = new SolidColorBrush(Colors.Red),
                ActionButton02Visibility = Visibility.Visible,
                ActionButton02Content = "Continue",
                ActionButton02Background = new SolidColorBrush(Colors.LightGreen),
                ActionButton02Foreground = new SolidColorBrush(Colors.Green),
                ActionButton03Visibility = Visibility.Hidden,
                ActionButton03Content = "",
                ActionButton03Background = new SolidColorBrush(Colors.Aqua),
                ActionButton03Foreground = new SolidColorBrush(Colors.Navy)
            };
            messagePopupTest.ShowDialog();
        }

        /// <summary>
        ///
        /// </summary>
        public static void ExamplePopupErrorMessage()
        {
            DuPopup.ErrorMessage("This application has encountered an error", "The source file cannot be found.");
        }
        #endregion DuPopup Examples
    }
}