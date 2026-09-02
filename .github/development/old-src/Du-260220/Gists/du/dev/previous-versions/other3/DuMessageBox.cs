#region PROJECT_HEADER
//   PROJECT: myAvimport
//  FILENAME: DuMessageBox.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/myAvimport
#endregion

#region USING
using System.Windows.Forms;
#endregion

namespace Du
{
    public class DuMessageBox
    {

        /// <summary>Displays a standard MessageBox control with an "OK" button.</summary>
        /// <param name="msgHeader"></param>
        /// <param name="msgBody"></param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static void Display(string msgHeader, string msgBody)
        {
            MessageBox.Show(msgHeader, msgBody);
        }
    }
}