// ---------------------------------------------------------------------------------------------------------------------
// Name: DoCheckBox.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with Checkboxes.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AO
{
    public class DoCheckBox
    {
        /// <summary>Does something with checkboxes.</summary>
        /// <param name="contentList"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="incX"></param>
        /// <param name="incY"></param>
        /// <param name="checkBoxPrefix"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static CheckBox[] BuildArray(List<string> contentList, int startX, int startY, int incX, int incY, string checkBoxPrefix, string direction)
        {
            CheckBox[] checkBoxArray = new CheckBox[contentList.Count];
            var boxNum = 0;
            var LocY = startY;
            var LocX = startX;

            // Build a checkbox for each color
            foreach (var eachItem in contentList)
            {
                checkBoxArray[boxNum] = new CheckBox();
                checkBoxArray[boxNum].Name = checkBoxPrefix + eachItem;
                checkBoxArray[boxNum].Text = eachItem;
                checkBoxArray[boxNum].Location = new Point(LocX, LocY);
                boxNum++;

                if (direction == "vertical")
                {
                    LocY += incY;
                }
                else
                {
                    LocX += incX;
                }
            }

            return checkBoxArray;
        }
    }
}

// CHANGELOG
// =========
// 00.90.01.160731: Initial release

// ROADMAP
// =======
// * Proper error handling

// NOTES
// =====