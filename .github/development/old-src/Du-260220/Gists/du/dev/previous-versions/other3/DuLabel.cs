#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuLabel.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with Label controls.
#endregion

#region USING
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Du
{
    public class DuLabel
    {
        /// <summary>Creates a template for a single Label control.</summary>
        /// <param name="prefix">    Control prefix.</param>
        /// <param name="backColor"> Control background color.</param>
        /// <returns>A Label control template.</returns>
        /// <remarks>This method is generally used in conjuction with DuLabel.BuildArray(). The ".Name" property of this
        /// template will end up as the prefix to any control it is used to create, so it is recommended that you leave
        /// "prefix" set to "lbl" so that any Labels that are created using this template will follow best practice
        /// naming conventions.</remarks>
        /// <build>180227</build>
        public static Label CreateTemplate(string prefix, Color backColor)
        {
            return new Label
            {
                Name      = prefix,
                BackColor = backColor
            };
        }

        /// <summary>Builds an array of Label controls from a Label template.</summary>
        /// <param name="template">   The Label template.</param>
        /// <param name="names">      The list of the Label names that will be created.</param>
        /// <param name="xStart">     X-axis starting point for the collection.</param>
        /// <param name="yStart">     Y-axis starting point for the collection.</param>
        /// <param name="xIncrement"> Amount to increment the x-axis on each pass.</param>
        /// <param name="yIncrement"> Amount to increment the y-axis on each pass.</param>
        /// <param name="direction">  The direction the collection should be built [horizontal/vertical]</param>
        /// <returns>A array containing the collection of Label. </returns>
        /// <remarks>This method will build an array of Label controls, one for each item in the "names" parameter. It
        /// is recommended required.You will also need to provide additional information about the Label controls so
        /// they appear in their container correctly.</remarks>                                                                                                                                                         container correctly.</remarks>
        /// <build>180227</build>
        public static Label[] BuildArray(Label template, List<string> names, int xStart, int yStart, int xIncrement, int yIncrement, string direction)
        {
            var currentLabel = 0;
            var currentX     = xStart;
            var currentY     = yStart;
            var labelArray   = new Label[names.Count];

            foreach (var name in names)
            {
                // Note that if template.name=cbx, and name=TheName, the control name will be "cbxTheName"
                labelArray[currentLabel] = new Label
                {
                    Name     = template.Name + name.Replace(" ", ""),
                    Text     = name,
                    Location = new Point(currentX, currentY)
                };

                switch (direction)
                {
                    case "vertical":
                        currentY += xIncrement;
                        break;

                    case "horizontal":
                        currentX += yIncrement;
                        break;

                    default:
                        break;
                }

                currentLabel++;
            }

            return labelArray;
        }
    }
}