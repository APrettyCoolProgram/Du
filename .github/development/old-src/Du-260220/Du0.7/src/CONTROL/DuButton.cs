// =====================================================================================================================
//    FILE: Du.DuButton.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 3-30-2021-9:58 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Du
{
    /// <summary>Does things with WPF Label controls.</summary>
    public class DuButton
    {
        /////// <summary>Create a template for a single Button control.</summary>
        /////// <param name="prefix">    Button prefix [e.g., "btn"].</param>
        /////// <param name="size">      Button size.</param>
        /////// <param name="backColor"> Button background color.</param>
        /////// <build>180225</build>
        /////// <returns> Button control template.</returns>
        /////// <remarks> Creates an basic Button control. The ".Name" property will end up as the prefix to any button it
        /////// is used to create, so it is recommended that  you leave "prefix" set to "btn" to follow best practice naming
        /////// conventions.</remarks>


        public static void Template(string btnPrefix, double btnWidth, double btnHeight, HorizontalAlignment btnHorizontalAlignment,
                                    VerticalAlignment btnVerticalAlignment, Brush btnBackground, Brush btnForeground)
        {
            var btn2 = new Button()
            {
                Name                       = btnPrefix,
                Width                      = btnWidth,
                Height                     = btnHeight,
                HorizontalAlignment        = btnHorizontalAlignment,
                HorizontalContentAlignment = btnHorizontalAlignment,
                VerticalAlignment          = btnVerticalAlignment,
                VerticalContentAlignment   = btnVerticalAlignment,
                Background                 = btnBackground,
                Foreground                 = btnForeground,
                Content                    = "Test"
            };
        }
    }

    ///////// <summary>Builds an array of Button controls from a Button template.</summary>
    ///////// <param name="template">   The CheckBox template.</param>
    ///////// <param name="names">      The list of the CheckBox names that will be created.</param>
    ///////// <param name="xStart">     X-axis starting point for the collection.</param>
    ///////// <param name="yStart">     Y-axis starting point for the collection.</param>
    ///////// <param name="xIncrement"> Amount to increment the x-axis on each pass.</param>
    ///////// <param name="yIncrement"> Amount to increment the y-axis on each pass.</param>
    ///////// <param name="direction">  The direction the collection should be built [horizontal/vertical]</param>
    ///////// <build>180225</build>
    ///////// <returns>A array containing the collection of Checkboxes.</returns>
    ///////// <remarks> This method will build an array of Button controls, one for each item in the "names" parameter. It
    ///////// is recommended that you  use DuButton.CreateTemplate() to create          a Button template, which is
    ///////// required.You will also need to provide additional information about the Button controls so they appear in
    ///////// their container correctly.</remarks>



    //public static Button[] BuildArray(Button template, List<string> names, int xStart, int yStart, int xIncrement,
    //                                  int yIncrement, string direction)
    //{
    //    var currentButton = 0;
    //    var currentX      = xStart;
    //    var currentY      = yStart;
    //    var buttonArray   = new Button[names.Count];

    //    foreach(var name in names)
    //    {
    //        // If template.name=cbx, and name=TheName, the control name will be "cbxTheName"
    //        buttonArray[currentButton] = new Button
    //        {
    //            //Name = template.Name + name.Replace(" ", ""),
    //            //Size = template.Size,
    //            //Location = new Point(currentX, currentY)
    //        };

    //        switch(direction)
    //        {
    //            case "vertical":
    //                currentY += yIncrement;
    //                break;

    //            case "horizontal":
    //                currentX += xIncrement;
    //                break;
    //        }
    //        currentButton++;
    //    }
    //    return buttonArray;
    //}
}