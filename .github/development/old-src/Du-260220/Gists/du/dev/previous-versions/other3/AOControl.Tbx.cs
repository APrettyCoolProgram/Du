/* A nested class for AOControl.cs that does various things with textbox controls.
 * v00.53.02.161218
 * http://aprettycoolprogram.com/ao
 */

using System.Drawing;
using System.Windows.Forms;

namespace AO
{
    partial class AOControl
    {
        /// <summary>
        /// Does various things with textboxes.
        /// </summary>
        public class Tbx
        {
            /// <summary>
            /// Create a single button control.
            /// </summary>
            /// <param name="textboxName"> DETAILS HERE. </param>
            /// <param name="height"> DETAILS HERE. </param>
            /// <param name="width"> DETAILS HERE. </param>
            /// <param name="yPos"> DETAILS HERE. </param>
            /// <param name="xPos"> DETAILS HERE. </param>
            /// <param name="border"> DETAILS HERE. </param>
            /// <returns> DETAILS HERE. </returns>
            public static TextBox Create(string textboxName, int height, int width, int yPos, int xPos, string border)
            {
                TextBox wrkTextBox  = new TextBox();
                wrkTextBox.Name     = textboxName;
                wrkTextBox.Height   = height;
                wrkTextBox.Width    = width;
                wrkTextBox.Location = new Point(xPos, yPos);

                switch (border)
                {
                    default:
                        break;
                }

                return wrkTextBox;
            }
        }
    }
}