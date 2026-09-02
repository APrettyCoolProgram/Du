/* A nested class for AOControl.cs that does various things with button controls.
 * v00.53.02.161218
 * http://aprettycoolprogram.com/ao
 */

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AO
{
    partial class AOControl
    {
        /// <summary>
        /// Does various things with buttons.
        /// </summary>
        public class Btn
        {
            /// <summary>
            /// Creates an array of Button controls.
            /// </summary>
            /// <param name="buttonList"> DETAILS HERE. </param>
            /// <param name="xPos"> DETAILS HERE. </param>
            /// <param name="yPos"> DETAILS HERE. </param>
            /// <param name="xInc"> DETAILS HERE. </param>
            /// <param name="yInc"> DETAILS HERE. </param>
            /// <param name="ctrlPrefix"> DETAILS HERE. </param>
            /// <param name="mv"> DETAILS HERE. </param>
            /// <returns> DETAILS HERE. </returns>
            public static Button[] BuildArray(List<string> buttonList, int xPos, int yPos, int xInc, int yInc, string ctrlPrefix, string mv)
            {
                var element          = 0;
                var noSpacName       = string.Empty;
                Button[] buttonArray = new Button[buttonList.Count];

                foreach (var button in buttonList)
                {
                    noSpacName                    = AOString.Remove(button, "space", null);
                    buttonArray[element]          = new Button();
                    buttonArray[element].Text     = button;
                    buttonArray[element].Name     = ctrlPrefix + noSpacName;
                    buttonArray[element].Location = new Point(xPos, yPos);
                    element++;

                    if (mv == "vert")
                    {
                        yPos += yInc;
                    }
                    else if (mv == "horz")
                    {
                        xPos += yInc;
                    }
                }

                return buttonArray;
            }

            /// <summary>
            /// Create a single button control.
            /// </summary>
            /// <param name="buttonName"> DETAILS HERE. </param>
            /// <param name="buttonHeight"> DETAILS HERE. </param>
            /// <param name="buttonWidth"> DETAILS HERE. </param>
            /// <param name="yPos"> DETAILS HERE. </param>
            /// <param name="xPos"> DETAILS HERE. </param>
            /// <param name="border"> DETAILS HERE. </param>
            /// <returns> DETAILS HERE. </returns>
            public static Button Create(string buttonName, int buttonHeight, int buttonWidth, int yPos, int xPos, string border, string image, string backImage)
            {
                Button wrkButton   = new Button();
                wrkButton.Name     = buttonName;
                wrkButton.Height   = buttonHeight;
                wrkButton.Width    = buttonWidth;
                wrkButton.Location = new Point(xPos, yPos);

                // TODO - put imaging stuff here.

                switch (border)
                {
                    default:
                        break;
                }

                return wrkButton;
            }
        }
    }
}