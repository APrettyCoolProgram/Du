#region PROJECT_HEADER
//   PROJECT: Sobchak
//  FILENAME: DuPanel.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Sobchak
#endregion

#region CLASS_DESCRIPTION
// Does things with Panel controls.
#endregion

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Du
{
    public class DuPanel
    {
        /// <summary>Creates a basic Panel control template.</summary>
        /// <param name="prefix">    Control prefix.</param>
        /// <param name="size">      Control size.</param>
        /// <param name="backColor"> Control background color.</param>
        /// <returns>A Panel control template.</returns>
        /// <remarks>Creates an basic Panel control. The ".Name" property will end up as the prefix to any button it is
        /// used to create, so it is recommended that  you leave "prefix" set to "btn" to follow best practice naming
        /// conventions.</remarks>
        /// <build>180227</build>
        public static Panel Template(string prefix, Size size, Color backColor, BorderStyle borderStyle)
        {
            return new Panel
            {
                BackColor   = backColor,
                BorderStyle = borderStyle,
                Name        = prefix,
                Size        = size,
            };
        }

        /// <summary>Builds an array of Panel controls from a Panel template.</summary>
        /// <param name="template">   The CheckBox template.</param>
        /// <param name="names">      The list of the CheckBox names that will be created.</param>
        /// <param name="xStart">     X-axis starting point for the collection.</param>
        /// <param name="yStart">     Y-axis starting point for the collection.</param>
        /// <param name="xIncrement"> Amount to increment the x-axis on each pass.</param>
        /// <param name="yIncrement"> Amount to increment the y-axis on each pass.</param>
        /// <param name="direction">  The direction the collection should be built [horizontal/vertical]</param>
        /// <returns>A array containing the collection of Checkboxes.</returns>
        /// <remarks>This method will build an array of Panel controls, one for each item in the "names" parameter. It
        /// is recommended required.You will also need to provide additional information about the Panel controls so
        /// they appear in their controls correctly.</remarks>                                                                                                                                                              container correctly.</remarks>
        /// <build>180227</build>
        public static Panel[] BuildArray(Panel template, List<string> names, int xStart, int yStart, int xIncrement,
                                          int yIncrement, string direction)
        {
            var currentPanel = 0;
            var currentX     = xStart;
            var currentY     = yStart;
            var buttonArray  = new Panel[names.Count];

            foreach (var name in names)
            {
                // Note that if template.name=cbx, and name=TheName, the control name will be "cbxTheName"
                buttonArray[currentPanel] = new Panel()
                {
                    Name     = template.Name + name.Replace(" ", ""),
                    Size     = template.Size,
                    Location = new Point(currentX, currentY)
                };

                //TODO  Should have something about the name here.

                switch (direction)
                {
                    case "vertical":
                        currentY += yIncrement;
                        break;
                    case "horizontal":
                        currentX += xIncrement;
                        break;
                    default:
                        // This will break if neither "vertical" or "horizontal" are passed.
                        break;
                }

                currentPanel++;
            }

            return buttonArray;
        }
    }
}