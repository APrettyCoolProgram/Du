#region PROJECT_HEADER
//   PROJECT: myAvatool
//  FILENAME: DuInputBox.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/myAvatool
#endregion

#region CLASS_DESCRIPTION
// Displays a popup that requests user input.
#endregion

using System;
using System.Windows.Forms;

namespace Du
{
    /// <summary>Entry point.</summary>
    public partial class frmDuInputBox : Form
    {
        public frmDuInputBox()
        {
            InitializeComponent();
        }

        /// <summary>Initialize the popup with the provided messages.</summary>
        /// <param name="whatever"></param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public frmDuInputBox(string whatever)
        {
            InitializeComponent();
            lblMessage.Text = whatever;
        }

        /// <summary>User clicks the OK button.</summary>
        /// <remarks></remarks>
        /// <build>180225</build>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Tag = tbxUserResponse.Text;
            Hide();
        }

        /// <summary>User clicks the Cancel button.</summary>
        /// <remarks></remarks>
        /// <build>180225</build>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>The text in the tbxUserInput control is changed.</summary>
        /// <remarks>Whenever the user modifies the contents of the response control, check to see if the control is
        /// empty. If the control is empty, disable the "OK" button.</remarks>
        /// <build>180225</build>
        private void tbxUserResponse_TextChanged(object sender, EventArgs e)
        {
            /*  
             */
            btnOK.Enabled = tbxUserResponse.Text != string.Empty;
        }
    }
}