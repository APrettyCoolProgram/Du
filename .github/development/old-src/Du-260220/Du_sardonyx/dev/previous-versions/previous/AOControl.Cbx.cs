/* A nested class for AOControl.cs that does various things with checkbox controls.
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
        /// Does various things with checkboxes.
        /// </summary>
        public class Cbx
        {
            /// <summary>
            /// Creates an array of CheckBox controls.
            /// </summary>
            /// <param name="checkboxList"> DETAILS HERE. </param>
            /// <param name="xPos"> DETAILS HERE. </param>
            /// <param name="yPos"> DETAILS HERE. </param>
            /// <param name="xInc"> DETAILS HERE. </param>
            /// <param name="yInc"> DETAILS HERE. </param>
            /// <param name="ctrlPrefix"> DETAILS HERE. </param>
            /// <param name="mv"> DETAILS HERE. </param>
            /// <returns> DETAILS HERE. </returns>
            public static System.Windows.Forms.CheckBox[] BuildArray(List<string> checkboxList, int xPos, int yPos, int xInc, int yInc, string ctrlPrefix, string mv)
            {
                var element = 0;
                var noSpaceName = string.Empty;
                CheckBox[] checkboxArray = new CheckBox[checkboxList.Count];

                foreach (var checkbox in checkboxList)
                {
                    noSpaceName = AOString.Remove(checkbox, "spc", null);
                    checkboxArray[element] = new System.Windows.Forms.CheckBox();
                    checkboxArray[element].Text = checkbox;
                    checkboxArray[element].Name = ctrlPrefix + noSpaceName;
                    checkboxArray[element].Location = new Point(xPos, yPos);
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

                return checkboxArray;
            }
        }
    }
}