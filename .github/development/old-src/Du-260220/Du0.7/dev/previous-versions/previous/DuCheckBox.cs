#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuCheckBox.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
//  Does things with CheckBox controls.
#endregion

#region USING
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Du
{
    public class DuCheckBox
    {
        /// <summary>Creates a template for a single CheckBox control.</summary>
        /// <param name="prefix">    Control prefix.</param>
        /// <param name="backColor"> Checkbox background color.</param>
        /// <build>180225</build>
        /// <returns>A CheckBox control template.</returns>
        /// <remarks>This method is generally used in conjuction with DuCheckBox.BuildArray(). The ".Name" property of
        /// this template will end up as the prefix to any control it is used to create, so it is recommended that you
        /// leave "prefix" set to "cbx" so that any CheckBoxes that are created using this template will follow best
        /// practice naming conventions.</remarks>
        public static CheckBox CreateTemplate(string prefix, Color backColor) => new CheckBox
        {
            Name = prefix,
            BackColor = backColor
        };

        /// <summary>Builds an array of CheckBox controls from a CheckBox template.</summary>
        /// <param name="template">   The CheckBox template.</param>
        /// <param name="names">      The list of the CheckBox names that will be created.</param>
        /// <param name="xStart">     X-axis starting point for the collection.</param>
        /// <param name="yStart">     Y-axis starting point for the collection.</param>
        /// <param name="xIncrement"> Amount to increment the x-axis on each pass.</param>
        /// <param name="yIncrement"> Amount to increment the y-axis on each pass.</param>
        /// <param name="direction">  The direction the collection should be built [horizontal/vertical]</param>
        /// <build>180225</build>
        /// <returns>A array containing the collection of Checkboxes.</returns>
        /// <remarks>This method will build an array of CheckBox controls, one for each item in the "names" parameter.
        /// It is recommended that you  use DuCheckBox.CreateTemplate() to create a ChecklBox template, which is
        /// required.You will also need to provide additional information about the CheckBox controls so they appear in
        /// their container correctly.</remarks>
        public static CheckBox[] BuildArray(CheckBox template, List<string> names, int xStart, int yStart,
                                            int xIncrement, int yIncrement, string direction)
        {
            var currentCheckBox = 0;
            var currentX        = xStart;
            var currentY        = yStart;
            var checkBoxArray   = new CheckBox[names.Count];

            foreach (var name in names)
            {
                // If template.name=cbx, and name=TheName, the control name will be "cbxTheName"
                checkBoxArray[currentCheckBox] = new CheckBox
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
                }
                currentCheckBox++;
            }
            return checkBoxArray;
        }
    }
}