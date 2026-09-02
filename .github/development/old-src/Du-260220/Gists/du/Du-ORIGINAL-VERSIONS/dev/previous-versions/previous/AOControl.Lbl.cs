/* A nested class for AOControl.cs that does various things with label controls.
 * v00.53.00.16XXXX
 * http://aprettycoolprogram.com/ao
 */

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AO
{
    partial class AOControl
    {
        /// <summary>
        /// Does various things with labels.
        /// </summary>
        public class Lbl
        {
            /// <summary>
            /// Creates an array of checkbox controls.
            /// </summary>
            /// <param name="labelList"> DETAILS HERE. </param>
            /// <param name="yPos"> DETAILS HERE. </param>
            /// <param name="xPos"> DETAILS HERE. </param>
            /// <param name="yInc"> DETAILS HERE. </param>
            /// <param name="xInc"> DETAILS HERE. </param>
            /// <param name="ctrlPrefix"> DETAILS HERE. </param>
            /// <param name="mv"> DETAILS HERE. </param>
            /// <param name="cWdth"> DETAILS HERE. </param>
            /// <param name="cHght"> DETAILS HERE. </param>
            /// <returns> DETAILS HERE. </returns>
            public static System.Windows.Forms.Label[] BuildArray(List<string> labelList, int yPos, int xPos, int yInc, int xInc, string ctrlPrefix, string mv, int cWdth, int cHght)
            {
                var ele            = 0;
                var noSpcNm        = string.Empty;
                var yPosReset      = yPos;
                Label[] labelArray = new Label[labelList.Count];

                foreach (var lbl in labelList)
                {
                    noSpcNm = AOString.Remove(lbl, "spc", null);
                    labelArray[ele] = new System.Windows.Forms.Label();
                    labelArray[ele].Text = lbl;
                    labelArray[ele].Name = ctrlPrefix + noSpcNm;

                    if (cWdth != 0)
                    {
                        if (yPos + yInc > cHght)
                        {
                            yPos = yPosReset;
                            xPos += cWdth;
                        }
                    }

                    labelArray[ele].Location = new Point(xPos, yPos);
                    ele++;

                    if (mv == "vert")
                    {
                        yPos += yInc;
                    }
                    else if (mv == "horz")
                    {
                        xPos += xInc;
                    }
                }
                return labelArray;
            }

            /// <summary>Applies a color scheme to all labels on a form.</summary>
            /// <param name="formName"> DETAILS HERE. </param>
            /// <param name="backgroundColor"> DETAILS HERE. </param>
            /// <param name="foregroundColor"> DETAILS HERE. </param>
            public static void PaintAll(Form formName, string backgroundColor, string foregroundColor)
            {
                foreach (Control control in formName.Controls.OfType<System.Windows.Forms.Label>())
                {
                    control.BackColor = Color.FromName(backgroundColor);
                    control.ForeColor = Color.FromName(foregroundColor);
                }
            }
        }
    }
}