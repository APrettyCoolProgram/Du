/* A nested class for AOControl.cs that does various things with flow layout panel controls.
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
        /// Does various things with flow layout panels.
        /// </summary>
        public class Flp
        {
            /// <summary>
            /// Create a FlowLayoutPanel.
            /// </summary>
            /// <param name="flpName"> DETAILS HERE. </param>
            /// <param name="hgt"> DETAILS HERE. </param>
            /// <param name="wdth"> DETAILS HERE. </param>
            /// <param name="xLoc"> DETAILS HERE. </param>
            /// <param name="yLoc"> DETAILS HERE. </param>
            /// <param name="border"> DETAILS HERE. </param>
            /// <returns> DETAILS HERE. </returns>
            public static FlowLayoutPanel Create(string flpName, int hgt, int wdth, int xLoc, int yLoc, string border)
            {
                FlowLayoutPanel wrkFlp = new FlowLayoutPanel();
                wrkFlp.Name            = flpName;
                wrkFlp.Height          = hgt;
                wrkFlp.Width           = wdth;
                wrkFlp.Location        = new Point(xLoc, yLoc);

                switch (border)
                {
                    case "3D":
                        wrkFlp.BorderStyle = BorderStyle.Fixed3D;
                        break;

                    case "single":
                        wrkFlp.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case "none":
                        wrkFlp.BorderStyle = BorderStyle.None;
                        break;

                    default:
                        break;
                }

                return wrkFlp;
            }
        }
    }
}