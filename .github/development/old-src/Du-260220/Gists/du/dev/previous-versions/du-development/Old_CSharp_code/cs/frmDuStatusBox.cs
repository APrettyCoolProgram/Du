#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: frmDuStatusBox.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
/*  A simple form that displays status text. Generally you want to use the Build() method to build the initial form,
 *  then the other methods to modify the form.
 */
#endregion

#region USING
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Du
{
    public partial class frmDuStatusBox : Form
    {
        /// <summary>Entry point.</summary>
        public frmDuStatusBox()
        {
            InitializeComponent();
        }

        public string ActionButtonText   { get; set; }
        public bool   ActionButtonStatus { get; set; }
        public string HeaderText         { get; set; }
        public string StatusText         { get; set; }
        public Color  BorderColor        { get; set; }
        public Color  BackgroundColor    { get; set; }

        /// <summary>Set the StatusBox header.</summary>
        /// <param name="header">The header to display.</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void SetHeader(string header)
        {
            lblHeader.Text = header;
        }

        /// <summary>Set the StatusBox status.</summary>
        /// <param name="initialMsg">The message to display.</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void SetStatus(string initialMsg)
        {
            lblStatus.Text = initialMsg;
        }

        /// <summary>Set the StatusBox button to visible or not.</summary>
        /// <param name="isVisible">The visiblity status [true/false]</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void ButtonVisible(bool isVisible)
        {
            btnAction.Visible = isVisible;
        }

        /// <summary>Set the StatusBox button to enabled or disabled.</summary>
        /// <param name="isEnabled">The enabled status [true/false]</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void ButtonEnabled(bool isEnabled)
        {
            btnAction.Enabled = isEnabled;
        }

        /// <summary>Set the StatusBox button to enabled or disabled.</summary>
        /// <param name="color">The color </param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void ButtonForeground(Color color)
        {
            btnAction.ForeColor = color;
        }

        /// <summary>Set the StatusBox button to enabled or disabled.</summary>
        /// <param name="color">The color </param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void ButtonBackground(Color color)
        {
            btnAction.BackColor = color;
        }

        /// <summary>Sets the action button text.</summary>
        /// <param name="text">The text to put on the button.</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void ButtonText(string text)
        {
            btnAction.Text = text;
        }

        /// <summary>Dispose the form when the button is clicked.</summary>
        /// <remarks></remarks>
        /// <build>180225</build>
        private void btnAction_Click(object    sender,
                                     EventArgs e)
        {
            Dispose();
        }

        /// <summary>Change the border color.</summary>
        /// <param name="text">The text to put on the button.</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void SetBorder(Color color)
        {
            BackColor = color;
        }

        /// <summary>Change the background color.</summary>
        /// <param name="text">The text to put on the button.</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public void SetBackground(Color color)
        {
            pnlContainer.BackColor = color;
        }
    }
}