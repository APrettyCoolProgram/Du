/* A nested class for AOControl.cs that does various things with panel controls.
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
        /// Does various things with panels.
        /// </summary>
        public class Pnl
        {
            /// <summary>
            /// Create a panel.
            /// </summary>
            /// <param name="panelName"> DETAILS HERE. </param>
            /// <param name="pnlHght"> DETAILS HERE. </param>
            /// <param name="pnlWdth"> DETAILS HERE. </param>
            /// <param name="yPos"> DETAILS HERE. </param>
            /// <param name="xPos"> DETAILS HERE. </param>
            /// <param name="border"> DETAILS HERE. </param>
            /// <returns> DETAILS HERE. </returns>
            public static Panel Create(string panelName, int pnlHght, int pnlWdth, int yPos, int xPos, string border)
            {
                Panel wrkPanel    = new Panel();
                wrkPanel.Name     = panelName;
                wrkPanel.Height   = pnlHght;
                wrkPanel.Width    = pnlWdth;
                wrkPanel.Location = new Point(xPos, yPos);

                switch (border)
                {
                    case "fixed3D":
                        wrkPanel.BorderStyle = BorderStyle.Fixed3D;
                        break;

                    case "fixedSingle":
                        wrkPanel.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case "none":
                        wrkPanel.BorderStyle = BorderStyle.None;
                        break;

                    default:
                        break;
                }

                return wrkPanel;
            }
        }
    }
}