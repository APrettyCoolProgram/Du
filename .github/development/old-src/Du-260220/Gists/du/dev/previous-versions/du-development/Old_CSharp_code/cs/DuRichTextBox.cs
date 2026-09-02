#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuRichTextBox.cs
//   VERSION: 0.6.1-beta
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Du
{
    public class DuRichTextBox
    {
        /// <summary>Appends text to a RichTextBox.</summary>
        /// <param name="rtb"></param>
        /// <param name="text"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        /// <param name="addNewLine"></param>
        /// <remarks></remarks>
        /// <build>180227</build>
        public static void Append(RichTextBox rtb, string text, Color foreColor, Color backColor, bool addNewLine)
        {
            if (addNewLine)
            {
                text += Environment.NewLine;
            }

            rtb.SelectionStart  = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor     = foreColor;
            rtb.SelectionBackColor = backColor;
            rtb.AppendText(text);
        }
    }
}