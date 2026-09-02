#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuButton.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
//  Does things with Button controls.
#endregion

#region USING
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Du
{
    public class DuButton
    {
        /// <summary>Creates a basic Button control template.</summary>
        /// <param name="prefix">    Control prefix.</param>
        /// <param name="size">      Control size.</param>
        /// <param name="backColor"> Control background color.</param>
        /// <build>180225</build>
        /// <returns> Button control template.</returns>
        /// <remarks> Creates an basic Button control. The ".Name" property will end up as the prefix to any button it
        /// is used to create, so it is recommended that  you leave "prefix" set to "btn" to follow best practice naming
        /// conventions.</remarks>
        public static Button Template(string prefix, Size size, Color backColor, FlatStyle flatStyle, Color borderColor,
                                      int borderSize, Color checkedBackColor, Color mouseDownBackColor,
                                      Color mouseOverBackColor)
        {
            return new Button
            {
                BackColor = backColor,
                FlatStyle = flatStyle,
                FlatAppearance =
                {
                    BorderColor        = borderColor,
                    BorderSize         = borderSize,
                    CheckedBackColor   = checkedBackColor,
                    MouseDownBackColor = mouseDownBackColor,
                    MouseOverBackColor = mouseOverBackColor
                },
                Name = prefix,
                Size = size
            };
        }

        /// <summary>Builds an array of Button controls from a Button template.</summary>
        /// <param name="template">   The CheckBox template.</param>
        /// <param name="names">      The list of the CheckBox names that will be created.</param>
        /// <param name="xStart">     X-axis starting point for the collection.</param>
        /// <param name="yStart">     Y-axis starting point for the collection.</param>
        /// <param name="xIncrement"> Amount to increment the x-axis on each pass.</param>
        /// <param name="yIncrement"> Amount to increment the y-axis on each pass.</param>
        /// <param name="direction">  The direction the collection should be built [horizontal/vertical]</param>
        /// <build>180225</build>
        /// <returns>A array containing the collection of Checkboxes.</returns>
        /// <remarks> This method will build an array of Button controls, one for each item in the "names" parameter. It
        /// is recommended that you  use DuButton.CreateTemplate() to create          a Button template, which is
        /// required.You will also need to provide additional information about the Button controls so they appear in
        /// their container correctly.</remarks>
        public static Button[] BuildArray(Button template, List<string> names, int xStart, int yStart, int xIncrement,
                                          int yIncrement, string direction)
        {
            var currentButton = 0;
            var currentX      = xStart;
            var currentY      = yStart;
            var buttonArray   = new Button[names.Count];

            foreach (var name in names)
            {
                // If template.name=cbx, and name=TheName, the control name will be "cbxTheName"
                buttonArray[currentButton] = new Button
                {
                    Name     = template.Name + name.Replace(" ", ""),
                    Size     = template.Size,
                    Location = new Point(currentX, currentY)
                };

                switch (direction)
                {
                    case "vertical":
                        currentY += yIncrement;
                        break;

                    case "horizontal":
                        currentX += xIncrement;
                        break;
                }
                currentButton++;
            }
            return buttonArray;
        }
    }
}