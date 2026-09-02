// =====================================================================================================================
//    FILE: Du.DuMsgBox.xaml.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-24-2021-2:03 PM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

/* This isn't being currently developed, but I'm leaving it since it probably will have a use at some point.
 */

using System;
using System.Windows;
using System.Windows.Controls;

namespace Du
{
    public partial class MsgBox : Window
    {
        // PROPERTIES
        public int BoxHeight { get; set; }
        public int BoxWidth { get; set; }
        public string BoxTitleBar { get; set; }
        public string MsgTitle { get; set; }
        public string MsgBody { get; set; }
        public MsgBoxButton Button1 { get; set; }
        public MsgBoxButton Button2 { get; set; }
        public MsgBoxButton Button3 { get; set; }

        public class MsgBoxButton
        {
            public bool Visible { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
            public string Function { get; set; }
        }

        // EVENT HANDLERS
        private void btnBoxButton1_Click(object sender, RoutedEventArgs e)
        {
            ButtonFunctions(sender);
        }

        private void btnBoxButton2_Click(object sender, RoutedEventArgs e)
        {
            ButtonFunctions(sender);
        }

        private void btnBoxButton3_Click(object sender, RoutedEventArgs e)
        {
            ButtonFunctions(sender);
        }


        // DEFAULT CONSTRUCTOR
        public MsgBox()
        {
            InitializeComponent();
        }

        /// <summary>Creates and displays a message box.</summary>
        /// <param name="msgBox">The MsgBox object.</param>
        /// <remarks>Creates an displays a message box. See EOF comments for more information.</remarks>
        public MsgBox(MsgBox msgBox)
        {
            InitializeComponent();

            SetBoxWidth(msgBox);
            SetBoxHeight(msgBox);
            SetBoxTitleBar(msgBox);

            SetMsgTitle(msgBox);
            SetMsgBody(msgBox);

            SetButton(msgBox.Button1, btnBoxButton1);
            SetButton(msgBox.Button2, btnBoxButton2);
            SetButton(msgBox.Button3, btnBoxButton3);
        }

        /// <summary>Set the message box height.</summary>
        /// <param name="msgBox">The MsgBox object.</param>
        /// <remarks>This forces the box height to be between 250px. and 500px.</remarks>
        private void SetBoxHeight(MsgBox msgBox)
        {
            Height = msgBox.BoxHeight switch
            {
                < 250 => 250,
                > 500 => 500,
                _ => msgBox.BoxHeight,
            };
        }

        /// <summary>Set the message box width.</summary>
        /// <param name="msgBox">The MsgBox object.</param>
        /// <remarks>This forces the box width to be between 350px. and 600px.</remarks>
        private void SetBoxWidth(MsgBox msgBox)
        {
            Width = msgBox.BoxWidth switch
            {
                < 350 => 350,
                > 600 => 600,
                _ => msgBox.BoxWidth,
            };
        }

        /// <summary>Set the message box title bar text.</summary>
        /// <param name="msgBox">The MsgBox object.</param>
        /// <remarks>If the title bar text is empty, the title bar is removed.</remarks>
        private void SetBoxTitleBar(MsgBox msgBox)
        {
            if(msgBox.BoxTitleBar == "")
            {
                WindowStyle = WindowStyle.None;
            }
            else
            {
                Title = msgBox.BoxTitleBar;
            }
        }

        /// <summary>Set the message title.</summary>
        /// <param name="msgBox">The MsgBox object.</param>
        /// <remarks>If the message title is empty, set a generic title.</remarks>
        private void SetMsgTitle(MsgBox msgBox)
        {
            lblMsgTitle.Content = msgBox.MsgTitle == ""
? "<missing message title>"
: msgBox.MsgTitle;
        }

        /// <summary>Set the message body.</summary>
        /// <param name="msgBox">The MsgBox object.</param>
        /// <remarks>If the message body is empty, set a generic title.</remarks>
        private void SetMsgBody(MsgBox msgBox)
        {
            lblMsgBody.Content = msgBox.MsgBody == ""
? "<missing message body>"
: msgBox.MsgBody;
        }

        /// <summary>Set a message box button.</summary>
        /// <param name="msgBoxButton">The button information.</param>
        /// <param name="button">The message box button control.</param>
        private void SetButton(MsgBoxButton msgBoxButton, Button button)
        {
            button.Name = msgBoxButton.Name;
            button.Visibility = msgBoxButton.Visible
                ? Visibility.Visible
                : Visibility.Hidden;
            button.Content = msgBoxButton.Content;
            button.Tag = msgBoxButton.Function;
        }

        /// <summary>Perform a button function.</summary>
        /// <param name="sender">The button that was clicked.</param>
        /// <remarks>If the button tag is empty, just continue the application.</remarks>
        private void ButtonFunctions(object sender)
        {
            var button = (Button)sender;
            var buttonFunction = (string)button.Tag;

            if(buttonFunction.Contains("ExitApp"))
            {
                Environment.Exit(0);
            }
            else
            {
                Close();
            }
        }


    }
}

/*  MsgBox(MsgBox msgBox)
 *  =====================
 *  To use MsgBox(MsgBox msgBox), you'll first need to create a MsgBox object with the specifications of the
 *  message box you are creating:
 *
 *      var msgBoxMissingConfigurationFile = new MsgBox()
 *      {
 *          BoxHeight          = 300,
 *          BoxWidth           = 600,
 *          BoxTitle           = "The message box title",
 *          BoxButton          = "Ok",
 *          MsgTitle           = "The message title",
 *          MsgBody            = "The message body",
 *          ExitOnConfirmation = true
 *      };
 *
 *
 *
 *
 *
 */
///
/// var msgBox = new MsgBox(msgBoxMissingConfigurationFile);
/// msgBox.ShowDialog();